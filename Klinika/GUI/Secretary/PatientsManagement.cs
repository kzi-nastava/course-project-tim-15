using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Exceptions;
using Klinika.Utilities;
using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;

namespace Klinika.GUI.Secretary
{
    public partial class PatientsManagement : Form
    {
        public PatientsManagement()
        {
            InitializeComponent();
        }

        private void DeletePatientButton_Click(object sender, EventArgs e)
        {
            DeletePatient();
        }

        private void AddPatientButton_Click(object sender, EventArgs e)
        {
            new AddPatient(this).Show();
        }

        private void ModifyPatientButton_Click(object sender, EventArgs e)
        {
            ShowModifyPatientForm();
        }

        private void BlockButton_Click(object sender, EventArgs e)
        {
            BlockPatient();
        }

        private void UnblockButton_Click(object sender, EventArgs e)
        {
            UnblockPatient();
        }

        private void UrgentSchedulingButton_Click(object sender, EventArgs e)
        {
            new UrgentScheduling().Show();
        }

        private void DeletePatient()
        {
            DialogResult deletionConfirmation = MessageBoxUtilities.ShowConfirmationMessage("Are you sure you want to delete the selected patient?");
            if (deletionConfirmation == DialogResult.No) return;
            int id = (int)UIUtilities.GetCellValue(patientsTable, "ID");
            try
            {
                PatientService.Delete(id);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                patientsTable.Rows.RemoveAt(selectedRowNumber);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully deleted!");
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetPatientTabButtonsStates()
        {
            modifyPatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
            bool isBlocked = (bool)UIUtilities.GetCellValue(patientsTable, "Blocked");
            if (isBlocked)
            {
                unblockButton.Enabled = true;
                blockButton.Enabled = false;
            }
            else
            {
                unblockButton.Enabled = false;
                blockButton.Enabled = true;
            }
        }

        private void BlockPatient()
        {
            bool blockingConfirmation = UIUtilities.Confirm("Are you sure you want to block the selected patient?");
            if (!blockingConfirmation) return;
            string email = UIUtilities.GetCellValue(patientsTable, "Email").ToString();
            try
            {
                Roles.Patient toBlock = PatientService.GetSingle(email);
                PatientService.Block(toBlock, "SEC");
                ModifyRowOfPatientTable(toBlock);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully blocked!");
                SetPatientTabButtonsStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void UnblockPatient()
        {
            DialogResult unblockingConfirmation = MessageBoxUtilities.ShowConfirmationMessage("Are you sure you want to unblock the selected patient?");
            if (unblockingConfirmation == DialogResult.No) return;
            string email = UIUtilities.GetCellValue(patientsTable, "Email").ToString();
            try
            {
                Roles.Patient toUnblock = PatientService.GetSingle(email);
                PatientService.Unblock(toUnblock);
                ModifyRowOfPatientTable(toUnblock);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully unblocked!");
                SetPatientTabButtonsStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void ShowModifyPatientForm()
        {
            string selectedPatientEmail = UIUtilities.GetCellValue(patientsTable, "Email").ToString();
            Roles.Patient selected = PatientService.GetSingle(selectedPatientEmail);
            new ModifyPatient(this, selected).Show();
        }


    }
}
