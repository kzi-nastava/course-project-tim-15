using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class ViewAllAppointments : Form
    {
        internal readonly Main parent;
        public ViewAllAppointments(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void ViewAllAppointments_Load(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitAllAppointmentsTab();
        }
        private void ViewAllAppointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }

        #region All Appointments
        private void InitAllAppointmentsTab()
        {
            AllAppointmentsTable.Fill(DoctorService.GetAppointments(parent.doctor.id));
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;
        }
        private void AllAppointmentsTable_CellClick(object sender, DataGridViewCellEventArgs e)
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