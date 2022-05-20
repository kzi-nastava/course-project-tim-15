using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
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

        #region Form
        public DoctorMain(User doctor)
        {
            InitializeComponent();
            Doctor = doctor;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            InitAllAppointmentsTab();
            InitScheduleTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private static void FillAppointmentsTableWithData(DataTable? data, DataGridView table)
        {
            if (data != null)
            {
                FillTableWithPatientData(data);
                DoctorService.FillAppointmentTypeField(data);
                data.Columns.Remove("DoctorID");
                data.Columns.Remove("PatientID");
                data.Columns.Remove("RoomID");
                data.Columns.Remove("IsDeleted");
                data.Columns.Remove("Description");

                data.Columns["Completed"].SetOrdinal(6);

                table.DataSource = data;
                table.Columns["Duration"].HeaderText = "Duration [min]";

                table.ClearSelection();
            }
        }
        private static void FillTableWithPatientData(DataTable dt)
        {
            dt.Columns.Add("Patient Full Name");
            dt.Columns["Patient Full Name"].SetOrdinal(1);
            foreach (DataRow row in dt.Rows)
            {
                row["Patient Full Name"] = PatientService.GetFullName(Convert.ToInt32(row["PatientID"]));
            }
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 2:
                    InitUnapprovedDrugs();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region All Appointments
        private static int GetSelectedAppointmentID(DataGridView table)
        {
            return Convert.ToInt32(table.SelectedRows[0].Cells["ID"].Value);
        }
        private static Appointment GetSelectedAppointment(DataGridView table)
        {
            int appointmentID = GetSelectedAppointmentID(table);
            return AppointmentRepository.GetInstance().Appointments.Where(x => x.ID == appointmentID).FirstOrDefault();
        }
        private void InitAllAppointmentsTab()
        {
            FillAllAppointmentsTable();
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;
        }
        private void FillAllAppointmentsTable()
        {
            DataTable? allAppointments = AppointmentRepository.GetAllAsTable(Doctor.ID, User.RoleType.DOCTOR);
            FillAppointmentsTableWithData(allAppointments, AllAppointmentsTable);
        }
        private static void DeleteAppointmet(DataGridView table)
        {
            int id = GetSelectedAppointmentID(table);
            AppointmentService.Delete(id);
            table.Rows.RemoveAt(table.CurrentRow.Index);
        }
        public void InsertIntoAllAppointmentsTable(Appointment appointment)
        {
            DataTable? dt = AllAppointmentsTable.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dataRow[0] = appointment.ID.ToString();
            dataRow[1] = PatientService.GetFullName(appointment.PatientID);
            dataRow[2] = appointment.DateTime.ToString();
            dataRow[3] = appointment.GetType();
            dataRow[4] = appointment.Duration.ToString();
            dataRow[5] = appointment.Urgent;
            dt.Rows.Add(dataRow);
        }
        private void AllAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            EditAppointmentButton.Enabled = true;
            DeleteAppointmentButton.Enabled = true;
        }
        private void EditAppointmentButtonClick(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment(AllAppointmentsTable);
            new AppointmentDetails(this, selected).Show();
        }
        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            DialogResult deleteConfirmation = MessageBox.Show(
                "Are you sure you want to delete the selected appointment? This action cannot be undone.",
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (deleteConfirmation == DialogResult.Yes)
            {
                DeleteAppointmet(AllAppointmentsTable);
            }
        }
        private void AddAppointmentButtonClick(object sender, EventArgs e)
        {
            new AppointmentDetails(this).Show();
        }
        #endregion

        #region Schedule
        private void InitScheduleTab()
        {
            FillScheduledAppointmentsTable(DateTime.Now.ToString("yyyy-MM-dd"));
            ViewMedicalRecordButton.Enabled = false;
            PerformButton.Enabled = false;
        }
        private void FillScheduledAppointmentsTable(string date)
        {
            DataTable? scheduledAppointments = AppointmentRepository.GetAllAsTable(date, Doctor.ID, User.RoleType.DOCTOR, 3);
            FillAppointmentsTableWithData(scheduledAppointments, ScheduleTable);
        }
        private void ScheduleDatePickerValueChanged(object sender, EventArgs e)
        {
            var date = ScheduleDatePicker.Value.ToString("yyyy-MM-dd");
            FillScheduledAppointmentsTable(date);
            PerformButton.Enabled = false;
        }
        private void ScheduleTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ViewMedicalRecordButton.Enabled = true;
        }
        private void ScheduleTableSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = GetSelectedAppointment(ScheduleTable);
                bool canBePerformed = !selected.Completed
                    && selected.Type == 'E'
                    && selected.DateTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd");

                if (canBePerformed)
                {
                    PerformButton.Enabled = true;
                    return;
                }
            }
            catch { }
            PerformButton.Enabled = false;
        }
        private void ViewMedicalRecordButtonClick(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment(ScheduleTable);
            if (selected != null)
            {
                new MedicalRecord(this, selected).Show();
            }
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment(ScheduleTable);
            if (selected != null)
            {
                new MedicalRecord(this, selected, false).Show();
            }
        }
        #endregion

        #region Unapproved Drugs
        private void InitUnapprovedDrugs()
        {
            UnapprovedDrugsTable.Fill(DrugRepository.Instance.GetUnapproved());
            ApproveDrugButton.Enabled = false;
            DenyDrugButton.Enabled = false;
            DenydDrugDescription.Text = "";
        }
        private void UnapprovedDrugsTableSelectionChanged(object sender, EventArgs e)
        {
            ApproveDrugButton.Enabled = true;
            DenydDrugDescription.Text = "";
        }
        private void DenyDrugDescriptionTextChanged(object sender, EventArgs e)
        {
            DenyDrugButton.Enabled = DenydDrugDescription.Text != "" && ApproveDrugButton.Enabled;
        }
        private void ApproveDrugButtonClick(object sender, EventArgs e)
        {
            var msgBox = MessageBox.Show("Are you sure you want to approve this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugService.ApproveDrug(UnapprovedDrugsTable.GetSelectedId());
            InitUnapprovedDrugs();
        }
        private void DenyDrugButtonClick(object sender, EventArgs e)
        {
            var msgBox = MessageBox.Show("Are you sure you want to deny this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugService.DenyDrug(UnapprovedDrugsTable.GetSelectedId(), DenydDrugDescription.Text);
            InitUnapprovedDrugs();
        }
        #endregion

    }
}
