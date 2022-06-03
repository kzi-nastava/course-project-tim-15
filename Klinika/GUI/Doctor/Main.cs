using Klinika.Services;

namespace Klinika.GUI.Doctor
{
    public partial class Main : Form
    {
        public Roles.Doctor doctor { get; }
        public Main(int doctorID)
        {
            InitializeComponent();
            doctor = DoctorService.GetById(doctorID);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void AllAppointmetnsButtonClick(object sender, EventArgs e)
        {
            new ViewAllAppointments(this).Show();
        }
        private void ViewScheduleButtonClick(object sender, EventArgs e)
        {
            new ViewSchedule(this).Show();
        }
        private void UnapprovedDrugsButtonClick(object sender, EventArgs e)
        {
            new ManageUnapprovedDrugs(this).Show();
        }
        private void VacationRequestButtonClick(object sender, EventArgs e)
        {
            new VacationRequests(this).Show();
        }
    }
}