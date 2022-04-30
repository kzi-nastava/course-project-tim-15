using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Doctor
{
    public partial class DoctorMain : Form
    {
        public User Doctor { get; }
        private List<Appointment> Appointments
        {
            get
            {
                return AppointmentRepository.GetInstance().Appointments;
            }
        }

        #region Form
        public DoctorMain(User doctor)
        {
            InitializeComponent();
            Doctor = doctor;
        }
        private void DoctorMainLoad(object sender, EventArgs e)
        {
            // All Appointments Tab
            FillAllAppointmentsTable();
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;

            // Schedule Tab
            DataTable? scheduledAppointments = AppointmentRepository.GetAll(DateTime.Now.ToString("yyyy-MM-dd"), Doctor.ID, User.RoleType.DOCTOR, 3);
            FillTableWithData(scheduledAppointments, ScheduleTable);
            ScheduleTable.ClearSelection();
            ViewMedicalRecordButton.Enabled = false;
            PerformButton.Enabled = false;

        }
        private void DoctorMainFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Shared
        private void FillTableWithData(DataTable? data, DataGridView table)
        {
            if (data != null)
            {
                FillTableWithPatientData(data);
                FixAppointmentTypeField(data);
                data.Columns.Remove("DoctorID");
                data.Columns.Remove("PatientID");
                data.Columns.Remove("RoomID");
                //data.Columns.Remove("Completed");
                data.Columns.Remove("IsDeleted");
                data.Columns.Remove("Description");

                data.Columns["Completed"].SetOrdinal(6);

                table.DataSource = data;
                table.Columns["Duration"].HeaderText = "Duration [min]";
                table.ClearSelection();
            }
        }
        public void UpdateTableRow(Appointment appointment, DataGridView table)
        {
            DataTable? dt = table.DataSource as DataTable;
            table.SelectedRows[0].SetValues(appointment.ID.ToString(),
                GetPatientFullName(appointment.PatientID),
                appointment.DateTime.ToString(),
                GetTypeFullName(appointment.Type),
                appointment.Duration.ToString(),
                appointment.Urgent,
                appointment.Completed);
        }
        #endregion

        #region All Appointments
        public void FillAllAppointmentsTable()
        {
            DataTable? allAppointments = AppointmentRepository.GetAll(Doctor.ID, User.RoleType.DOCTOR);
            FillTableWithData(allAppointments, AllAppointmentsTable);
        }
        public void InsertIntoAppointmentsTable(Appointment appointment)
        {
            DataTable? dt = AllAppointmentsTable.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dataRow[0] = appointment.ID.ToString();
            dataRow[1] = GetPatientFullName(appointment.PatientID);
            dataRow[2] = appointment.DateTime.ToString();
            dataRow[3] = GetTypeFullName(appointment.Type);
            dataRow[4] = appointment.Duration.ToString();
            dataRow[5] = appointment.Urgent;
            dt.Rows.Add(dataRow);
        }
        private void FixAppointmentTypeField(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Type"] = GetTypeFullName(Convert.ToChar(row["Type"]));
            }
        }
        private string GetTypeFullName(char type)
        {
            switch (type)
            {
                case 'O':
                    return "Operation";
                default:
                    return "Examination";
            }
        }
        private void FillTableWithPatientData(DataTable dt)
        {
            dt.Columns.Add("Patient Full Name");
            dt.Columns["Patient Full Name"].SetOrdinal(1);
            foreach (DataRow row in dt.Rows)
            {
                row["Patient Full Name"] = GetPatientFullName(Convert.ToInt32(row["PatientID"]));
            }
        }
        public string GetPatientFullName(int ID)
        {
            var patient = UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
            return $"{patient.Name} {patient.Surname}";
        }
        private void AllAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            EditAppointmentButton.Enabled = true;
            DeleteAppointmentButton.Enabled = true;
        }
        private void AddAppointmentButtonClick(object sender, EventArgs e)
        {
            new AppointmentDetails(this).Show();
        }
        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete the selected appointment? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deleteConfirmation == DialogResult.Yes)
            {
                int toDeleteID = Convert.ToInt32(AllAppointmentsTable.SelectedRows[0].Cells["ID"].Value);
                AppointmentRepository.GetInstance().Delete(toDeleteID);
                AllAppointmentsTable.Rows.RemoveAt(AllAppointmentsTable.CurrentRow.Index);
            }
        }
        private void EditAppointmentButtonClick(object sender, EventArgs e)
        {
            int toEditID = Convert.ToInt32(AllAppointmentsTable.SelectedRows[0].Cells["ID"].Value);
            var toEdit = Appointments.Where(x => x.ID == toEditID).FirstOrDefault();
            new AppointmentDetails(this, toEdit).Show();
        }
        #endregion

        #region Schedule
        private void ScheduleDatePickerValueChanged(object sender, EventArgs e)
        {
            var date = ScheduleDatePicker.Value.ToString("yyyy-MM-dd");
            DataTable? scheduledAppointments = AppointmentRepository.GetAll(date, Doctor.ID, User.RoleType.DOCTOR, 3);
            FillTableWithData(scheduledAppointments, ScheduleTable);
            ScheduleTable.ClearSelection();
            PerformButton.Enabled = false;
        }
        private void ScheduleTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ViewMedicalRecordButton.Enabled = true;
            PerformButton.Enabled = true;
        }
        private void ViewMedicalRecordButtonClick(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(ScheduleTable.SelectedRows[0].Cells["ID"].Value);
            Appointment appointment = Appointments.Where(x => x.ID == appointmentID).FirstOrDefault();
            int patientID = Appointments.Where(x => x.ID == appointmentID).FirstOrDefault().PatientID;
            new MedicalRecord(this, appointment).Show();
        }
        #endregion

        #region Preforme
        private void PreformButtonClick(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(ScheduleTable.SelectedRows[0].Cells["ID"].Value);
            Appointment appointment = Appointments.Where(x => x.ID == appointmentID).FirstOrDefault();
            if(appointment.Type == 'O')
            {
                MessageBox.Show("This feature will be implemented soon", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (appointment.Completed)
            {
                MessageBox.Show("This Appointment is already completed!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int patientID = Appointments.Where(x => x.ID == appointmentID).FirstOrDefault().PatientID;
            new MedicalRecord(this, appointment, false).Show();
        }
        #endregion

        private void ScheduleTableSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int appointmentID = Convert.ToInt32(ScheduleTable.SelectedRows[0].Cells["ID"].Value);
                Appointment appointment = Appointments.Where(x => x.ID == appointmentID).FirstOrDefault();
                if (!appointment.Completed && appointment.Type == 'E' && appointment.DateTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    PerformButton.Enabled = true;
                    return;
                }
            }
            catch { }
            PerformButton.Enabled = false;
        }
    }
}
