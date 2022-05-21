using Klinika.Models;
using Klinika.Repositories;
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
    public partial class PrescriptionIssuing : Form
    {
        internal readonly MedicalRecord Parent;

        #region Form
        public PrescriptionIssuing(MedicalRecord parent)
        {
            InitializeComponent();
            Parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            PrescriptionStartDatePicker.MinDate = DateTime.Now;
            PrescriptionEndDatePicker.MinDate = DateTime.Now;
            DrugsTable.Fill(DrugRepository.Instance.GetApproved());
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Prescript
        private void PrescriptButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var prescription = new Prescription(
                Parent.Appointment.PatientID,
                DrugsTable.GetSelectedId(),
                new TimeSlot(PrescriptionStartDatePicker.Value, PrescriptionEndDatePicker.Value),
                Convert.ToInt32(IntervalSpinner.Value),
                CommentTextBox.Text);
            PrescriptionService.StorePrescription(prescription);

            MessageBox.Show("Drug prescripted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        private bool ValidateForm()
        {
            if (!ValidateDate()) return false;
            if (!ValidateDrug()) return false;
            return true;
        }
        private bool ValidateDate()
        {
            var startDate = PrescriptionStartDatePicker.Value;
            var endDate = PrescriptionEndDatePicker.Value;

            if (startDate < endDate) return true;

            MessageBox.Show("Date is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private bool ValidateDrug()
        {
            if (!IsDrugSelected()) return false;
            if (!IsDrugPrescriptible(DrugsTable.GetSelectedDrug())) return false;
            return true;
        }
        private bool IsDrugSelected()
        {
            if (DrugsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Drug not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsDrugPrescriptible(Drug selected)
        {
            if (!Parent.Record.IsAllergic(selected)) return true;

            var msgBox = MessageBox.Show($"Patient is allergic to ingredient found in the selected drug\n" +
                        $"Are you sure you want to prescript it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msgBox == DialogResult.Yes) return true;
            return false;
        }
        #endregion
    }
}