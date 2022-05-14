using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System.Data;
using Klinika.Services;

namespace Klinika.GUI.Patient
{
    public partial class PersonalAppointment : Form
    {
        private readonly PatientMain Parent;
        private Appointment? Appointment;

        #region Form
        public PersonalAppointment(PatientMain parent, Appointment appointment)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            Parent.FillDoctorComboBox(DoctorComboBox);
            SetAppointmentDetails();
        }
        private void SetAppointmentDetails()
        {
            if (Appointment == null)
            {
                DatePicker.Enabled = false;
               
                DatePicker.Value = Parent.AppointmentDatePicker.Value;
                DoctorComboBox.Enabled = false;
                DoctorComboBox.SelectedIndex = Parent.DoctorComboBox.SelectedIndex;
            }
            else
            {
                DatePicker.Enabled = true;
                DatePicker.Value = Appointment.DateTime.Date;
                TimePicker.Enabled = true;
                TimePicker.Value = Appointment.DateTime;
                DoctorComboBox.Enabled = true;
                DoctorComboBox.SelectedIndex = DoctorComboBox.Items.IndexOf(UserRepository.GetInstance().Users.Where(x => x.ID == Appointment.DoctorID).FirstOrDefault());
            }
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Click functions
        private void ConfirmeButtonClick(object sender, EventArgs e)
        {
            if (!Parent.IsDateValid(GetSelectedDateTime()))
            {
                return;
            }
            if (Appointment == null)
            {
                if (!AppointmentRepository.GetInstance().IsOccupied(GetSelectedDateTime(), GetDoctorID()))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to create this Appoinment?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CreateAppointment();
                        Close();
                    }
                    return;
                }
            }
            else
            {
                if (!AppointmentRepository.GetInstance().IsOccupied(GetSelectedDateTime(), GetDoctorID(), 15, Appointment.ID))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ModifyAppointment();
                        Close();
                    }
                    return;
                }
            }

            MessageBox.Show("This time is occupied!", "Denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion

        #region Helper functions
        private void CreateAppointment()
        {
            Appointment = new Appointment();
            Appointment.ID = -1;
            Appointment.DoctorID = GetDoctorID();
            Appointment.PatientID = Parent.Patient.ID;
            Appointment.DateTime = GetSelectedDateTime();
            Appointment.RoomID = 1;
            Appointment.Completed = false;
            Appointment.Type = 'E';
            Appointment.Duration = 15;
            Appointment.Urgent = false;
            Appointment.Description = "";
            Appointment.IsDeleted = false;
            AppointmentRepository.GetInstance().Create(Appointment);
            Parent.InsertRowIntoPersonalAppointmentsTable(Appointment);
            Parent.InsertRowIntoOccupiedTable(Appointment);
        }
        private void ModifyAppointment()
        {
            Appointment.DoctorID = GetDoctorID();
            Appointment.DateTime = GetSelectedDateTime();

            bool needApproval = DateTime.Now.AddDays(2).Date >= Appointment.DateTime.Date;

            if (needApproval)
            {
                DialogResult sendConfirmation = MessageBox.Show("Changes that you have requested have to be check by secretary. " +
                    "Do you want to send request? ", "Send Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sendConfirmation == DialogResult.Yes)
                {
                    SendPatientRequest(!needApproval);
                }

                return;
            }

            SendPatientRequest(!needApproval);
            AppointmentRepository.GetInstance().Modify(Appointment);
            Parent.ModifyPersonalAppointmentTableRow(Appointment);
        }
        private void SendPatientRequest(bool isApproved)
        {
            PatientRequest patientRequest = new PatientRequest();
            patientRequest.PatientID = Appointment.PatientID;
            patientRequest.MedicalActionID = Appointment.ID;
            patientRequest.Type = 'M';
            patientRequest.Description = PatientRequestService.GenerateDescription(GetSelectedDateTime(), GetDoctorID());
            patientRequest.Approved = isApproved;
            PatientRequestRepository.Create(patientRequest);
        }   
        private int GetDoctorID()
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
        #endregion
    }
}
