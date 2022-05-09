using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Data;
using Klinika.Repositories;
using Klinika.Models;
using Klinika.Exceptions;
using Klinika.Roles;

namespace Klinika.GUI.Secretary
{
    public partial class mainWindow : Form
    {

        public int  chosenReferralID { get; set; }
        public mainWindow()
        {
            InitializeComponent();
        }


        private void addPatientButton_Click(object sender, EventArgs e)
        {
            new AddPatient(this).Show();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            DataTable patients = PatientRepository.GetAll();
            if (patients != null)
            {
                patientsTable.DataSource = patients;
                patientsTable.ClearSelection();
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to delete the selected patient? This action cannot be undone.");
            if(deletionConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable,"Email").ToString();
                int id = PatientRepository.EmailIDPairs[email];
                PatientRepository.Delete(id,email);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                patientsTable.Rows.RemoveAt(selectedRowNumber);
                SecretaryService.ShowSuccessMessage("Patient successfully deleted!");
            }

        }

        private void updatePatientButton_Click(object sender, EventArgs e)
        {
            new ModifyPatient(this).Show();
        }

        private void patientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updatePatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
            bool isBlocked = Convert.ToBoolean(SecretaryService.GetCellValue(patientsTable, "Blocked"));
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

        private void blockButton_Click(object sender, EventArgs e)
        {
            DialogResult blockingConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to block the selected patient?");
            if (blockingConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable,"Email").ToString();
                int id = PatientRepository.EmailIDPairs[email];
                PatientRepository.Block(id);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                DataRow blockedPatientRow = ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber];
                blockedPatientRow["Blocked"] = true;
                blockedPatientRow["BlockedBy"] = "SEC";
                SecretaryService.ShowSuccessMessage("Patient successfully blocked!");
                unblockButton.Enabled = true;
                blockButton.Enabled = false;
            }
        }

        private void unblockButton_Click(object sender, EventArgs e)
        {
            DialogResult unblockingConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to unblock the selected patient?");
            if (unblockingConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable, "Email").ToString();
                int id = PatientRepository.EmailIDPairs[email];
                PatientRepository.Unblock(id);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                DataRow unblockedPatientRow = ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber];
                unblockedPatientRow["Blocked"] = false;
                unblockedPatientRow["BlockedBy"] = "";
                SecretaryService.ShowSuccessMessage("Patient successfully unblocked!");
                unblockButton.Enabled = false;
                blockButton.Enabled = true;
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabs.SelectedTab == requests)
            {
                requestsTable.DataSource = PatientRequestRepository.GetAll();
                requestsTable.ClearSelection();
            }
            else if(tabs.SelectedTab == referrals)
            {
                SecretaryService.FillPatientSelectionList(patientSelection, PatientRepository.IDPatientPairs);
            }
        }

        private void requestsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string modificationType = SecretaryService.GetCellValue(requestsTable, "RequestType").ToString();
            bool isModification = modificationType == "Modify" ? true:false;
            
            if(string.IsNullOrEmpty(SecretaryService.GetCellValue(requestsTable,"Approved").ToString()))
            {
                if (isModification)
                {
                    detailsButton.Enabled = true;
                }
                else
                {
                    detailsButton.Enabled = false;
                }

                approveButton.Enabled = true;
                denyButton.Enabled = true;
            }

        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            new ModificationRequestDetails(this).Show();
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            DialogResult approveConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to approve the selected request?");
            if (approveConfirmation == DialogResult.Yes)
            {
                int requestID = Convert.ToInt32(SecretaryService.GetCellValue(requestsTable,"ID"));
                PatientRequestRepository.Approve(requestID);
                int selectedRequestIndex = requestsTable.SelectedRows[0].Index;
                DataRow selectedRequest = ((DataTable)requestsTable.DataSource).Rows[selectedRequestIndex];
                selectedRequest["Approved"] = true;
                string requestType = SecretaryService.GetCellValue(requestsTable, "RequestType").ToString();
                int examinationId = Convert.ToInt32(selectedRequest["ExaminationID"]);
                if (requestType.Equals("Modify"))
                {
                    PatientModificationRequest selected = PatientRequestRepository.IdRequestPairs[requestID];
                    selectedRequest["DateTime"] = selected.newAppointment;
                    AppointmentRepository.Modify(examinationId, selected.newDoctorID, selected.newAppointment);
                }
                else
                {
                    AppointmentRepository.Delete(examinationId);
                }
                SecretaryService.ShowSuccessMessage("Request successfully executed!");
                approveButton.Enabled = false;
                denyButton.Enabled = false;
                detailsButton.Enabled = false;
            }
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            DialogResult denyConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to deny the selected request?");
            if (denyConfirmation == DialogResult.Yes)
            {
                int selectedRequestID = Convert.ToInt32(SecretaryService.GetCellValue(requestsTable, "ID"));
                PatientRequestRepository.Deny(selectedRequestID);
                int selectedRequestIndex = requestsTable.SelectedRows[0].Index;
                DataRow selectedRequest = ((DataTable)requestsTable.DataSource).Rows[selectedRequestIndex];
                selectedRequest["Approved"] = false;
                SecretaryService.ShowSuccessMessage("Request successfully denied!");
                approveButton.Enabled = false;
                denyButton.Enabled = false;
                detailsButton.Enabled = false;
            }
        }

        private void patientSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            new ChooseReferral(this).ShowDialog();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                int doctorId = -1;
                if (!string.IsNullOrEmpty(doctorField.Text))
                {
                    doctorId = SecretaryService.ExtractID(doctorField.Text);
                }
                DateTime appointmentStart = appointmentPicker.Value;
              
                ReferralService.Validate(doctorId, appointmentStart);
                ReferalRepository.MarkAsUsed(chosenReferralID);
                int doctorID = SecretaryService.ExtractID(doctorField.Text);
                int patientID = SecretaryService.ExtractID(patientSelection.SelectedItem.ToString());
                DateTime chosenTime = appointmentPicker.Value;
                chosenTime = chosenTime.AddSeconds(-chosenTime.Second);
                Appointment newAppointment = new Appointment(-1, doctorID, patientID, chosenTime, 1, false, 'E', 15, false, "", false);
                AppointmentRepository.GetInstance().Create(newAppointment);
                SecretaryService.ShowSuccessMessage("Appointment successfully scheduled!");
            }
            catch (DateTimeInvalidException)
            { }

            catch(DoctorUnavailableException)
            { }
        }

        private void findAvailableDoctorButton_Click(object sender, EventArgs e)
        {
            string chosenSpecialization = specializationField.Text;
            DateTime chosenTime = appointmentPicker.Value;
            Roles.Doctor suitableDoctor = DoctorService.GetSuitable(chosenSpecialization,chosenTime);
            if(suitableDoctor != null)
            {
                doctorField.Text = suitableDoctor.ID + ". " + suitableDoctor.Name + " " + suitableDoctor.Surname;
            }
        }

    }

}
