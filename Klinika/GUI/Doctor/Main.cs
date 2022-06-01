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
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void AllAppointmetnsButton_Click(object sender, EventArgs e)
        {
            new ViewAllAppointments(this).Show();
        }
        private void ViewScheduleButton_Click(object sender, EventArgs e)
        {
            new ViewSchedule(this).Show();
        }
        private void UnapprovedDrugsButton_Click(object sender, EventArgs e)
        {
            new ManageUnapprovedDrugs(this).Show();
        }
        private void VacationRequestButton_Click(object sender, EventArgs e)
        {
            new VacationRequests(this).Show();
        }
    }
}