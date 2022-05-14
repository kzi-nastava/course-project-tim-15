﻿using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.GUI.Doctor;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        private readonly PrescriptionIssuing Form;
        public PrescriptionService(PrescriptionIssuing form)
        {
            Form = form;
        }
        public static void FillTable(DataGridView table)
        {
            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("ID");
            drugsData.Columns.Add("Name");
            drugsData.Columns.Add("Ingredients");

            foreach (Drug drug in DrugRepository.Instance.Drugs)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["ID"] = drug.ID;
                newRow["Name"] = drug.Name;
                newRow["Ingredients"] = drug.GetIngredientsAsString();
                drugsData.Rows.Add(newRow);
            }

            table.DataSource = drugsData;
            table.Columns[0].Width = 30;
            table.Columns[1].Width = 80;
            table.ClearSelection();
        }
        public static Drug GetSelectedDrug(DataGridView table)
        {
            int drugId = Convert.ToInt32(table.SelectedRows[0].Cells["ID"].Value);
            var selectedDrug = DrugRepository.Instance.Drugs.Where(x => x.ID == drugId).FirstOrDefault();
            return selectedDrug;
        }
        public void FinishForm()
        {
            if (!Validate()) return;

            var selected = GetSelectedDrug(Form.DrugsTable);

            if (!ValidateDrug(selected)) return;

            CreateInDatabase(selected);
            MessageBox.Show("Drug prescripted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool Validate()
        {
            var startDate = Form.PrescriptionStartDatePicker.Value;
            var endDate = Form.PrescriptionEndDatePicker.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Date is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Form.IntervalSpinner.Value == 0)
            {
                MessageBox.Show("Interval must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Form.DrugsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Drug not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidateDrug(Drug selectedDrug)
        {
            foreach (Ingredient ingredient in selectedDrug.Ingredients)
            {
                if (Form.Parent.Record.Allergens.Contains(ingredient))
                {
                    var msgBox = MessageBox.Show($"Patient is allergic to {ingredient.Name}, which is found in selected drug\n" +
                        $"Are you sure you want to prescript it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgBox == DialogResult.Yes) return true;
                    return false;
                }
            }
            return true;
        }
        private void CreateInDatabase(Drug selectedDrug)
        {
            var prescription = new Prescription();
            prescription.PatientID = Form.Parent.Appointment.PatientID;
            prescription.DrugID = selectedDrug.ID;
            prescription.DateStarted = Form.PrescriptionStartDatePicker.Value;
            prescription.DateEnded = Form.PrescriptionEndDatePicker.Value;
            prescription.Interval = Convert.ToInt32(Form.IntervalSpinner.Value);
            prescription.Comment = Form.CommentTextBox.Text;

            DrugRepository.CreatePrescription(prescription);
        }
    }
}