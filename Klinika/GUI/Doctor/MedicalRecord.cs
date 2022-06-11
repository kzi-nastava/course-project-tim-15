using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Dependencies;

namespace Klinika.GUI.Doctor
{
    public partial class MedicalRecord : Form
    {
        private readonly AnamnesisService? anamnesisService;
        private readonly MedicalRecordService? medicalRecordService;
        private readonly ReferralService? referralService;
        internal readonly ViewSchedule parent;
        public Appointment appointment;
        public Models.MedicalRecord record;
        private bool hasEmptyFields
        {
            get { return DescriptionTextBox.Text.Trim() == "" || SymptomsTextBox.Text.Trim() == "" || ConclusionTextBox.Text.Trim() == ""; }
        }
        #region Form
        public MedicalRecord(ViewSchedule parent, Appointment appointment, bool isPreview = true)
        {
            InitializeComponent();
            this.parent = parent;
            this.appointment = appointment;
            referralService = StartUp.serviceProvider.GetService<ReferralService>();
            anamnesisService = StartUp.serviceProvider.GetService<AnamnesisService>();
            medicalRecordService = StartUp.serviceProvider.GetService<MedicalRecordService>();
            if (!isPreview) AnamnesisGroup.Visible = true;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            record = medicalRecordService.Get(appointment.patientID);
            FillPatientMainData();
            AnamnesesTable.Fill(record.anamneses);
            DiseasesTable.Fill(record.diseases);
            AllergensTable.Fill(record.allergens);
            UIUtilities.FillSpecializationComboBox(SpecializationsComboBox);
        }
        //TODO @s
        private void FillPatientMainData()
        {
            PatientNameLabel.Text = PatientService.GetFullName(record.id);
            BloodTypeLabel.Text = record.bloodType;
            HeightLabel.Text = $"{record.height}cm";
            WeightLabel.Text = $"{record.weight}kg";
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        #endregion
        private void FinishButtonClick(object sender, EventArgs e)
        {
            if (!IsAppointmentCompleted()) return;
            new DynamicEquipment(parent, appointment).Show();
            Close();
        }
        private void ReferCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ToggleReferal(ReferCheckBox.Checked);
        }
        private void SpecializationsComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            if(SpecializationsComboBox.SelectedIndex == -1) return;
            int selectedID = (SpecializationsComboBox.SelectedItem as Specialization).id;
            UIUtilities.FillSpecializedDoctorComboBox(DoctorsComboBox, selectedID);
        }
        private void ToggleReferal(bool state)
        {
            SpecializationsComboBox.Enabled = state;
            DoctorsComboBox.Enabled = state;
            SpecializationsComboBox.SelectedIndex = -1;
            DoctorsComboBox.SelectedIndex = -1;
        }
        private void AnamnesisTextChanged(object sender, EventArgs e)
        {
            TogglePrescriptionIssuing(hasEmptyFields);
        }
        private void TogglePrescriptionIssuing(bool state)
        {
            PerscriptionButton.Enabled = !state;
            PerscriptionHint.Visible = state;
        }
        private void PerscriptionButtonClick(object sender, EventArgs e)
        {
            new PrescriptionIssuing(this).Show();
        }
        private bool ValidateAnamnesis(bool skipValidation)
        {
            if (skipValidation || !hasEmptyFields) return true;
            return UIUtilities.Confirm("Some fields are left empty. Are you sure you want to save it?");
        }
        private bool TryCreateReferal()
        {
            if (!ReferCheckBox.Checked) return false;

            int specializationID = (SpecializationsComboBox.SelectedItem as Specialization).id;
            int doctorID = DoctorsComboBox.SelectedIndex == -1 ? -1 : (DoctorsComboBox.SelectedItem as User).id;
            referralService.Create(appointment.patientID, specializationID, doctorID);

            MessageBoxUtilities.ShowInformationMessage("Referal made successfully!");
            return true;
        }
        private bool TryCreateAnamnesis(bool skipValidation = false)
        {
            if (!ValidateAnamnesis(skipValidation)) return false;

            var anamnesis = new Anamnesis(appointment.id, DescriptionTextBox.Text,
                SymptomsTextBox.Text, ConclusionTextBox.Text);

            anamnesisService.Create(anamnesis);
            return true;
        }
        private bool IsAppointmentCompleted()
        {
            bool isCreated = TryCreateReferal();
            return TryCreateAnamnesis(isCreated);
        }
    }
}