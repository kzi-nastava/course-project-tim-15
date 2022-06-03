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
        private readonly SearchDoctors? parentSearchDoctor;
        private Appointment? appointment;
        private readonly bool isDoctorSelected;
        private int patientID;
        private bool IsCreate
        {
            get
            {
                return appointment == null || isDoctorSelected;
            }
        }

        #region Form
        public PersonalAppointment(ViewSchedule parent, Appointment appointment)
        {
            InitializeComponent();
            parentViewSchedule = parent;
            this.appointment = appointment;
            isDoctorSelected = false;
            parentViewSchedule.Enabled = false;
            patientID = parent.parent.patient.id;
        }
        public PersonalAppointment(SearchDoctors parent, Appointment appointment)
        {
            InitializeComponent();
            parentSearchDoctor = parent;
            this.appointment = appointment;
            isDoctorSelected = true;
            parentSearchDoctor.Enabled = false;
            patientID = parent.parent.patient.id;
        }
        public PersonalAppointment(NewAppointment parent)
        {
            InitializeComponent();
            parentNewAppointment = parent;
            appointment = null;
            isDoctorSelected = false;
            parentNewAppointment.Enabled = false;
            patientID = parent.parent.patient.id;
        }
        private void LoadForm(object sender, EventArgs e)
        {
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
            if (isDoctorSelected)
            {
                SetDoctorComboBoxIndex();
                return;
            }
            DoctorComboBox.Enabled = false;
            DoctorComboBox.SelectedIndex = parentNewAppointment.DoctorComboBox.SelectedIndex;

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
            if (parentViewSchedule != null) parentViewSchedule.Enabled = true;
            if (parentSearchDoctor != null) parentSearchDoctor.Enabled = true;
            if (parentNewAppointment != null) parentNewAppointment.Enabled = true;
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

            appointment = new Appointment(GetSelectedDoctorID(), patientID, GetSelectedDateTime());
            AppointmentRepository.GetInstance().Create(appointment);

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