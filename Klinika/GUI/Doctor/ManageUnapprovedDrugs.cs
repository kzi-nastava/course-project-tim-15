using Klinika.Dependencies;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class ManageUnapprovedDrugs : Form
    {
        private readonly DrugService? drugService;
        internal readonly Main parent;
        public ManageUnapprovedDrugs(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
            drugService = StartUp.serviceProvider.GetService<DrugService>();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitUnapprovedDrugs();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitUnapprovedDrugs()
        {
            UnapprovedDrugsTable.Fill(drugService.GetUnapproved());
            ApproveDrugButton.Enabled = false;
            DenyDrugButton.Enabled = false;
            DenyDrugDescription.Text = "";
        }
        private void UnapprovedDrugsTableSelectionChanged(object sender, EventArgs e)
        {
            ApproveDrugButton.Enabled = true;
            DenyDrugDescription.Text = "";
        }
        private void DenyDrugDescriptionTextChanged(object sender, EventArgs e)
        {
            DenyDrugButton.Enabled = DenyDrugDescription.Text != "" && ApproveDrugButton.Enabled;
        }
        private void ApproveDrugButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to approve this drug?")) return;
            drugService.ApproveDrug(UnapprovedDrugsTable.GetSelectedId());
            InitUnapprovedDrugs();
        }
        private void DenyDrugButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to deny this drug?")) return;
            drugService.DenyDrug(UnapprovedDrugsTable.GetSelectedId(), DenyDrugDescription.Text);
            InitUnapprovedDrugs();
        }
    }
}