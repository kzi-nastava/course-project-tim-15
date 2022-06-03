using Klinika.Services;
using Klinika.Roles;
using Klinika.Utilities;
using System.Data;

namespace Klinika.GUI.Patient
{
    public partial class NewAppointment : Form
    {
        internal Main parent;
        public NewAppointment(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitNewAppointmentTab();
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
        }
        private void InitNewAppointmentTab()
        {
            ScheduleButton.Enabled = false;
            OccupiedAppointmentsTable.DataSource = new DataTable();
        }
        private void FindAppointmentsButtonClick(object sender, EventArgs e)
        {
            if (!IsDateValid(AppointmentDatePicker.Value)) return;

            int doctorID = (DoctorComboBox.SelectedItem as User).id;
            OccupiedAppointmentsTable.Fill(DoctorService.GetAppointments(AppointmentDatePicker.Value, doctorID));
            ScheduleButton.Enabled = true;
        }
        private void ScheduleButtonClick(object sender, EventArgs e)
        {
            new PersonalAppointment(this).Show();
        }
        private void RecommendButtonClick(object sender, EventArgs e)
        {
            new AppointmentRecommendation(this).Show();
        }
        public bool IsDateValid(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
    }
}
