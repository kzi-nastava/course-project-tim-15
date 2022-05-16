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
        private void InitAllAppointmentsTab()
        {
            DataTable? allAppointments = AppointmentRepository.GetAll(Doctor.ID, User.RoleType.DOCTOR);
            DoctorService.FillAppointmentsTableWithData(allAppointments, AllAppointmentsTable);
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;
        }
        private void InitScheduleTab()
        {
            FillScheduledAppointmentsTable(DateTime.Now.ToString("yyyy-MM-dd"));
            ViewMedicalRecordButton.Enabled = false;
            PerformButton.Enabled = false;
        }
        private void FillScheduledAppointmentsTable(string date)
        {
            DataTable? scheduledAppointments = AppointmentRepository.GetAll(date, Doctor.ID, User.RoleType.DOCTOR, 3);
            DoctorService.FillAppointmentsTableWithData(scheduledAppointments, ScheduleTable);
        }
        #endregion

        #region All Appointments
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
            var selected = AppointmentService.GetSelected(AllAppointmentsTable);
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
                DoctorService.DeleteAppointmet(AllAppointmentsTable);
            }
        }
        private void AddAppointmentButtonClick(object sender, EventArgs e)
        {
            new AppointmentDetails(this).Show();
        }
        #endregion

        #region Schedule
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
                var selected = AppointmentService.GetSelected(ScheduleTable);
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
            var selected = AppointmentService.GetSelected(ScheduleTable);
            if (selected != null)
            {
                new MedicalRecord(this, selected).Show();
            }
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var selected = AppointmentService.GetSelected(ScheduleTable);
            if (selected != null)
            {
                new MedicalRecord(this, selected, false).Show();
            }
        }
        #endregion

        #region Unapproved Drugs
        private void InitUnapprovedDrugs()
        {
            DrugService.FillTable(UnapprovedDrugsTable, true);
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
            if (DenydDrugDescription.Text != "" && ApproveDrugButton.Enabled)
            {
                DenyDrugButton.Enabled = true;
                return;
            }
            DenyDrugButton.Enabled = false;
        }
        private void ApproveDrugButtonClick(object sender, EventArgs e)
        {
            var selected = DrugService.GetSelected(UnapprovedDrugsTable);
            DrugService.ApproveDrug(selected.ID);
            InitUnapprovedDrugs();
        }
        private void DenyDrugButtonClick(object sender, EventArgs e)
        {
            var selected = DrugService.GetSelected(UnapprovedDrugsTable);
            DrugService.DenyDrug(selected.ID, DenydDrugDescription.Text);
            InitUnapprovedDrugs();
        }
        #endregion

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

    }
}
