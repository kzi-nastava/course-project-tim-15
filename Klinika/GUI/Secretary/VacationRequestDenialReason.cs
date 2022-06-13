using Klinika.Core.Utilities;
using Klinika.Requests.Models;

namespace Klinika.GUI.Secretary
{
    public partial class VacationRequestDenialReason : Form
    {
        private VacationRequest selected;
        public VacationRequestDenialReason(VacationRequest selected)
        {
            this.selected = selected;
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e) => Confirm();

        private void Confirm()
        {
            if(denialReasonField.Text == "")
            {
                MessageBoxUtilities.ShowErrorMessage("Please fill the reason for denial field!");
                return;
            }
            selected.denyReason = denialReasonField.Text;
            Close();
        }
    }
}
