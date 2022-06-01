using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System.Data;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class PersonalAppointment : Form
    {
        private readonly PatientMain Parent;
        private Appointment? Appointment;
        private readonly bool IsDoctorSelected;
        private bool IsCreate
        {
            get
            {
                return Appointment == null || IsDoctorSelected;
            }
        }

        #region Form
        public PersonalAppointment(PatientMain parent, Appointment? appointment, bool isDoctorSelected = false)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
            IsDoctorSelected = isDoctorSelected;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
            FillFormDetails();
        }
        private void FillFormDetails()
        {
            if (IsCreate) SetupAsCreate();
            else SetupAsModify();
        }
        private void SetupAsCreate()
        {
            DoctorComboBox.Enabled = false;
            DoctorComboBox.SelectedIndex = Parent.DoctorComboBox.SelectedIndex;

            if (IsDoctorSelected)
            {
                SetDoctorComboBoxIndex();
                return; 
            }

            DatePicker.Enabled = false;
            DatePicker.Value = Parent.AppointmentDatePicker.Value;
        }
        private void SetupAsModify()
        {
            DatePicker.Enabled = true;
            DatePicker.Value = Appointment.dateTime.Date;
            TimePicker.Enabled = true;
            TimePicker.Value = Appointment.dateTime;
            DoctorComboBox.Enabled = true;
            SetDoctorComboBoxIndex();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (IsCreate) Create();
            else Modify();
        }
        private void Create()
        {
            if (!UIUtilities.Confirm("Are you sure you want to create this Appoinment ?")) return;

            Appointment = new Appointment(GetSelectedDoctorID(), Parent.Patient.ID, GetSelectedDateTime());
            AppointmentRepository.GetInstance().Create(Appointment);

            Parent.PersonalAppointmentsTable.Insert(Appointment);
            if (!IsDoctorSelected) Parent.OccupiedAppointmentsTable.Insert(Appointment);

            Close();
        }
        private void Modify()
        {
            if (!UIUtilities.Confirm("Are you sure you want to save the changes?")) return;

            Appointment.doctorID = GetSelectedDoctorID();
            Appointment.dateTime = GetSelectedDateTime();

            bool needApproval = DateTime.Now.AddDays(2).Date >= Appointment.dateTime.Date;
            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            PatientRequestService.Send(!needApproval, Appointment, PatientRequest.Types.Modify);
            if (!needApproval)
            {
                AppointmentService.Modify(Appointment);
                Parent.PersonalAppointmentsTable.ModifySelected(Appointment);
            }
            Close();
        }  
        private int GetSelectedDoctorID()
        {
            return (DoctorComboBox.SelectedItem as User).ID;
        }
        private DateTime GetSelectedDateTime()
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            var dateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
            return dateTime;
        }
        private void SetDoctorComboBoxIndex()
        {
            User selected = UserRepository.GetDoctor(Appointment.doctorID);
            DoctorComboBox.SelectedIndex = DoctorComboBox.Items.IndexOf(selected);
        }
        private bool ValidateForm()
        {
            if (!Parent.IsDateValid(GetSelectedDateTime())) return false;
            if (!DoctorService.IsOccupied(GetSelectedDateTime(), GetSelectedDoctorID())) return true;
            MessageBoxUtilities.ShowErrorMessage("This time is occupied!");
            return false;
        }
    }
}