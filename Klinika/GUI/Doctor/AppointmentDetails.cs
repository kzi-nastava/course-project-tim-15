using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class AppointmentDetails : Form
    {
        internal readonly DoctorMain Parent;
        private Appointment? Appointment;

        public AppointmentDetails(DoctorMain parent, Appointment? appointment = null)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            UIUtilities.FillPatientComboBox(PatientComboBox);

            if (Appointment == null)
            {
                SetType(Appointment.Types.EXAMINATION);
                return;
            }

            FillFormWithAppointmentData();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }

        private void FillFormWithAppointmentData()
        {
            DatePicker.Value = Appointment.DateTime;
            TimePicker.Value = Appointment.DateTime;
            PatientComboBox.SelectedIndex = PatientComboBox.Items.IndexOf(PatientService.GetSingle(Appointment.PatientID));

            SetType((Appointment.Types)Appointment.Type, Appointment.Duration);

            IsUrgentCheckBox.Checked = Appointment.Urgent;
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
            RoomComboBox.Items.Add(DoctorService.GetOffice(Parent._Doctor.OfficeID));
            return 0;
        }
        private int SetOperationRoom()
        {
            RoomComboBox.Items.Clear();
            RoomComboBox.Items.AddRange(RoomServices.GetOperationRooms());
            if (Appointment == null || Appointment.RoomID == 1) return -1;
            var rooms = RoomComboBox.Items.Cast<Room>().Select(x => x).ToList();
            var room = rooms.Where(x => x.ID == Appointment.RoomID).FirstOrDefault();
            return RoomComboBox.Items.IndexOf(room);
        }
        private void ExaminationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SetType(ExaminationRadioButton.Checked ? Appointment.Types.EXAMINATION : Appointment.Types.OPERATION);
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (Appointment != null) Modify();
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
            if (DoctorService.IsOccupied(GetSelectedDateTime(), Parent._Doctor.ID, 
                Convert.ToInt32(DurationTextBox.Text), Appointment == null ? -1 : Appointment.ID))
            {
                MessageBoxUtilities.ShowErrorMessage("Already occupied!");
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
            appointment.DoctorID = Parent._Doctor.ID;
            appointment.PatientID = (PatientComboBox.SelectedItem as User).ID;
            appointment.RoomID = (RoomComboBox.SelectedItem as Room).ID;
            appointment.Type = ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.Duration = Convert.ToInt32(DurationTextBox.Text);
            appointment.Urgent = IsUrgentCheckBox.Checked;
            appointment.Description = "";
        }
        private void Modify()
        {
            Appointment.DateTime = GetSelectedDateTime();
            TransferDataFromUI(Appointment);
            AppointmentService.Modify(Appointment);
            Parent.AllAppointmentsTable.ModifySelected(Appointment);
        }
        private void Create()
        {
            var appointment = new Appointment(GetSelectedDateTime());
            TransferDataFromUI(appointment);
            AppointmentService.Create(appointment);
            Parent.AllAppointmentsTable.Insert(appointment);
        }
    }
}