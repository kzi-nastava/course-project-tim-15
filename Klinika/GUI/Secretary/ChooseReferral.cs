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
            EnableChooseReferalButton();
        }


        private void InitializeTable()
        {
            string chosenPatient = parent.patientSelection.SelectedItem.ToString();
            int chosenPatientID = SecretaryService.ExtractID(chosenPatient);
            SecretaryService.Fill(referralsTable, ReferalRepository.GetReferralsPerPatient(chosenPatientID));
            referralsTable.ClearSelection();
        }


        private void EnableChooseReferalButton()
        {
            bool isUsed = Convert.ToBoolean(SecretaryService.GetCellValue(referralsTable, "Used"));
            if (!isUsed)
            {
                chooseReferalButton.Enabled = true;
            }
        }


        private void UpdateParentRefferalForm()
        {
            ChosenReferral referral = new ChosenReferral(
                SecretaryService.GetCellValue(referralsTable, "Doctor").ToString(),
                SecretaryService.GetCellValue(referralsTable, "Specialization").ToString(),
                Convert.ToInt32(SecretaryService.GetCellValue(referralsTable, "ID"))
            );

            parent.SetRefferalFormFieldValues(referral);
            parent.SetReferralFormCommandStates();

        }
    }
}
