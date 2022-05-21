using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Forms;
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
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 1:
                    InitScheduleTab();
                    break;
                case 2:
                    InitUnapprovedDrugs();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region All Appointments
        private void InitAllAppointmentsTab()
        {
            AllAppointmentsTable.Fill(AppointmentRepository.GetAll(Doctor.ID, User.RoleType.DOCTOR));
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;
        }
        private void AllAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            EditAppointmentButton.Enabled = true;
            DeleteAppointmentButton.Enabled = true;
        }
        private void EditAppointmentButtonClick(object sender, EventArgs e)
        {
            new AppointmentDetails(this, AllAppointmentsTable.GetSelected()).Show();
        }
        private void DeleteAppointmentButtonClick(object sender, EventArgs e)
        {
            DialogResult deleteConfirmation = MessageBox.Show(
                "Are you sure you want to delete the selected appointment? This action cannot be undone.",
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (deleteConfirmation == DialogResult.No) return;

            AppointmentService.Delete(AllAppointmentsTable.DeleteSelected());
        }
        private void AddAppointmentButtonClick(object sender, EventArgs e)
        {
            new AppointmentDetails(this).Show();
        }
        #endregion

        #region Schedule
        private void InitScheduleTab()
        {
            var scheduled = AppointmentRepository.GetAll(ScheduleDatePicker.Value.ToString("yyyy-MM-dd"), Doctor.ID, User.RoleType.DOCTOR, 3);
            ScheduleTable.Fill(scheduled);
            ViewMedicalRecordButton.Enabled = false;
            PerformButton.Enabled = false;
        }
        private void ScheduleDatePickerValueChanged(object sender, EventArgs e)
        {
            InitScheduleTab();
        }
        private void ScheduleTableSelectionChanged(object sender, EventArgs e)
        {
            ViewMedicalRecordButton.Enabled = true;
            try
            {
                var selected = ScheduleTable.GetSelected();
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
            var selected = ScheduleTable.GetSelected();
            new MedicalRecord(this, selected).Show();
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var selected = ScheduleTable.GetSelected();
            new MedicalRecord(this, selected, false).Show();
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
