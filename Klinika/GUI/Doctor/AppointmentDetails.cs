using Klinika.Appointments.Models;
using Klinika.Appointments.Services;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Rooms.Models;
using Klinika.Rooms.Services;
using Klinika.Schedule.Models;
using Klinika.Schedule.Services;
using Klinika.Users.Models;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class AppointmentDetails : Form
    {
        private readonly DoctorScheduleService? scheduleService;
        private readonly AppointmentService? appointmentService;
        private readonly RoomServices? roomServices;
        private readonly UserService? userService;
        internal readonly ViewAllAppointments parent;
        private Appointment? appointment;

        public AppointmentDetails(ViewAllAppointments parent, Appointment? appointment = null)
        {
            InitializeComponent();
            this.parent = parent;
            this.appointment = appointment;
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            roomServices = StartUp.serviceProvider.GetService<RoomServices>();
            userService = StartUp.serviceProvider.GetService<UserService>();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            UIUtilities.FillPatientComboBox(PatientComboBox);

            if (appointment == null)
            {
                SetType(Appointment.Types.EXAMINATION);
                return;
            }

            FillFormWithAppointmentData();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;

        private void FillFormWithAppointmentData()
        {
            DatePicker.Value = appointment.dateTime;
            TimePicker.Value = appointment.dateTime;
            PatientComboBox.SelectedIndex = PatientComboBox.Items.IndexOf(userService.GetSingle(appointment.patientID));

            SetType((Appointment.Types)appointment.type, appointment.duration);

            IsUrgentCheckBox.Checked = appointment.urgent;
            ConfirmButton.Text = "Save";
        }
        private void SetType(Appointment.Types type, int duration = -1)
        {
            ExaminationRadioButton.Checked = type == Appointment.Types.EXAMINATION;
            OperationRadioButton.Checked = type == Appointment.Types.OPERATION;
            RoomComboBox.Enabled = type == Appointment.Types.OPERATION;
            RoomComboBox.SelectedIndex = type == Appointment.Types.OPERATION ? SetOperationRoom() : SetExaminationRoom();
            DurationTextBox.Enabled = type == Appointment.Types.OPERATION;
            DurationTextBox.Text = type == Appointment.Types.EXAMINATION ? "15"
                : duration == -1 ? "" : duration.ToString();
        }
        private int SetExaminationRoom()
        {
            RoomComboBox.Items.Clear();
            RoomComboBox.Items.Add(roomServices.GetDoctorOffice(parent.doctor.officeID));
            return 0;
        }
        private int SetOperationRoom()
        {
            RoomComboBox.Items.Clear();
            RoomComboBox.Items.AddRange(roomServices.GetOperationRooms());
            if (appointment == null || appointment.roomID == 1) return 0;
            var rooms = RoomComboBox.Items.Cast<Room>().Select(x => x).ToList();
            var room = rooms.Where(x => x.id == appointment.roomID).FirstOrDefault();
            return RoomComboBox.Items.IndexOf(room);
        }
        private void ExaminationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SetType(ExaminationRadioButton.Checked ? Appointment.Types.EXAMINATION : Appointment.Types.OPERATION);
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (appointment != null) Modify();
            else Create();

            Close();
        }

        private bool ValidateForm()
        {
            if (GetSelectedDateTime() < DateTime.Now)
            {
                MessageBoxUtilities.ShowErrorMessage("Date or time is not valid!");
                return false;
            }
            if (PatientComboBox.SelectedIndex == -1)
            {
                MessageBoxUtilities.ShowErrorMessage("Patient is not valid!");
                return false;
            }
            if (scheduleService.IsOccupied(parent.doctor.id, new TimeSlot(GetSelectedDateTime(),
                Convert.ToInt32(DurationTextBox.Text)), appointment == null ? -1 : appointment.id))
            {
                MessageBoxUtilities.ShowErrorMessage("Already occupied!");
                return false;
            }
            if (roomServices.IsOccupied((RoomComboBox.SelectedItem as Room).id,new TimeSlot(GetSelectedDateTime(), 
                Convert.ToInt32(DurationTextBox.Text)), appointment == null ? -1 : appointment.id))
            {
                MessageBoxUtilities.ShowErrorMessage("Room is occupied!");
                return false;
            }
            return true;
        }
        private DateTime GetSelectedDateTime()
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            return DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
        }
        private void TransferDataFromUI(Appointment appointment)
        {
            appointment.doctorID = parent.doctor.id;
            appointment.patientID = (PatientComboBox.SelectedItem as User).id;
            appointment.roomID = (RoomComboBox.SelectedItem as Room).id;
            appointment.type = ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.duration = Convert.ToInt32(DurationTextBox.Text);
            appointment.urgent = IsUrgentCheckBox.Checked;
            appointment.description = "";
        }
        //TODO @s
        private void Modify()
        {
            appointment.dateTime = GetSelectedDateTime();
            TransferDataFromUI(appointment);
            appointmentService.Modify(appointment);
            parent.AllAppointmentsTable.ModifySelected(appointment);
        }
        private void Create()
        {
            var appointment = new Appointment(GetSelectedDateTime());
            TransferDataFromUI(appointment);
            appointmentService.Create(appointment);
            parent.AllAppointmentsTable.Insert(appointment);
        }
    }
}