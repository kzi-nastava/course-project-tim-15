using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class VacationRequests : Form
    {
        internal readonly Main parent;
        private Roles.Doctor doctor { get { return parent.doctor; } }
        public VacationRequests(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitVacationRequests();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitVacationRequests()
        {
            VacationRequestTable.Fill(VacationRequestService.GetAll(doctor.id));
        }
        private void SendRequestButtonClick(object sender, EventArgs e)
        {
            if (!VerifyVacationRequest()) return;
            var vacationRequest = new VacationRequest(doctor.id, FromDatePicker.Value, ToDatePicker.Value,
                ReasonTextBox.Text, EmergencyCheckBox.Checked);
            VacationRequestService.Create(vacationRequest);
            VacationRequestTable.Insert(vacationRequest);
        }
        private bool VerifyVacationRequest()
        {
            if (FromDatePicker.Value - DateTime.Now < TimeSpan.FromDays(2))
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
    }
}
