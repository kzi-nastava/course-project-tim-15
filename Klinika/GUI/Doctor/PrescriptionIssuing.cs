using Klinika.Dependencies;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class PrescriptionIssuing : Form
    {
        private readonly DrugService? drugService;
        private readonly PrescriptionService? prescriptionService;
        internal readonly MedicalRecord parent;

        #region Form
        public PrescriptionIssuing(MedicalRecord parent)
        {
            InitializeComponent();
            this.parent = parent;
            drugService = StartUp.serviceProvider.GetService<DrugService>();
            prescriptionService = StartUp.serviceProvider.GetService<PrescriptionService>();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            PrescriptionStartDatePicker.MinDate = DateTime.Now;
            PrescriptionEndDatePicker.MinDate = DateTime.Now;
            DrugsTable.Fill(drugService.GetApproved());
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        #endregion

        #region Prescript
        private void PrescriptButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var prescription = new Prescription(
                parent.appointment.patientID,
                DrugsTable.GetSelectedId(),
                new TimeSlot(PrescriptionStartDatePicker.Value, PrescriptionEndDatePicker.Value),
                Convert.ToInt32(IntervalSpinner.Value),
                CommentTextBox.Text);
            prescriptionService.Create(prescription);

            MessageBoxUtilities.ShowInformationMessage("Drug prescripted!");
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
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
        private bool ValidateDrug()
        {
            if (!IsDrugSelected())
            {
                MessageBoxUtilities.ShowErrorMessage("Drug not selected!");
                return false;
            }
            if (!IsDrugPrescriptible(DrugsTable.GetSelectedDrug()))
            {
                var msg = "Patient is allergic to ingredient found in the selected drug\n" + "Are you sure you want to prescript it?";
                return UIUtilities.Confirm(msg);
            }
            return true;
        }
        private bool IsDrugSelected()
        {
            if (DrugsTable.SelectedRows.Count == 0) return false;
            return true;
        }
        private bool IsDrugPrescriptible(Drug selected)
        {
            if (!parent.record.IsAllergic(selected)) return true;
            return false;
        }
        #endregion
    }
}