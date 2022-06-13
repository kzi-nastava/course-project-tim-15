using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Secretary
{
    public partial class ChooseReferral : Form
    {
        private Referrals parent;
        private readonly ReferralService referralService;
        public ChooseReferral(Referrals parent)
        {
            this.parent = parent;
            referralService = StartUp.serviceProvider.GetService<ReferralService>();
            InitializeComponent();
        }

        private void ChooseReferal_Load(object sender, EventArgs e) => InitializeTable();

        private void ChooseReferalButton_Click(object sender, EventArgs e)
        {
            UpdateParentRefferalForm();
            Close();
        }

        private void ReferralsTable_CellClick(object sender, DataGridViewCellEventArgs e) => SetButtonState();

        private void InitializeTable()
        {
            int chosenPatientID = UIUtilities.ExtractID(parent.patientSelection.SelectedItem.ToString());
            try
            {
                referralsTable.Fill(referralService.GetReferralsPerPatient(chosenPatientID));
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetButtonState()
        {
            bool isUsed = Convert.ToBoolean(referralsTable.GetCellValue("Used"));
            if (!isUsed)
            {
                chooseReferalButton.Enabled = true;
            }
            else
            {
                chooseReferalButton.Enabled = false;
            }
        }

        private void UpdateParentRefferalForm()
        {
            parent.SetFieldValues(new Referral(referralsTable.GetCellValue("Doctor").ToString(),
                                              referralsTable.GetCellValue("Specialization").ToString()
                                  ));
            parent.SetCommandStates();
        }
    }
}
