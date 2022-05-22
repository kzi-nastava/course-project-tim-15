using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using System.Data;

namespace Klinika.GUI.Patient
{
    public partial class PatientMain : Form
    {
        public User Patient { get; }

        #region Form
        public PatientMain(User patient)
        {
            InitializeComponent();
            Patient = patient;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            InitPersonalAppointmentsTab();
            FillDoctorComboBox(DoctorComboBox);
            FillSpecializationsComboBox();
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1) InitNewAppointmentTab();
            if ((sender as TabControl).SelectedIndex == 2) InitMedicalRecorTab();
            if ((sender as TabControl).SelectedIndex == 3) InitDoctorsTab();
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
            if (!IsDeleteConfirmed()) return;

            Appointment selected = PersonalAppointmentsTable.GetSelected();
            bool needApproval = DateTime.Now.AddDays(2).Date >= selected.DateTime.Date;

            if (needApproval)
            {
                DialogResult sendRequest = MessageBox.Show("Changes that you have requested have to be check by secretary. " +
                "Do you want to send request? ", "Send Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sendRequest == DialogResult.Yes)
                {
                    PatientRequestService.SendDeleted(!needApproval, selected);
                }
                return;
            }

            AppointmentRepository.Delete(selected.ID);
            AppointmentRepository.GetInstance().DeleteFromList(selected.ID);
            PatientRequestService.SendDeleted(!needApproval, selected);
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
            var occupied = AppointmentRepository.GetAll(AppointmentDatePicker.Value.ToString("yyyy-MM-dd"), doctorID, User.RoleType.DOCTOR);
            OccupiedAppointmentsTable.Fill(occupied);
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
            List<Anamnesis> anamneses = MedicalRecordRepository.GetAnamneses(Patient.ID);
            FillMedicalRecordTable(anamneses);
        }
        private void FillMedicalRecordTable(List<Anamnesis> anamneses)
        {

            List<Appointment> appointments = AppointmentRepository.GetCompleted(Patient.ID);

            DataTable anamnesesData = new DataTable();
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

                newRow["Doctor"] = DoctorService.GetFullName(appointment.DoctorID);
                newRow["Doctor Specialization"] = DoctorRepository.getSpecialization(appointment.DoctorID);
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
            List<Anamnesis> searchResoult = MedicalRecordService.GetFiltered(Patient.ID, searchParam);

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
            DoctorSurnameTextBox.Enabled = false;
            DoctorSpecializationComboBox.Enabled = false;
            NewAppointmentButton.Enabled = false;
        }
        private void DoctorNameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if(DoctorNameRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = true;
                DoctorSurnameTextBox.Enabled = false;
                DoctorSpecializationComboBox.Enabled = false;

                DoctorSurnameTextBox.Text = "";
                FillDoctorsTable();
            }
        }
        private void DoctorSurnameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (DoctorSurnameRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = false;
                DoctorSurnameTextBox.Enabled = true;
                DoctorSpecializationComboBox.Enabled = false;

                DoctorNameTextBox.Text = "";
                FillDoctorsTable();
            }
        }
        private void DoctorSpecializationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (DoctorSpecializationRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = false;
                DoctorSurnameTextBox.Enabled = false;
                DoctorSpecializationComboBox.Enabled = true;

                DoctorSurnameTextBox.Text = "";
                DoctorNameTextBox.Text = "";
                FillDoctorsTable();
            }
        }
        private void FillDoctorsTable(List<Roles.Doctor> doctors = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");

            if(doctors != null)
            {
                foreach(Roles.Doctor doctor in doctors)
                {
                    DataRow newRow = dataTable.NewRow();

                    newRow["Doctor ID"] = doctor.ID;
                    newRow["Name"] = doctor.Name;
                    newRow["Surname"] = doctor.Surname;
                    newRow["Specialization"] = doctor.specialization;
                    newRow["Grade"] = QuestionnaireRepository.GetGrade(doctor.ID);
                    dataTable.Rows.Add(newRow);
                }
            }
            DoctorsTable.DataSource = dataTable;
            DoctorsTable.ClearSelection();
            NewAppointmentButton.Enabled = false;
        }
        private void DoctorSearchButtonClick(object sender, EventArgs e)
        {
            if (DoctorNameRadioButton.Checked)
            {
                var resoult = DoctorService.SearchByName(DoctorNameTextBox.Text);
                FillDoctorsTable(resoult);
                return;
            }
            if (DoctorSurnameRadioButton.Checked)
            {
                var resoult = DoctorService.SearchBySurname(DoctorSurnameTextBox.Text);
                FillDoctorsTable(resoult);
                return;
            }
            var resout = DoctorService.SearchBySpecialization(GetSelectedSpecializationID());
            FillDoctorsTable(resout);
        }
        private void DoctorsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            NewAppointmentButton.Enabled = true;
        }
        private void NewAppointmentButtonClick(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.DoctorID = GetSelectedDoctorID(DoctorsTable);
            new PersonalAppointment(this, appointment, true).Show();
        }
        #endregion

        #region Helper functions
        public void FillDoctorComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(UserRepository.GetDoctors().ToArray());
            comboBox.SelectedIndex = 0;
        }
        private void FillSpecializationsComboBox()
        {
            var specializations = DoctorRepository.GetSpecializations().ToArray();
            DoctorSpecializationComboBox.Items.AddRange(specializations);
            DoctorSpecializationComboBox.SelectedIndex = 0;
        }
        private int GetSelectedDoctorID(DataGridView table)
        {
            return Convert.ToInt32(table.SelectedRows[0].Cells["Doctor ID"].Value);
        }
        private int GetSelectedSpecializationID()
        {
            return (DoctorSpecializationComboBox.SelectedItem as Specialization).ID;
        }
        public bool IsDateValid (DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                MessageBox.Show("Date is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool IsDeleteConfirmed()
        {
            DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete selected appointment?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteConfirmation == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
