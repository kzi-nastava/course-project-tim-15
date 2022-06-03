using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class PersonalAppointment : Form
    {
        private readonly NewAppointment? parentNewAppointment;
        private readonly ViewSchedule? parentViewSchedule;
        private Appointment? appointment;
        private readonly bool isDoctorSelected;
        private bool IsCreate
        {
            get
            {
                return appointment == null || isDoctorSelected;
            }
        }

        #region Form
        public PersonalAppointment(ViewSchedule parent, Appointment? appointment, bool isDoctorSelected = false)
        {
            InitializeComponent();
            parentViewSchedule = parent;
            this.appointment = appointment;
            this.isDoctorSelected = isDoctorSelected;
        }
        public PersonalAppointment(NewAppointment parent)
        {
            InitializeComponent();
            parentNewAppointment = parent;
            appointment = null;
            isDoctorSelected = false;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            //parent.Enabled = false;
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
            DoctorComboBox.SelectedIndex = parentNewAppointment.DoctorComboBox.SelectedIndex;

            if (isDoctorSelected)
            {
                SetDoctorComboBoxIndex();
                return; 
            }

            DatePicker.Enabled = false;
            DatePicker.Value = parentNewAppointment.AppointmentDatePicker.Value;
        }
        private void SetupAsModify()
        {
            DatePicker.Enabled = true;
            DatePicker.Value = appointment.dateTime.Date;
            TimePicker.Enabled = true;
            TimePicker.Value = appointment.dateTime;
            DoctorComboBox.Enabled = true;
            SetDoctorComboBoxIndex();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            //parent.Enabled = true;
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

            appointment = new Appointment(GetSelectedDoctorID(), parentNewAppointment.parent.patient.id, GetSelectedDateTime());
            AppointmentRepository.GetInstance().Create(appointment);

            //parentViewSchedule.PersonalAppointmentsTable.Insert(appointment);
            if (!isDoctorSelected) parentNewAppointment.OccupiedAppointmentsTable.Insert(appointment);

            Close();
        }
        private void Modify()
        {
            if (!UIUtilities.Confirm("Are you sure you want to save the changes?")) return;

            appointment.doctorID = GetSelectedDoctorID();
            appointment.dateTime = GetSelectedDateTime();

            bool needApproval = DateTime.Now.AddDays(2).Date >= appointment.dateTime.Date;
            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            PatientRequestService.Send(!needApproval, appointment, PatientRequest.Types.Modify);
            if (!needApproval)
            {
                AppointmentService.Modify(appointment);
                parentViewSchedule.PersonalAppointmentsTable.ModifySelected(appointment);
            }
            Close();
        }  
        private int GetSelectedDoctorID()
        {
            return (DoctorComboBox.SelectedItem as User).id;
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
            User selected = UserRepository.GetDoctor(appointment.doctorID);
            DoctorComboBox.SelectedIndex = DoctorComboBox.Items.IndexOf(selected);
        }
        private bool ValidateForm()
        {
            if (!IsDateValid(GetSelectedDateTime())) return false;
            if (!DoctorService.IsOccupied(GetSelectedDateTime(), GetSelectedDoctorID())) return true;
            MessageBoxUtilities.ShowErrorMessage("This time is occupied!");
            return false;
        }
        public bool IsDateValid(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
    }
}