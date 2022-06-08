﻿using System;
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
            bool deletionConfirmation = UIUtilities.Confirm("Are you sure you want to delete the selected patient?");
            if (!deletionConfirmation) return;
            int id = Convert.ToInt32(patientsTable.GetCellValue("ID"));
            try
            {
                PatientService.Delete(id);
                patientsTable.DeleteSelectedRow();
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully deleted!");
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetButtonsStates()
        {
            modifyPatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
            bool isBlocked = Convert.ToBoolean(patientsTable.GetCellValue("Blocked"));
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
            int id = Convert.ToInt32(patientsTable.GetCellValue("ID"));
            try
            {
                Roles.Patient toBlock = (Roles.Patient)PatientService.GetSingle(id);
                PatientService.Block(toBlock, "SEC");
                patientsTable.ModifyRow(patientsTable.GetSelectedRow(),toBlock);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully blocked!");
                SetButtonsStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void UnblockPatient()
        {
            bool unblockingConfirmation = UIUtilities.Confirm("Are you sure you want to unblock the selected patient?");
            if (!unblockingConfirmation) return;
            int id = Convert.ToInt32(patientsTable.GetCellValue("ID"));
            try
            {
                Roles.Patient toUnblock = (Roles.Patient)PatientService.GetSingle(id);
                PatientService.Unblock(toUnblock);
                patientsTable.ModifyRow(patientsTable.GetSelectedRow(),toUnblock);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully unblocked!");
                SetButtonsStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void ShowModifyPatientForm()
        {
            int selectedPatient = Convert.ToInt32(patientsTable.GetCellValue("ID"));
            Roles.Patient selected = (Roles.Patient)PatientService.GetSingle(selectedPatient);
            new ModifyPatient(this, selected).Show();
        }

        public void AddRowToPatientsTable(Roles.Patient newPatient)
        {
            patientsTable.AddRow(newPatient);
        }

        public void ModifyRowOfPatientsTable(Roles.Patient modified)
        {
            patientsTable.ModifyRow(patientsTable.GetSelectedRow(), modified);
        }

        private void PatientsManagement_Load(object sender, EventArgs e)
        {
            patientsTable.Fill(PatientService.GetAll());
        }

        private void PatientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonsStates();
        }
    }
}
