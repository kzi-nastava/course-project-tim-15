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
        RDoctor.Filters SelectedDoctorFilter = RDoctor.Filters.BY_NAME;
        public RPatient Patient { get; }

        #region Form
        public PatientMain(int patientID)
        {
            InitializeComponent();
            Patient = PatientService.GetById(patientID);
            System.Diagnostics.Debug.WriteLine(Patient.NotificationOffset);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            InitPersonalAppointmentsTab();
            FillNotificationsTable(NotificationService.Get(Patient));
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
            PersonalAppointmentsTable.Fill(AppointmentRepository.GetAll(Patient.ID, User.RoleType.PATIENT));
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
            new PersonalAppointment(this, PersonalAppointmentsTable.GetSelected()).Show();
        }
        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to delete selected appointment?")) return;

            Appointment selected = PersonalAppointmentsTable.GetSelected();
            bool needApproval = DateTime.Now.AddDays(2).Date >= selected.DateTime.Date;

            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            PatientRequestService.Send(!needApproval, selected, PatientRequest.Types.Delete);
            if (needApproval) return;

            AppointmentService.Delete(selected.ID);
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

            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            OccupiedAppointmentsTable.Fill(DoctorService.GetAppointments(AppointmentDatePicker.Value, doctorID));
            ScheduleButton.Enabled = true;
        }
        private void ScheduleAppointmentButtonClick(object sender, EventArgs e)
        {
            new PersonalAppointment(this, null).Show();
        }
        private void RecommendButtonClick(object sender, EventArgs e)
        {
            new AppointmentRecommendation(this).Show();
        }
        #endregion

        #region Medical Record Tab
        private void InitMedicalRecorTab()
        {
            FillMedicalRecordTable(AnamnesisService.Get(Patient.ID));
        }
        private void FillMedicalRecordTable(List<Anamnesis> anamneses)
        {
            List<Appointment> appointments = AppointmentService.GetCompleted(Patient.ID);

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
                Appointment appointment = appointments.Where(x => x.ID == anamnesis.MedicalActionID).FirstOrDefault();
                newRow["Appointment ID"] = anamnesis.MedicalActionID;
                newRow["Doctor"] = DoctorService.GetFullName(appointment.DoctorID);
                newRow["Doctor Specialization"] = DoctorService.GetSpecialization(appointment.DoctorID);
                newRow["DateTime"] = appointment.DateTime;
                newRow["Description"] = anamnesis.Description;
                newRow["Symptoms"] = anamnesis.Symptoms;
                newRow["Conclusion"] = anamnesis.Conclusion;
                anamnesesData.Rows.Add(newRow);
            }
            MedicalRecordTable.DataSource = anamnesesData;
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            string searchParam = SearchTextBox.Text;
            List<Anamnesis> searchResoult = AnamnesisService.GetFiltered(Patient.ID, searchParam);
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

            SelectedDoctorFilter = selected;
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
                newRow["Doctor ID"] = doctor.ID;
                newRow["Name"] = doctor.Name;
                newRow["Surname"] = doctor.Surname;
                newRow["Specialization"] = doctor.specialization;
                newRow["Grade"] = DoctorService.GetGrade(doctor.ID);
                dataTable.Rows.Add(newRow);
            }
  
            DoctorsTable.DataSource = dataTable;
            DoctorsTable.ClearSelection();
            NewAppointmentButton.Enabled = false;
        }
        private void DoctorSearchButtonClick(object sender, EventArgs e)
        {
            List<RDoctor> result = SelectedDoctorFilter switch
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
            appointment.DoctorID = Convert.ToInt32(UIUtilities.GetCellValue(DoctorsTable, "Doctor ID"));
            new PersonalAppointment(this, appointment, true).Show();
        }
        #endregion

        #region Notifications Tab
        private void InitNotificationsTab()
        {
            OffsetNumericUpDown.Value = Patient.NotificationOffset;
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

                newRow["ID"] = notification.ID;
                newRow["DateTime"] = notification.DateTime;
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
            Patient.NotificationOffset = Convert.ToInt32(OffsetNumericUpDown.Value);
            PatientService.Modify(Patient);
            FillNotificationsTable(NotificationRepository.Get(Patient));
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
            return (DoctorSpecializationComboBox.SelectedItem as Specialization).ID;
        }
        public bool IsDateValid (DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
        #endregion

        private void SendGradeButton_Click(object sender, EventArgs e)
        {
            new Questionnaire(this).Show();
        }
    }
}