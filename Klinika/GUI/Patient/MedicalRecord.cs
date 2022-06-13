using Klinika.Dependencies;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Patient
{
    public partial class MedicalRecord : Form
    {
        private readonly AnamnesisService? anamnesisService;
        private readonly QuestionnaireService? questionnaireService;
        private readonly AppointmentService? appointmentService;
        internal Main parent;
        public MedicalRecord(Main parent)
        {
            InitializeComponent();
            anamnesisService = StartUp.serviceProvider.GetService<AnamnesisService>();
            questionnaireService = StartUp.serviceProvider.GetService<QuestionnaireService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        private void Initialize()
        {
            MedicalRecordTable.Fill(anamnesisService.Get(parent.patient.id), parent.patient.id);
        }
        private void GradeDoctorButtonClick(object sender, EventArgs e)
        {
            Appointment selected = MedicalRecordTable.GetSelected();
            if (!questionnaireService.IsAppointmentGraded(selected.id))
            {
                var appointment = appointmentService.GetById(selected.id);
                new Questionnaire(this, parent.patient.id, Question.Types.DOCTOR, appointment.id, appointment.doctorID).Show();
                return;
            }
            MessageBoxUtilities.ShowErrorMessage("You already graded this appointment!");
        }
        private void ResetButtonClick(object sender, EventArgs e)
        {
            Initialize();
            SearchTextBox.Text = "";
        }
        private void SearchButtonClick(object sender, EventArgs e)
        {
            string searchParam = SearchTextBox.Text;
            List<Anamnesis> searchResoult = anamnesisService.GetFiltered(parent.patient.id, searchParam);
            MedicalRecordTable.Fill(searchResoult, parent.patient.id);
        }
    }
}
