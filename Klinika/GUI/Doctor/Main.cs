using Klinika.Core.Dependencies;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class Main : Form
    {
        private readonly DoctorService? doctorService;
        public Users.Models.Doctor doctor { get; }
        public Main(int doctorID)
        {
            InitializeComponent();
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
            doctor = doctorService.GetById(doctorID);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => Application.Exit();
        private void AllAppointmetnsButtonClick(object sender, EventArgs e) => new ViewAllAppointments(this).Show();
        private void ViewScheduleButtonClick(object sender, EventArgs e) => new ViewSchedule(this).Show();
        private void UnapprovedDrugsButtonClick(object sender, EventArgs e) => new ManageUnapprovedDrugs(this).Show();
        private void VacationRequestButtonClick(object sender, EventArgs e) => new VacationRequests(this).Show();
    }
}