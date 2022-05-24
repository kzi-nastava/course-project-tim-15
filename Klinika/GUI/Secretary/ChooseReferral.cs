using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Repositories;
using Klinika.Services;
using Klinika.Models;
using Klinika.Exceptions;

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
            int chosenPatientID = UIService.ExtractID(parent.patientSelection.SelectedItem.ToString());
            try
            {
                UIService.Fill(referralsTable, ReferalRepository.GetReferralsPerPatient(chosenPatientID));
                referralsTable.ClearSelection();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void SetButtonState()
        {
            bool isUsed = Convert.ToBoolean(UIService.GetCellValue(referralsTable, "Used"));
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
                UIService.GetCellValue(referralsTable, "Doctor").ToString(),
                UIService.GetCellValue(referralsTable, "Specialization").ToString(),
                Convert.ToInt32(UIService.GetCellValue(referralsTable, "ID"))
            );

            parent.SetRefferalTabFieldValues(referral);
            parent.SetReferralTabCommandStates();
        }
    }
}
