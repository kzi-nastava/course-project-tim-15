using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class MedicalRecord : Form
    {
        internal Main parent;
        public MedicalRecord(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void Initialize()
        {
            MedicalRecordTable.Fill(AnamnesisService.Get(parent.patient.id), parent.patient.id);
        }
        private void GradeDoctorButtonClick(object sender, EventArgs e)
        {
            Appointment selected = MedicalRecordTable.GetSelected();
            if (!AppointmentService.IsGraded(selected.id))
            {
                var appointment = AppointmentService.GetById(selected.id);
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
            List<Anamnesis> searchResoult = AnamnesisService.GetFiltered(parent.patient.id, searchParam);
            MedicalRecordTable.Fill(searchResoult, parent.patient.id);
        }
    }
}
