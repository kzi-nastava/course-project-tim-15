using System.Data;
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
            FillMedicalRecordTable(AnamnesisService.Get(parent.patient.id));
        }
        private void FillMedicalRecordTable(List<Anamnesis> anamneses)
        {
            List<Appointment> appointments = AppointmentService.GetCompleted(parent.patient.id);

            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("Appointment ID");
            anamnesesData.Columns.Add("Doctor");
            anamnesesData.Columns.Add("Doctor Specialization");
            anamnesesData.Columns.Add("DateTime");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");

            foreach (Anamnesis anamnesis in anamneses)
            {
                DataRow newRow = anamnesesData.NewRow();
                Appointment appointment = appointments.Where(x => x.id == anamnesis.medicalActionID).FirstOrDefault();
                newRow["Appointment ID"] = anamnesis.medicalActionID;
                newRow["Doctor"] = DoctorService.GetFullName(appointment.doctorID);
                newRow["Doctor Specialization"] = DoctorService.GetSpecialization(appointment.doctorID);
                newRow["DateTime"] = appointment.dateTime;
                newRow["Description"] = anamnesis.description;
                newRow["Symptoms"] = anamnesis.symptoms;
                newRow["Conclusion"] = anamnesis.conclusion;
                anamnesesData.Rows.Add(newRow);
            }
            MedicalRecordTable.DataSource = anamnesesData;
        }
        private void GradeDoctorButtonClick(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(UIUtilities.GetCellValue(MedicalRecordTable, "Appointment ID"));
            if (!AppointmentService.IsGraded(selected))
            {
                var appointment = AppointmentService.GetById(selected);
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
            FillMedicalRecordTable(searchResoult);
        }
    }
}
