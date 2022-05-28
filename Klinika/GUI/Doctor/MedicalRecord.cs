using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;
using System.Data;

namespace Klinika.GUI.Doctor
{
    public partial class MedicalRecord : Form
    {
        internal readonly DoctorMain Parent;
        public Appointment Appointment;
        public Models.MedicalRecord Record;

        #region Form
        public MedicalRecord(DoctorMain parent, Appointment appointment, bool isPreview = true)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
            Record = MedicalRecordRepository.Get(appointment.PatientID);
            if (!isPreview) ShowNewAnamnesisForm();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            FillPatientMainData();
            FillAnamnesesTable(AnamnesesTable, Record.Anamneses);
            FillDiseasesTable(DiseasesTable, Record.Diseases);
            FillAllergensTable(AllergensTable, Record.Allergens);
            FillSpecializationsComboBox();
        }
        public static void FillAnamnesesTable(DataGridView table, List<Anamnesis> anamneses)
        {
            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("ID");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");

            foreach (Anamnesis anamnesis in anamneses)
            {
                DataRow newRow = anamnesesData.NewRow();
                newRow["ID"] = anamnesis.ID;
                newRow["Description"] = anamnesis.Description;
                newRow["Symptoms"] = anamnesis.Symptoms;
                newRow["Conclusion"] = anamnesis.Conclusion;
                anamnesesData.Rows.Add(newRow);
            }

            table.DataSource = anamnesesData;
            table.Columns[0].Width = 30;
            table.ClearSelection();
        }
        public static void FillDiseasesTable(DataGridView table, List<Disease> diseases)
        {
            DataTable diseasesData = new DataTable();
            diseasesData.Columns.Add("ID");
            diseasesData.Columns.Add("Name");
            diseasesData.Columns.Add("Description");
            diseasesData.Columns.Add("Date");

            foreach (Disease disease in diseases)
            {
                DataRow newRow = diseasesData.NewRow();
                newRow["ID"] = disease.ID;
                newRow["Name"] = disease.Name;
                newRow["Description"] = disease.Description;
                newRow["Date"] = disease.DateDiagnosed.ToString("yyyy/MM/dd");
                diseasesData.Rows.Add(newRow);
            }

            table.DataSource = diseasesData;
            table.Columns[0].Width = 30;
            table.ClearSelection();
        }
        public static void FillAllergensTable(DataGridView table, List<Ingredient> allergens)
        {
            DataTable allergensData = new DataTable();
            allergensData.Columns.Add("ID");
            allergensData.Columns.Add("Name");
            allergensData.Columns.Add("Type");

            foreach (Ingredient ingredient in allergens)
            {
                DataRow newRow = allergensData.NewRow();
                newRow["ID"] = ingredient.ID;
                newRow["Name"] = ingredient.Name;
                newRow["Type"] = ingredient.Type;
                allergensData.Rows.Add(newRow);
            }

            table.DataSource = allergensData;
            table.Columns[0].Width = 30;
            table.ClearSelection();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Record
        private void FillPatientMainData()
        {
            PatientNameLabel.Text = PatientService.GetFullName(Record.ID);
            BloodTypeLabel.Text = Record.BloodType;
            HeightLabel.Text = $"{Record.Height}cm";
            WeightLabel.Text = $"{Record.Weight}kg";
        }
        private void TableSelectionChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }
        #endregion

        #region Add Anamnesis
        private void ShowNewAnamnesisForm()
        {
            AnamnesisGroup.Visible = true;
        }
        private bool ValidateAnamnesis(bool skipValidation)
        {
            bool someFieldsEmpty = DescriptionTextBox.Text.Trim() == "" || SymptomsTextBox.Text.Trim() == "" || ConclusionTextBox.Text.Trim() == "";
            if (skipValidation || !someFieldsEmpty) return true;
            return UIUtilities.Confirm("Some fields are left empty. Are you sure you want to save it?");
        }
        private bool TryCreateAnamnesis(bool skipValidation = false)
        {
            if (!ValidateAnamnesis(skipValidation)) return false;

            var anamnesis = new Anamnesis(
                Appointment.ID,
                DescriptionTextBox.Text,
                SymptomsTextBox.Text,
                ConclusionTextBox.Text);

            MedicalRecordService.StoreAnamanesis(anamnesis);
            return true;
        }
        private void FinishButtonClick(object sender, EventArgs e)
        {
            if (!IsAppointmentCompleted()) return;
            CompleteAppointment();
            Close();
        }
        #endregion

        #region Refer
        private void FillSpecializationsComboBox()
        {
            var specializations = DoctorRepository.GetSpecializations().ToArray();
            SpecializationsComboBox.Items.AddRange(specializations);
            DoctorsComboBox.SelectedIndex = -1;
        }
        private void FillDoctorsComboBox(int specializationID)
        {
            DoctorsComboBox.Items.Clear();
            DoctorsComboBox.Items.AddRange(DoctorRepository.GetSpecializedDoctors(specializationID));
        }
        private void ReferCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                EnableReferal();
                return;
            }
            DisableReferal();
        }
        private void EnableReferal()
        {
            SpecializationsComboBox.Enabled = true;
            DoctorsComboBox.Enabled = true;
        }
        private void DisableReferal()
        {
            SpecializationsComboBox.Enabled = false;
            SpecializationsComboBox.SelectedIndex = -1;
            DoctorsComboBox.Enabled = false;
            DoctorsComboBox.SelectedIndex = -1;
        }
        private void SpecializationsComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            if(SpecializationsComboBox.SelectedIndex == -1) return;
            int selectedID = (SpecializationsComboBox.SelectedItem as Specialization).ID;
            FillDoctorsComboBox(selectedID);
        }
        private bool TryCreateReferal()
        {
            if (!ReferCheckBox.Checked) return false;

            int specializationID = (SpecializationsComboBox.SelectedItem as Specialization).ID;
            int doctorID = DoctorsComboBox.SelectedIndex == -1 ? -1 : (DoctorsComboBox.SelectedItem as User).ID;
            MedicalRecordService.CreateReferal(Appointment.PatientID, specializationID, doctorID);

            MessageBoxUtilities.ShowInformationMessage("Referal made successfully!");
            return true;
        }
        #endregion

        #region Perscription
        private void AnamnesisTextChanged(object sender, EventArgs e)
        {
            bool areAllFiledsFiled = DescriptionTextBox.Text != "" && SymptomsTextBox.Text != "" && ConclusionTextBox.Text != "";
            if (areAllFiledsFiled)
            {
                PerscriptionButton.Enabled = true;
                PerscriptionHint.Visible = false;
                return;
            }
            PerscriptionButton.Enabled = false;
            PerscriptionHint.Visible = true;
        }
        private void PerscriptionButtonClick(object sender, EventArgs e)
        {
            new PrescriptionIssuing(this).Show();
        }
        #endregion

        #region Appointment
        private void CompleteAppointment()
        {
            Appointment.Completed = true;
            AppointmentRepository.GetInstance().Modify(Appointment);
            Parent.ScheduleTable.ModifySelected(Appointment);
        }
        private bool IsAppointmentCompleted()
        {
            bool isCreated = TryCreateReferal();
            return TryCreateAnamnesis(isCreated);
        }
        #endregion
    }
}