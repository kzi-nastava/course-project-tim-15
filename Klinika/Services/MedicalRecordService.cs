using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        private readonly GUI.Doctor.MedicalRecord Form;
        public MedicalRecordService(GUI.Doctor.MedicalRecord form)
        {
            Form = form;
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

        public void FinishForm()
        {
            if (!Validate()) return;

            CreateAnamanesisInDatabase();

            if (Form.ReferCheckBox.Checked) CreateReferalInDatabase();

            Form.Appointment.Completed = true;
            AppointmentRepository.GetInstance().Modify(Form.Appointment);

            DoctorService.UpdateTableRow(Form.Appointment, Form.Parent.ScheduleTable);
            DoctorService.UpdateTableRow(Form.Appointment, Form.Parent.AllAppointmentsTable);
        }
        private bool Validate()
        {
            if (Form.DescriptionTextBox.Text.Trim() == "" || Form.SymptomsTextBox.Text.Trim() == "" || Form.ConclusionTextBox.Text.Trim() == "")
            {
                var msgBox = MessageBox.Show("Some fields are left empty. Are you sure you want to save it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgBox == DialogResult.Yes) return true;
                return false;
            }
            return true;
        }
        private void CreateAnamanesisInDatabase()
        {
            Anamnesis anamnesis = new Anamnesis();
            anamnesis.Description = Form.DescriptionTextBox.Text;
            anamnesis.Symptoms = Form.SymptomsTextBox.Text;
            anamnesis.Conclusion = Form.ConclusionTextBox.Text;
            anamnesis.MedicalActionID = Form.Appointment.ID;
            anamnesis.ID = MedicalRecordRepository.CreateAnamnesis(anamnesis);
        }
        private void CreateReferalInDatabase()
        {
            int specializationID = (Form.SpecializationsComboBox.SelectedItem as Specialization).ID;
            int doctorID = Form.DoctorsComboBox.SelectedIndex == -1 ? -1 : (Form.DoctorsComboBox.SelectedItem as User).ID;
            ReferalRepository.Create(Form.Appointment.PatientID, specializationID, doctorID);
        }
    }
}
