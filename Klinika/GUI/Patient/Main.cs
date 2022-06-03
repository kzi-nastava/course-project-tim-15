using Klinika.Services;
using Klinika.Models;

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
            new MedicalRecord(this).Show();
        }
        private void SearchDoctorsButtonClick(object sender, EventArgs e)
        {
            new SearchDoctors(this).Show();
        }
        private void NotificationsButtonClick(object sender, EventArgs e)
        {
            new Notifications(this).Show();
        }
        private void QuestionnaireForClinicButtonClick(object sender, EventArgs e)
        {
            new Questionnaire(this, patient.id, Question.Types.CLINIC).Show();
        }
    }
}
