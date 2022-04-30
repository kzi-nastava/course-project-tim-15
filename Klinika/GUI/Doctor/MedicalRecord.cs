using Klinika.Models;
using Klinika.Repositories;
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
        private readonly DoctorMain Parent;
        private Appointment Appointment;
        private Models.MedicalRecord Record;
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
            FillAnamnesesTable();
            FillDiseasesTable();
            FillAllergensTable();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region View Record
        private void FillPatientMainData()
        {
            PatientNameLabel.Text = Parent.GetPatientFullName(Record.ID);
            BloodTypeLabel.Text = Record.BloodType;
            HeightLabel.Text = $"{Record.Height}cm";
            WeightLabel.Text = $"{Record.Weight}kg";
        }
        private void FillAnamnesesTable()
        {
            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("ID");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");

            foreach (Anamnesis anamnesis in Record.Anamneses)
            {
                DataRow newRow = anamnesesData.NewRow();
                newRow["ID"] = anamnesis.ID;
                newRow["Description"] = anamnesis.Description;
                newRow["Symptoms"] = anamnesis.Symptoms;
                newRow["Conclusion"] = anamnesis.Conclusion;
                anamnesesData.Rows.Add(newRow);
            }

            AnamnesesTable.DataSource = anamnesesData;
            AnamnesesTable.Columns[0].Width = 30;
            AnamnesesTable.ClearSelection();
        }
        private void FillDiseasesTable()
        {
            DataTable diseasesData = new DataTable();
            diseasesData.Columns.Add("ID");
            diseasesData.Columns.Add("Name");
            diseasesData.Columns.Add("Description");
            diseasesData.Columns.Add("Date");

            foreach (Disease disease in Record.Diseases)
            {
                DataRow newRow = diseasesData.NewRow();
                newRow["ID"] = disease.ID;
                newRow["Name"] = disease.Name;
                newRow["Description"] = disease.Description;
                newRow["Date"] = disease.DateDiagnosed.ToString("yyyy/MM/dd");
                diseasesData.Rows.Add(newRow);
            }

            DiseasesTable.DataSource = diseasesData;
            DiseasesTable.Columns[0].Width = 30;
            DiseasesTable.ClearSelection();
        }
        private void FillAllergensTable()
        {
            DataTable allergensData = new DataTable();
            allergensData.Columns.Add("ID");
            allergensData.Columns.Add("Name");
            allergensData.Columns.Add("Type");

            foreach (Allergen allergen in Record.Allergens)
            {
                DataRow newRow = allergensData.NewRow();
                newRow["ID"] = allergen.ID;
                newRow["Name"] = allergen.Name;
                newRow["Type"] = allergen.Type;
                allergensData.Rows.Add(newRow);
            }

            AllergensTable.DataSource = allergensData;
            AllergensTable.Columns[0].Width = 30;
            AllergensTable.ClearSelection();
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
            if (!VerifyForm())
            {
                return;
            }

            CreateAnamanesisInDatabase();

            Appointment.Completed = true;
            AppointmentRepository.GetInstance().Modify(Appointment);

            Parent.UpdateTableRow(Appointment, Parent.ScheduleTable);
            Close();
        }
        private void CreateAnamanesisInDatabase()
        {
            Anamnesis anamnesis = new Anamnesis();
            anamnesis.Description = DescriptionTextBox.Text;
            anamnesis.Symptoms = SymptomsTextBox.Text;
            anamnesis.Conclusion = ConclusionTextBox.Text;
            anamnesis.MedicalActionID = Appointment.ID;
            anamnesis.ID = MedicalRecordRepository.CreateAnamnesis(anamnesis);
        }
        private bool VerifyForm()
        {
            if (DescriptionTextBox.Text.Trim() == "" || SymptomsTextBox.Text.Trim() == "" || ConclusionTextBox.Text.Trim() == "")
            {
                var msgBox = MessageBox.Show("Some fields are left empty. Are you sure you want to save it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgBox == DialogResult.Yes) return true;
                return false;
            }
            return true;
        }
        #endregion

    }
}
