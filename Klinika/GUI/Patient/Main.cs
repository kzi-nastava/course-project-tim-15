using Klinika.Services;

namespace Klinika.GUI.Patient
{
    public partial class Main : Form
    {
        internal Roles.Patient patient;
        public Main(int patientID)
        {
            InitializeComponent();
            patient = PatientService.GetById(patientID);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void ViewScheduleButtonClick(object sender, EventArgs e)
        {
            new ViewSchedule(this).Show();
        }
        private void NewAppointmentButtonClick(object sender, EventArgs e)
        {
            new NewAppointment(this).Show();
        }
        private void MedicalRecordButtonClick(object sender, EventArgs e)
        {

        }
        private void SearchDoctorsButtonClick(object sender, EventArgs e)
        {

        }
        private void NotificationsButtonClick(object sender, EventArgs e)
        {

        }
        private void QuestionnaireForClinicButtonClick(object sender, EventArgs e)
        {

        }

        
    }
}
