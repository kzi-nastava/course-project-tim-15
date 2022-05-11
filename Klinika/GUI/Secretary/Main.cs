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
            SecretaryService.Fill(patientsTable, PatientRepository.GetAll());
            patientsTable.ClearSelection();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            DeletePatient();
        }

        private void updatePatientButton_Click(object sender, EventArgs e)
        {
            new ModifyPatient(this).Show();
        }

        private void patientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetPatientTabButtonsStates(); 
        }

        private void blockButton_Click(object sender, EventArgs e)
        {
            BlockPatient();
        }

        private void unblockButton_Click(object sender, EventArgs e)
        {
            UnblockPatient();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSelectedTab();
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
                if (!string.IsNullOrEmpty(refferalTabDoctorField.Text))
                {
                    doctorId = SecretaryService.ExtractID(refferalTabDoctorField.Text);
                }
                DateTime appointmentStart = appointmentPicker.Value;
              
                ReferralService.Validate(doctorId, appointmentStart);
                ReferalRepository.MarkAsUsed(chosenReferralID);
                int doctorID = SecretaryService.ExtractID(refferalTabDoctorField.Text);
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
                refferalTabDoctorField.Text = suitableDoctor.ID + ". " + suitableDoctor.Name + " " + suitableDoctor.Surname;
            }
        }

        public void SetRefferalFormFieldValues(ChosenReferral referral)
        {
            refferalTabDoctorField.Text = referral.chosenDoctor;
            specializationField.Text = referral.chosenSpecialization;
            chosenReferralID = referral.chosenReferralId;
        }


        public void SetReferralFormCommandStates()
        {
            string chosenDoctor = refferalTabDoctorField.Text;
            appointmentPicker.Enabled = true;
            scheduleButton.Enabled = true;
            if (string.IsNullOrEmpty(chosenDoctor))
            {
                findAvailableDoctorButton.Enabled = true;
            }
            else
            {
                findAvailableDoctorButton.Enabled = false;
            }
        }


        public void AddRowToPatientTable(Roles.Patient newPatient)
        {
            DataTable patients = (DataTable)patientsTable.DataSource;
            DataRow newRow = patients.NewRow();
            ModifyRowOfPatientTable(ref newRow, newPatient);
            patientsTable.Rows.Add(newRow);
            patients.AcceptChanges();
        }

        public void ModifyRowOfPatientTable(ref DataRow row, Roles.Patient patient)
        {
            row["JMBG"] = patient.jmbg;
            row["Name"] = patient.Name;
            row["Surname"] = patient.Surname;
            row["Birthdate"] = patient.birthdate.Date;
            row["Gender"] = patient.gender;
            row["Email"] = patient.Email;
            row["Blocked"] = patient.IsBlocked;
            row["BlockedBy"] = patient.whoBlocked;

        }

        public void ModifyRowOfPatientTable(Roles.Patient patient)
        {
            DataTable patientsData = (DataTable)patientsTable.DataSource;
            int selectedRowIndex = patientsTable.SelectedRows[0].Index;
            DataRow selectedRow = patientsData.Rows[selectedRowIndex];
            ModifyRowOfPatientTable(ref selectedRow, patient);  
        }


        private void DeletePatient()
        {
            DialogResult deletionConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to delete the selected patient? This action cannot be undone.");
            if (deletionConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable, "Email").ToString();
                PatientRepository.Delete(PatientRepository.EmailIDPairs[email], email);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                patientsTable.Rows.RemoveAt(selectedRowNumber);
                SecretaryService.ShowSuccessMessage("Patient successfully deleted!");
            }
        }

        private void SetPatientTabButtonsStates()
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

        private void BlockPatient()
        {
            DialogResult blockingConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to block the selected patient?");
            if (blockingConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable, "Email").ToString();
                int id = PatientRepository.EmailIDPairs[email];
                
                Roles.Patient toBlock = PatientRepository.IDPatientPairs[id];
                toBlock.Block("SEC");
                ModifyRowOfPatientTable(toBlock);
                SecretaryService.ShowSuccessMessage("Patient successfully blocked!");
                SetPatientTabButtonsStates();
            }
        }


        private void UnblockPatient()
        {
            DialogResult unblockingConfirmation = SecretaryService.ShowConfirmationMessage("Are you sure you want to unblock the selected patient?");
            if (unblockingConfirmation == DialogResult.Yes)
            {
                string email = SecretaryService.GetCellValue(patientsTable, "Email").ToString();
                int id = PatientRepository.EmailIDPairs[email];
                Roles.Patient toUnblock = PatientRepository.IDPatientPairs[id];
                toUnblock.Unblock();
                ModifyRowOfPatientTable(toUnblock);
                SecretaryService.ShowSuccessMessage("Patient successfully unblocked!");
                SetPatientTabButtonsStates();
            }
        }


        private void InitializeSelectedTab()
        {
            if (tabs.SelectedTab == requests)
            {
                requestsTable.DataSource = PatientRequestRepository.GetAll();
                requestsTable.ClearSelection();
            }
            else if (tabs.SelectedTab == referrals)
            {
                SecretaryService.FillPatientSelectionList(patientSelection, PatientRepository.IDPatientPairs);
            }
        }
}

}
