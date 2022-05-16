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
            FillPersonalAppointmentTable();
            FillDoctorComboBox(DoctorComboBox);
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1)
            {
                ScheduleButton.Enabled = false;
                OccupiedAppointmentsTable.DataSource = new DataTable();
                return;
            }

            if ((sender as TabControl).SelectedIndex == 2) FillMedicalRecorTab();
            if ((sender as TabControl).SelectedIndex == 3) InitDoctorsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Personal Appointments Table
        private void FillPersonalAppointmentTable()
        {
            DataTable? allAppointments = AppointmentRepository.GetAll(Patient.ID, User.RoleType.PATIENT);
            if (allAppointments != null)
            {
                FillTableWithDoctorData(allAppointments);
                DoctorService.FillAppointmentTypeField(allAppointments);

                allAppointments.Columns.Remove("DoctorID");
                allAppointments.Columns.Remove("RoomID");
                allAppointments.Columns.Remove("PatientID");
                allAppointments.Columns.Remove("Completed");
                allAppointments.Columns.Remove("IsDeleted");
                allAppointments.Columns.Remove("Description");

                PersonalAppointmentsTable.DataSource = allAppointments;

                PersonalAppointmentsTable.Columns["ID"].Width = 45;
                PersonalAppointmentsTable.Columns["DateTime"].MinimumWidth = 150;

                PersonalAppointmentsTable.ClearSelection();
            }
        }
        public void InsertRowIntoPersonalAppointmentsTable(Appointment appointment)
        {
            DataTable? dataTable = PersonalAppointmentsTable.DataSource as DataTable;
            DataRow dataRow = dataTable.NewRow();
            dataRow[0] = appointment.ID.ToString();
            dataRow[1] = DoctorService.GetFullName(appointment.DoctorID);
            dataRow[2] = appointment.DateTime;
            dataRow[3] = appointment.GetType();
            dataRow[4] = appointment.Duration.ToString();
            dataRow[5] = appointment.Urgent;
            dataTable.Rows.Add(dataRow);
        }
        public void ModifyPersonalAppointmentTableRow(Appointment appointment)
        {
            PersonalAppointmentsTable.SelectedRows[0].SetValues(appointment.ID.ToString(),
                DoctorService.GetFullName(appointment.DoctorID),
                appointment.DateTime,
                appointment.GetType(),
                appointment.Duration.ToString(),
                appointment.Urgent);
        }
        private void PersonalAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }
        private void ModifyAppointmentClick(object sender, EventArgs e)
        {
            Appointment selected = AppointmentService.GetSelected(PersonalAppointmentsTable);
            new PersonalAppointment(this, selected).Show();
        }
        private void DeleteAppointmentClick(object sender, EventArgs e)
        {
            if (!IsDeleteConfirmed()) return;

            Appointment selected = AppointmentService.GetSelected(PersonalAppointmentsTable);
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
            PersonalAppointmentsTable.Rows.RemoveAt(PersonalAppointmentsTable.SelectedRows[0].Index);
        }
        #endregion

        #region Occupied Appointment table
        private void FillOccupiedAppointmentsTable()
        {
            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            DataTable? appointmets = AppointmentRepository.GetAll(AppointmentDatePicker.Value.ToString("yyyy-MM-dd"), doctorID, User.RoleType.DOCTOR);

            if (appointmets != null)
            {

                FillTableWithDoctorData(appointmets);
                DoctorService.FillAppointmentTypeField(appointmets);

                appointmets.Columns.Remove("PatientID");
                appointmets.Columns.Remove("Completed");
                appointmets.Columns.Remove("IsDeleted");
                appointmets.Columns.Remove("Description");
                appointmets.Columns.Remove("Type");
                appointmets.Columns.Remove("Urgent");
                appointmets.Columns.Remove("RoomID");

                OccupiedAppointmentsTable.DataSource = appointmets;

                OccupiedAppointmentsTable.Columns["ID"].Width = 45;
                OccupiedAppointmentsTable.Columns["DateTime"].MinimumWidth = 150;

                OccupiedAppointmentsTable.ClearSelection();

                ScheduleButton.Enabled = true;
            }
        }
        public void InsertRowIntoOccupiedTable(Appointment appointment)
        {
            DataTable? dataTable = OccupiedAppointmentsTable.DataSource as DataTable;
            DataRow dataRow = dataTable.NewRow();
            dataRow[0] = appointment.ID.ToString();
            dataRow[1] = DoctorService.GetFullName(appointment.DoctorID);
            dataRow[2] = appointment.DoctorID.ToString();
            dataRow[3] = appointment.DateTime;
            dataRow[4] = appointment.Duration.ToString();
            dataTable.Rows.Add(dataRow);
        }
        private void FindAppointmentsClick(object sender, EventArgs e)
        {
            if (!IsDateValid(AppointmentDatePicker.Value)) return;
            FillOccupiedAppointmentsTable();
        }
        private void ScheduleAppointmentClick(object sender, EventArgs e)
        {
            new PersonalAppointment(this, null).Show();
        }
        private void RecommendClick(object sender, EventArgs e)
        {
            new AppointmentRecommendation(this).Show();
        }
        #endregion

        #region Medical Record
        private void FillMedicalRecorTab()
        {
            List<Anamnesis> anamneses = MedicalRecordRepository.GetAnamneses(Patient.ID);
            FillMedicalRecordTable(anamneses);
        }
        private void FillMedicalRecordTable(List<Anamnesis> anamneses)
        {

            List<Appointment> appointments = AppointmentRepository.GetInstance().GetCompleted(Patient.ID);

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
        private void SearchClick(object sender, EventArgs e)
        {
            string searchParam = SearchTextBox.Text.ToUpper();

            List<Anamnesis> searchResoult = MedicalRecordRepository.GetAnamneses(Patient.ID).Where(
                x => x.Description.ToUpper().Contains(searchParam) 
                || x.Symptoms.ToUpper().Contains(searchParam) 
                || x.Conclusion.ToUpper().Contains(searchParam)).ToList();

            FillMedicalRecordTable(searchResoult);
        }
        private void ResetClick(object sender, EventArgs e)
        {
            FillMedicalRecorTab();
            SearchTextBox.Text = "";
        }
        #endregion

        #region Doctors
        private void InitDoctorsTab()
        {
            List<Roles.Doctor> doctors = DoctorRepository.GetInstance().doctors;
            FillDoctorTable(doctors);

            DoctorNameRadioButton.Checked = true;
            DoctorSurnameTextBox.Enabled = false;
            DoctorSpecializationComboBox.Enabled = false;
            button1.Enabled = false;
        }
        private void DoctorNameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if(DoctorNameRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = true;
                DoctorSurnameTextBox.Enabled = false;
                DoctorSpecializationComboBox.Enabled = false;
            }
        }
        private void DoctorSurnameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (DoctorSurnameRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = false;
                DoctorSurnameTextBox.Enabled = true;
                DoctorSpecializationComboBox.Enabled = false;
            }
        }
        private void DoctorSpecializationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (DoctorSpecializationRadioButton.Checked)
            {
                DoctorNameTextBox.Enabled = false;
                DoctorSurnameTextBox.Enabled = false;
                DoctorSpecializationComboBox.Enabled = true;
            }
        }
        private void FillDoctorTable(List<Roles.Doctor> doctors)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");

            if(doctors.Count() != 0)
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
            DoctorTable.DataSource = dataTable;
        }

        #endregion

        #region Helper functions
        private void FillTableWithDoctorData(DataTable dataTable)
        {
            dataTable.Columns.Add("Doctor Full Name");
            dataTable.Columns["Doctor Full Name"].SetOrdinal(1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["Doctor Full Name"] = DoctorService.GetFullName(Convert.ToInt32(row["DoctorID"]));
            }
        }
        public void FillDoctorComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(UserRepository.GetDoctors().ToArray());
            comboBox.SelectedIndex = 0;
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
