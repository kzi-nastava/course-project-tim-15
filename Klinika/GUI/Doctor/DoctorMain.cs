using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class DoctorMain : Form
    {
        public Roles.Doctor doctor { get; }

        #region Form
        public DoctorMain(int doctorID)
        {
            InitializeComponent();
            doctor = DoctorService.GetById(doctorID);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            //InitAllAppointmentsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MainTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (MainTabControl.SelectedIndex == 1) InitScheduleTab();
            if (MainTabControl.SelectedIndex == 2) InitUnapprovedDrugs();
            if (MainTabControl.SelectedIndex == 3) InitVacationRequests();
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
            VacationRequestTable.Fill(VacationRequestService.GetAll(doctor.id));
        }
        private void SendRequestButton_Click(object sender, EventArgs e)
        {
            if (!VerifyVacationRequest()) return;
            var vacationRequest = new VacationRequest(doctor.id, FromDatePicker.Value, ToDatePicker.Value, 
                ReasonTextBox.Text, EmergencyCheckBox.Checked);
            VacationRequestService.Create(vacationRequest);
            VacationRequestTable.Insert(vacationRequest);
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
            if (EmergencyCheckBox.Checked && ToDatePicker.Value - FromDatePicker.Value > TimeSpan.FromDays(5))
            {
                MessageBoxUtilities.ShowErrorMessage("Emergency break can't be longer than 5 days.");
                return false;
            }
            if (ReasonTextBox.Text == "") 
            {
                MessageBoxUtilities.ShowErrorMessage("Reason text box must be filled!");
                return false;
            }
            if (DoctorService.IsOccupied(doctor.id, new TimeSlot(FromDatePicker.Value, ToDatePicker.Value)))
            {
                MessageBoxUtilities.ShowErrorMessage("Doctor is occupied!");
                return false;
            }
            return true;
        }
        #endregion

    }
}