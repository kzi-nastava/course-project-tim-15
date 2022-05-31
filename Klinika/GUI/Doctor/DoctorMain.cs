using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class DoctorMain : Form
    {
        public Roles.Doctor _Doctor { get; }

        #region Form
        public DoctorMain(int doctorID)
        {
            InitializeComponent();
            _Doctor = DoctorService.GetById(doctorID);
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
            if (MainTabControl.SelectedIndex == 1) InitScheduleTab();
            if (MainTabControl.SelectedIndex == 2) InitUnapprovedDrugs();
            if (MainTabControl.SelectedIndex == 3) InitVacationRequests();
        }
        #endregion

        #region All Appointments
        private void InitAllAppointmentsTab()
        {
            AllAppointmentsTable.Fill(DoctorService.GetAppointments(_Doctor.ID));
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
            if (!UIUtilities.Confirm("Are you sure you want to delete the selected appointment? This action cannot be undone.")) return;
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
            var scheduled = DoctorService.GetAppointments(ScheduleDatePicker.Value, _Doctor.ID, 3);
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
            new MedicalRecord(this, ScheduleTable.GetSelected()).Show();
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var selected = ScheduleTable.GetSelected();
            if (selected.IsExamination()) new MedicalRecord(this, selected, false).Show();
            else new DynamicEquipment(this, selected).Show();
        }
        #endregion

        #region Unapproved Drugs
        private void InitUnapprovedDrugs()
        {
            UnapprovedDrugsTable.Fill(DrugService.GetUnapproved());
            ApproveDrugButton.Enabled = false;
            DenyDrugButton.Enabled = false;
            DenyDrugDescription.Text = "";
        }
        private void UnapprovedDrugsTableSelectionChanged(object sender, EventArgs e)
        {
            ApproveDrugButton.Enabled = true;
            DenyDrugDescription.Text = "";
        }
        private void DenyDrugDescriptionTextChanged(object sender, EventArgs e)
        {
            DenyDrugButton.Enabled = DenyDrugDescription.Text != "" && ApproveDrugButton.Enabled;
        }
        private void ApproveDrugButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to approve this drug?")) return;
            DrugService.ApproveDrug(UnapprovedDrugsTable.GetSelectedId());
            InitUnapprovedDrugs();
        }
        private void DenyDrugButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to deny this drug?")) return;
            DrugService.DenyDrug(UnapprovedDrugsTable.GetSelectedId(), DenyDrugDescription.Text);
            InitUnapprovedDrugs();
        }
        #endregion

        #region Vacation Requests
        private void InitVacationRequests()
        {
            VacationRequestTable.Fill(VacationRequestService.GetAll(_Doctor.ID));
        }
        private void SendRequestButton_Click(object sender, EventArgs e)
        {
            if (!VerifyVacationRequest()) return;

        }
        private bool VerifyVacationRequest()
        {
            if(FromDatePicker.Value - DateTime.Now < TimeSpan.FromDays(2))
            {
                MessageBoxUtilities.ShowErrorMessage("Request must be send at lest 2 days prior.");
                return false;
            }
            if (ToDatePicker.Value - FromDatePicker.Value < TimeSpan.Zero)
            {
                MessageBoxUtilities.ShowInformationMessage("Time span is not valid.");
                return false;
            }
            if (!EmergencyCheckBox.Checked || ToDatePicker.Value - FromDatePicker.Value > TimeSpan.FromDays(5))
            {
                MessageBoxUtilities.ShowErrorMessage("Emergency break can't be longer than 5 days.");
                return false;
            }
            if (ReasonTextBox.Text == "") 
            {
                MessageBoxUtilities.ShowErrorMessage("Reason text box must be filled!");
                return false;
            }
            if (DoctorService.IsOccupied(FromDatePicker.Value, ToDatePicker.Value, _Doctor.ID))
            {
                MessageBoxUtilities.ShowErrorMessage("Doctor is occupied!");
                return false;
            }
            return true;
        }
        #endregion

    }
}