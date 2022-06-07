using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class ViewAllAppointments : Form
    {
        internal readonly Main parent;
        internal Roles.Doctor doctor { get { return parent.doctor; } }
        public ViewAllAppointments(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitAllAppointmentsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }

        #region All Appointments
        private void InitAllAppointmentsTab()
        {
            AllAppointmentsTable.Fill(DoctorService.GetAppointments(doctor.id));
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;
        }
        private void AllAppointmentsTableCellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}