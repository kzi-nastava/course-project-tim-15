using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Doctor
{
    public partial class MedicalRecord : Form
    {
        internal readonly DoctorMain Parent;
        public Appointment Appointment;
        public Models.MedicalRecord Record;
        private MedicalRecordService Service;

        #region Form
        public MedicalRecord(DoctorMain parent, Appointment appointment, bool isPreview = true)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
            Record = MedicalRecordRepository.Get(appointment.PatientID);
            if (!isPreview) ShowNewAnamnesisForm();
            Service = new MedicalRecordService(this);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            FillPatientMainData();
            MedicalRecordService.FillAnamnesesTable(AnamnesesTable, Record.Anamneses);
            MedicalRecordService.FillDiseasesTable(DiseasesTable, Record.Diseases);
            MedicalRecordService.FillAllergensTable(AllergensTable, Record.Allergens);
            FillSpecializationsComboBox();
            
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region View Record
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
        private void FinishButtonClick(object sender, EventArgs e)
        {
            Service.FinishForm();
            Close();
        }
        #endregion

        #region Refer
        private void FillSpecializationsComboBox()
        {
            var specializations = DoctorRepository.GetSpecializations().ToArray();
            SpecializationsComboBox.Items.AddRange(specializations);
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
        private void SpecializationsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(SpecializationsComboBox.SelectedIndex == -1)
            {
                return;
            }
            int selectedID = (SpecializationsComboBox.SelectedItem as Specialization).ID;
            FillDoctorsComboBox(selectedID);
            DoctorsComboBox.SelectedIndex = -1;
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
    }
}
