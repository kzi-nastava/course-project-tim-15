using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class MedicalRecord : Form
    {
        internal readonly ViewSchedule parent;
        public Appointment appointment;
        public Models.MedicalRecord record;
        #region Form
        public MedicalRecord(ViewSchedule parent, Appointment appointment, bool isPreview = true)
        {
            InitializeComponent();
            this.parent = parent;
            this.appointment = appointment;
            record = MedicalRecordService.Get(appointment.patientID);
            if (!isPreview) AnamnesisGroup.Visible = true;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            FillPatientMainData();
            AnamnesesTable.Fill(record.anamneses);
            DiseasesTable.Fill(record.diseases);
            AllergensTable.Fill(record.allergens);
            UIUtilities.FillSpecializationComboBox(SpecializationsComboBox);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        #endregion
        #region Record
        private void FillPatientMainData()
        {
            PatientNameLabel.Text = PatientService.GetFullName(record.id);
            BloodTypeLabel.Text = record.bloodType;
            HeightLabel.Text = $"{record.height}cm";
            WeightLabel.Text = $"{record.weight}kg";
        }
        #endregion
        #region Add Anamnesis
        private bool ValidateAnamnesis(bool skipValidation)
        {
            bool hasEmptyFields = DescriptionTextBox.Text.Trim() == "" || SymptomsTextBox.Text.Trim() == "" || ConclusionTextBox.Text.Trim() == "";
            if (skipValidation || !hasEmptyFields) return true;
            return UIUtilities.Confirm("Some fields are left empty. Are you sure you want to save it?");
        }
        private bool TryCreateAnamnesis(bool skipValidation = false)
        {
            if (!ValidateAnamnesis(skipValidation)) return false;

            var anamnesis = new Anamnesis(appointment.id, DescriptionTextBox.Text,
                SymptomsTextBox.Text, ConclusionTextBox.Text);

            AnamnesisService.Create(anamnesis);
            return true;
        }
        private void FinishButtonClick(object sender, EventArgs e)
        {
            if (!IsAppointmentCompleted()) return;
            Close();
            new DynamicEquipment(parent, appointment).Show();
        }
        #endregion
        #region Refer
        private void ReferCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ToggleReferal(ReferCheckBox.Checked);
        }
        private void ToggleReferal(bool state)
        {
            SpecializationsComboBox.Enabled = state;
            DoctorsComboBox.Enabled = state;
            SpecializationsComboBox.SelectedIndex = -1;
            DoctorsComboBox.SelectedIndex = -1;
        }
        private void SpecializationsComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            if(SpecializationsComboBox.SelectedIndex == -1) return;
            int selectedID = (SpecializationsComboBox.SelectedItem as Specialization).id;
            UIUtilities.FillSpecializedDoctorComboBox(DoctorsComboBox, selectedID);
        }
        private bool TryCreateReferal()
        {
            if (!ReferCheckBox.Checked) return false;

            int specializationID = (SpecializationsComboBox.SelectedItem as Specialization).id;
            int doctorID = DoctorsComboBox.SelectedIndex == -1 ? -1 : (DoctorsComboBox.SelectedItem as User).id;
            ReferralService.Create(appointment.patientID, specializationID, doctorID);

            MessageBoxUtilities.ShowInformationMessage("Referal made successfully!");
            return true;
        }
        #endregion
        #region Perscription
        private void AnamnesisTextChanged(object sender, EventArgs e)
        {
            bool hasEmptyFileds = DescriptionTextBox.Text == "" || SymptomsTextBox.Text == "" || ConclusionTextBox.Text == "";
            if (!hasEmptyFileds)
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
        private bool IsAppointmentCompleted()
        {
            bool isCreated = TryCreateReferal();
            return TryCreateAnamnesis(isCreated);
        }
        #endregion
    }
}