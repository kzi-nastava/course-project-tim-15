using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;
using System.Data;
using RDoctor = Klinika.Roles.Doctor;
using RPatient = Klinika.Roles.Patient;

namespace Klinika.GUI.Patient
{
    public partial class PatientMain : Form
    {
        RDoctor.Filters selectedDoctorFilter = RDoctor.Filters.BY_NAME;
        public RPatient patient { get; }

        #region Form
        public PatientMain(int patientID)
        {
            InitializeComponent();
            patient = PatientService.GetById(patientID);
            System.Diagnostics.Debug.WriteLine(patient.notificationOffset);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            InitPersonalAppointmentsTab();
            FillNotificationsTable(NotificationService.Get(patient));
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
            FillSpecializationsComboBox();
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1) InitNewAppointmentTab();
            if ((sender as TabControl).SelectedIndex == 2) InitMedicalRecorTab();
            if ((sender as TabControl).SelectedIndex == 3) InitDoctorsTab();
            if ((sender as TabControl).SelectedIndex == 4) InitNotificationsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Personal Appointments Tab
        private void InitPersonalAppointmentsTab()
        {
            PersonalAppointmentsTable.Fill(AppointmentRepository.GetAll(patient.id, User.RoleType.PATIENT));
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
        }
        private void PersonalAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }
        private void ModifyAppointmentButtonClick(object sender, EventArgs e)
        {
            //new PersonalAppointment(this, PersonalAppointmentsTable.GetSelected()).Show();
        }
        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to delete selected appointment?")) return;

            Appointment selected = PersonalAppointmentsTable.GetSelected();
            bool needApproval = DateTime.Now.AddDays(2).Date >= selected.dateTime.Date;

            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            PatientRequestService.Send(!needApproval, selected, PatientRequest.Types.Delete);
            if (needApproval) return;

