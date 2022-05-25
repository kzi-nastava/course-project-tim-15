using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Models;
using Klinika.Exceptions;
using Klinika.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class ChooseReferral : Form
    {
        private mainWindow parent;
        public ChooseReferral(mainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void ChooseReferal_Load(object sender, EventArgs e)
        {
            InitializeTable();
        }

        private void chooseReferalButton_Click(object sender, EventArgs e)
        {
            UpdateParentRefferalForm();
            Close();
        }

        private void referralsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonState();
        }

        private void InitializeTable()
        {
            int chosenPatientID = UIUtilities.ExtractID(parent.patientSelection.SelectedItem.ToString());
            try
            {
                UIUtilities.Fill(referralsTable, ReferralService.GetReferralsPerPatient(chosenPatientID));
                referralsTable.ClearSelection();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetButtonState()
        {
            bool isUsed = Convert.ToBoolean(UIUtilities.GetCellValue(referralsTable, "Used"));
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
            ChosenReferral referral = new ChosenReferral(
                                                        UIUtilities.GetCellValue(referralsTable, "Doctor").ToString(),
                                                        UIUtilities.GetCellValue(referralsTable, "Specialization").ToString(),
                                                        Convert.ToInt32(UIUtilities.GetCellValue(referralsTable, "ID"))
            );

            parent.SetRefferalTabFieldValues(referral);
            parent.SetReferralTabCommandStates();
        }
    }
}
