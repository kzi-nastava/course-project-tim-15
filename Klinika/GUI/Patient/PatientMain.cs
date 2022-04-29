﻿using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System.Data;

namespace Klinika.GUI.Patient
{
    public partial class PatientMain : Form
    {
        public User Patient { get; }
        private List<Appointment> Appointments
        {
            get
            {
                return AppointmentRepository.GetInstance().Appointments;
            }
        }
        public PatientMain(User patient)
        {
            InitializeComponent();
            Patient = patient;
        }

        #region Loads and closing
        private void PatientMainLoad(object sender, EventArgs e)
        {
            FillPersonalAppointmentTable();
            FillDoctorComboBox(DoctorComboBox);
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
        }
        private void PatientMainFormClosing(object sender, FormClosingEventArgs e)
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
                FillAppointmentTypeName(allAppointments);

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
            dataRow[1] = GetDoctorFullName(appointment.DoctorID);
            dataRow[2] = appointment.DateTime;
            dataRow[3] = GetAppointmentTypeName(appointment.Type.ToString());
            dataRow[4] = appointment.Duration.ToString();
            dataRow[5] = appointment.Urgent;
            dataTable.Rows.Add(dataRow);
        }
        public void ModifyPersonalAppointmentTableRow(Appointment appointment)
        {
            DataTable? dt = PersonalAppointmentsTable.DataSource as DataTable;
            PersonalAppointmentsTable.SelectedRows[0].SetValues(appointment.ID.ToString(),
                GetDoctorFullName(appointment.DoctorID),
                appointment.DateTime,
                GetAppointmentTypeName(appointment.Type.ToString()),
                appointment.Duration.ToString(),
                appointment.Urgent);
        }
        private void PersonalAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
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
                FillAppointmentTypeName(appointmets);

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
            dataRow[1] = GetDoctorFullName(appointment.DoctorID);
            dataRow[2] = appointment.DoctorID.ToString();
            dataRow[3] = appointment.DateTime;
            dataRow[4] = appointment.Duration.ToString();
            dataTable.Rows.Add(dataRow);
        }
        #endregion

        #region Click functions
        private void ModifyButtonClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(PersonalAppointmentsTable.SelectedRows[0].Cells["ID"].Value);
            Appointment? toModify = GetAppointment(ID);
            new PersonalAppointment(this, toModify).Show();
        }
        private void DeleteAppointmentClick(object sender, EventArgs e)
        {
            DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete selected appointment?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteConfirmation == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(PersonalAppointmentsTable.SelectedRows[0].Cells["ID"].Value);
                Appointment? toDelete = GetAppointment(ID);

                if (DateTime.Now.AddDays(2).Date >= toDelete.DateTime.Date)
                {
                    DialogResult sendRequest = MessageBox.Show("Changes that you have requested have to be check by secretary. " +
                    "Do you want to send request? ", "Send Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (sendRequest == DialogResult.Yes)
                    {
                        PatientRequest patientRequest = new PatientRequest(-1, toDelete.PatientID, toDelete.ID, 'D', "", false);
                        PatientRequestRepository.Create(patientRequest);
                    }
                }
                else
                {
                    AppointmentRepository.GetInstance().Delete(toDelete.ID);

                    PatientRequest patientRequest = new PatientRequest(-1, toDelete.PatientID, toDelete.ID, 'D', "", true);
                    PatientRequestRepository.Create(patientRequest);

                    PersonalAppointmentsTable.Rows.RemoveAt(PersonalAppointmentsTable.SelectedRows[0].Index);
                }
            }
        }
        private void FindAppointmentsButtonClick(object sender, EventArgs e)
        {
            if (IsDateValid(AppointmentDatePicker.Value))
            {
                FillOccupiedAppointmentsTable();
            }
        }
        private void ScheduleButtonClick(object sender, EventArgs e)
        {
            new PersonalAppointment(this, null).Show();
        }
        #endregion

        #region Helper functions
        private void FillAppointmentTypeName(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                row["Type"] = GetAppointmentTypeName(row["Type"].ToString());
            }
        }
        private void FillTableWithDoctorData(DataTable dataTable)
        {
            dataTable.Columns.Add("Doctor Name");
            dataTable.Columns["Doctor Name"].SetOrdinal(1);
            foreach (DataRow row in dataTable.Rows)
            {
                row["Doctor Name"] = GetDoctorFullName(Convert.ToInt32(row["DoctorID"]));
            }
        }
        private string GetAppointmentTypeName(string type)
        {
            if (type == "E")
            {
                return "Examination";
            }
            else
            {
                return "Operation";
            }
        }
        private string GetDoctorFullName(int doctorID)
        {
            var doctor = GetDoctor(doctorID);
            return doctor.Name + " " + doctor.Surname;
        }
        private User? GetDoctor(int ID)
        {
            return UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
        }
        private Appointment? GetAppointment(int ID)
        {
            return Appointments.Where(x => x.ID == ID).FirstOrDefault();
        }
        public void FillDoctorComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(GetDoctors());
            comboBox.SelectedIndex = 0;
        }
        private User[] GetDoctors()
        {
            return UserRepository.GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.DOCTOR.ToString()).ToArray();
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1)
            {
                ScheduleButton.Enabled = false;
                OccupiedAppointmentsTable.DataSource = new DataTable();
            }
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
        #endregion
    }
}