            AppointmentService.Delete(selected.id);
            PersonalAppointmentsTable.DeleteSelected();
        }
        #endregion

        #region New Appointment Tab
        private void InitNewAppointmentTab()
        {
            ScheduleButton.Enabled = false;
            OccupiedAppointmentsTable.DataSource = new DataTable();
        }
        private void FindAppointmentsButtonClick(object sender, EventArgs e)
        {
            if (!IsDateValid(AppointmentDatePicker.Value)) return;

            int doctorID = (DoctorComboBox.SelectedItem as User).id;
            OccupiedAppointmentsTable.Fill(DoctorService.GetAppointments(AppointmentDatePicker.Value, doctorID));
            ScheduleButton.Enabled = true;
        }
        private void ScheduleAppointmentButtonClick(object sender, EventArgs e)
        {
            //new PersonalAppointment(this, null).Show();
        }
        private void RecommendButtonClick(object sender, EventArgs e)
        {
            //new AppointmentRecommendation(this).Show();
        }
        #endregion

        #region Medical Record Tab
        private void InitMedicalRecorTab()
        {
            FillMedicalRecordTable(AnamnesisService.Get(patient.id));
        }
        private void FillMedicalRecordTable(List<Anamnesis> anamneses)
        {
            List<Appointment> appointments = AppointmentService.GetCompleted(patient.id);

            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("Appointment ID");
            anamnesesData.Columns.Add("Doctor");
            anamnesesData.Columns.Add("Doctor Specialization");
            anamnesesData.Columns.Add("DateTime");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");

            foreach (Anamnesis anamnesis in anamneses)
            {
                DataRow newRow = anamnesesData.NewRow();
                Appointment appointment = appointments.Where(x => x.id == anamnesis.medicalActionID).FirstOrDefault();
                newRow["Appointment ID"] = anamnesis.medicalActionID;
                newRow["Doctor"] = DoctorService.GetFullName(appointment.doctorID);
                newRow["Doctor Specialization"] = DoctorService.GetSpecialization(appointment.doctorID);
                newRow["DateTime"] = appointment.dateTime;
                newRow["Description"] = anamnesis.description;
                newRow["Symptoms"] = anamnesis.symptoms;
                newRow["Conclusion"] = anamnesis.conclusion;
                anamnesesData.Rows.Add(newRow);
            }
            MedicalRecordTable.DataSource = anamnesesData;
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            string searchParam = SearchTextBox.Text;
            List<Anamnesis> searchResoult = AnamnesisService.GetFiltered(patient.id, searchParam);
            FillMedicalRecordTable(searchResoult);
        }
        private void ResetButtonClick(object sender, EventArgs e)
        {
            InitMedicalRecorTab();
            SearchTextBox.Text = "";
        }
        #endregion

        #region Doctors Tab
        private void InitDoctorsTab()
        {
            DoctorNameRadioButton.Checked = true;
        }
        private void SetDoctorFilter(RDoctor.Filters selected)
        {
            DoctorNameTextBox.Enabled = selected == RDoctor.Filters.BY_NAME;
            DoctorSurnameTextBox.Enabled = selected == RDoctor.Filters.BY_SURNAME;
            DoctorSpecializationComboBox.Enabled = selected == RDoctor.Filters.BY_SPECIALIZATION;

            DoctorNameTextBox.Text = "";
            DoctorSurnameTextBox.Text = "";
            DoctorsTable.DataSource = null;

            selectedDoctorFilter = selected;
        }
        private void DoctorNameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorNameRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_NAME);
        }
        private void DoctorSurnameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorSurnameRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_SURNAME);
        }
        private void DoctorSpecializationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorSpecializationRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_SPECIALIZATION);
        }
        private void FillDoctorsTable(List<RDoctor>? doctors = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");

            if (doctors == null) return;
            foreach(RDoctor doctor in doctors)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Doctor ID"] = doctor.id;
                newRow["Name"] = doctor.name;
                newRow["Surname"] = doctor.surname;
                newRow["Specialization"] = doctor.specialization;
                newRow["Grade"] = string.Format("{0:0.00}", DoctorService.GetGrade(doctor.id));
                dataTable.Rows.Add(newRow);
            }
  
            DoctorsTable.DataSource = dataTable;
            DoctorsTable.ClearSelection();
            NewAppointmentButton.Enabled = false;
        }
        private void DoctorSearchButtonClick(object sender, EventArgs e)
        {
            List<RDoctor> result = selectedDoctorFilter switch
            {
                RDoctor.Filters.BY_NAME => DoctorService.SearchByName(DoctorNameTextBox.Text),
                RDoctor.Filters.BY_SURNAME => DoctorService.SearchBySurname(DoctorSurnameTextBox.Text),
                RDoctor.Filters.BY_SPECIALIZATION => DoctorService.SearchBySpecialization(GetSelectedSpecializationID()),
                _ => new List<RDoctor>()
            };
            FillDoctorsTable(result);
        }
        private void DoctorsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            NewAppointmentButton.Enabled = true;
        }
        private void NewAppointmentButtonClick(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.doctorID = Convert.ToInt32(UIUtilities.GetCellValue(DoctorsTable, "Doctor ID"));
            //new PersonalAppointment(this, appointment, true).Show();
        }
        #endregion

        #region Notifications Tab
        private void InitNotificationsTab()
        {
            OffsetNumericUpDown.Value = patient.notificationOffset;
            SetButton.Enabled = false;
        }
        private void FillNotificationsTable(List<Notification> notifications)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("DateTime");
            dataTable.Columns.Add("Message");

            if (notifications == null) return;
            foreach (Notification notification in notifications)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["ID"] = notification.id;
                newRow["DateTime"] = notification.dateTime;
                newRow["Message"] = notification.message;
                dataTable.Rows.Add(newRow);
            }
            NotificationsTable.DataSource = dataTable;
            NotificationsTable.ClearSelection();
            MarkAsReadButton.Enabled = false;
        }
        private void MarkAsReadButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want mark as read this notification?")) return;
            int notificationID = Convert.ToInt32(UIUtilities.GetCellValue(NotificationsTable, "ID")); 
            NotificationService.MarkAsRead(notificationID);
            NotificationsTable.Rows.RemoveAt(NotificationsTable.CurrentRow.Index);
            MarkAsReadButton.Enabled = false;
        }
        private void SetButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to save changes?")) return;
            patient.notificationOffset = Convert.ToInt32(OffsetNumericUpDown.Value);
            PatientService.Modify(patient);
            FillNotificationsTable(NotificationRepository.Get(patient));
            SetButton.Enabled = false;
        }
        private void OffsetNumericUpDownEnter(object sender, EventArgs e)
        {
            SetButton.Enabled = true;
        }
        private void NotificationsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MarkAsReadButton.Enabled = true;
        }
        #endregion

        #region Helper functions
        private void FillSpecializationsComboBox()
        {
            var specializations = SpecializationService.GetAll().ToArray();
            DoctorSpecializationComboBox.Items.AddRange(specializations);
            DoctorSpecializationComboBox.SelectedIndex = 0;
        }
        private int GetSelectedSpecializationID()
        {
            return (DoctorSpecializationComboBox.SelectedItem as Specialization).id;
        }
        public bool IsDateValid (DateTime dateTime) //2
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
        #endregion

        private void GradeDoctorButtonClick(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(UIUtilities.GetCellValue(MedicalRecordTable, "Appointment ID"));
            if (!AppointmentService.IsGraded(selected))
            {
                var appointment = AppointmentService.GetById(selected);
                new Questionnaire(this, Question.Types.DOCTOR, appointment.id, appointment.doctorID).Show();
                return;
            }
            MessageBoxUtilities.ShowErrorMessage("You already graded this appointment!");
        }
        private void ClinicQuestionnaireButtonClick(object sender, EventArgs e)
        {
            new Questionnaire(this, Question.Types.CLINIC).Show();
        }
    }
}