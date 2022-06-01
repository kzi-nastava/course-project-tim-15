using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class ManageUnapprovedDrugs : Form
    {
        internal readonly Main parent;
        public ManageUnapprovedDrugs(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void ManageUnapprovedDrugs_Load(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitUnapprovedDrugs();
        }
        private void ManageUnapprovedDrugs_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitUnapprovedDrugs()
        {
            UnapprovedDrugsTable.Fill(DrugService.GetUnapproved());
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
            DrugService.ApproveDrug(UnapprovedDrugsTable.GetSelectedId());
            InitUnapprovedDrugs();
        }
        private void DenyDrugButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to deny this drug?")) return;
            DrugService.DenyDrug(UnapprovedDrugsTable.GetSelectedId(), DenyDrugDescription.Text);
            InitUnapprovedDrugs();
        }
    }
}