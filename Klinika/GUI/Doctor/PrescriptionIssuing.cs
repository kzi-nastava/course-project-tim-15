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
    public partial class PrescriptionIssuing : Form
    {
        private readonly MedicalRecord Parent;

        #region Form
        public PrescriptionIssuing(MedicalRecord parent)
        {
            InitializeComponent();
            Parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            FillPrescriptionTable();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Prescript
        private void FillPrescriptionTable()
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

            DrugsTable.DataSource = drugsData;
            DrugsTable.Columns[0].Width = 30;
            DrugsTable.Columns[1].Width = 80;
            DrugsTable.ClearSelection();
        }
        private bool VerifyForm()
        {
            var startDate = PrescriptionStartDatePicker.Value;
            var endDate = PrescriptionEndDatePicker.Value;
            // Date
            if (startDate > endDate)
            {
                MessageBox.Show("Date is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Interval
            if (IntervalSpinner.Value == 0)
            {
                MessageBox.Show("Interval must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Drug
            if (DrugsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Drug not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool VerifyDrug(Drug selectedDrug)
        {
            foreach(Ingredient ingredient in selectedDrug.Ingredients)
            {
                if (Parent.Record.Allergens.Contains(ingredient))
                {
                    var msgBox = MessageBox.Show($"Patient is allergic to {ingredient.Name}, which is found in selected drug\n" +
                        $"Are you sure you want to prescript it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgBox == DialogResult.Yes) return true;
                    return false;
                }
            }
            return true;
        }
        private void PrescriptButtonClick(object sender, EventArgs e)
        {
            if (!VerifyForm())
            {
                return;
            }

            int drugId = Convert.ToInt32(DrugsTable.SelectedRows[0].Cells["ID"].Value);
            var selectedDrug = DrugRepository.Instance.Drugs.Where(x => x.ID == drugId).FirstOrDefault();
            
            if (!VerifyDrug(selectedDrug))
            {
                return;
            }
            MessageBox.Show("Drug prescripted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
