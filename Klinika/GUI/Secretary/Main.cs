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
            UIService.Fill(patientsTable, PatientRepository.GetAll());
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

        private void modifyPatientButton_Click(object sender, EventArgs e)
        {
            ShowModifyPatientForm();
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
            SetRequestsTabButtonStates();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            ShowModificationDetailsForm();
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            ApprovePatientRequest();
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            DenyPatientRequest();
        }

        private void patientSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            new ChooseReferral(this).ShowDialog();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            ScheduleAppointmentThroughReferral();
        }

        private void findAvailableDoctorButton_Click(object sender, EventArgs e)
        {
            FindSuitableDoctor();
        }

        private void urgentSchedulingButton_Click(object sender, EventArgs e)
        {
            new UrgentScheduling().Show();
        }

        private void ShowModifyPatientForm()
        {
            string selectedPatientEmail = UIService.GetCellValue(patientsTable, "Email").ToString();
            Roles.Patient selected = PatientService.GetSingle(selectedPatientEmail);
            new ModifyPatient(this,selected).Show();
        }

        private void ShowModificationDetailsForm()
        {
            int selectedRequestId = (int)UIService.GetCellValue(requestsTable, "ID");
            PatientModificationRequest selected = PatientRequestService.GetModificationRequest(selectedRequestId);
            new ModificationRequestDetails(selected).Show();
        }

        public void SetRefferalTabFieldValues(ChosenReferral referral)
        {
            refferalTabDoctorField.Text = referral.chosenDoctor;
            specializationField.Text = referral.chosenSpecialization;
            chosenReferralID = referral.chosenReferralId;
        }

        public void SetReferralTabCommandStates()
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
            patients.Rows.Add(newRow);
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
            DialogResult deletionConfirmation = UIService.ShowConfirmationMessage("Are you sure you want to delete the selected patient? ");
            if (deletionConfirmation == DialogResult.No) return;
            string email = UIService.GetCellValue(patientsTable, "Email").ToString();
            PatientRepository.Delete(PatientRepository.EmailIDPairs[email], email);
            int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
            patientsTable.Rows.RemoveAt(selectedRowNumber);
            UIService.ShowSuccessMessage("Patient successfully deleted!");
        }

        private void SetPatientTabButtonsStates()
        {
            updatePatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
            bool isBlocked = Convert.ToBoolean(UIService.GetCellValue(patientsTable, "Blocked"));
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
            DialogResult blockingConfirmation = UIService.ShowConfirmationMessage("Are you sure you want to block the selected patient?");
            if (blockingConfirmation == DialogResult.No) return;
            string email = UIService.GetCellValue(patientsTable, "Email").ToString();                
            Roles.Patient toBlock = PatientRepository.IDPatientPairs[PatientRepository.EmailIDPairs[email]];
            PatientService.Block(toBlock,"SEC");
            ModifyRowOfPatientTable(toBlock);
            UIService.ShowSuccessMessage("Patient successfully blocked!");
            SetPatientTabButtonsStates();
        }

        private void UnblockPatient()
        {
            DialogResult unblockingConfirmation = UIService.ShowConfirmationMessage("Are you sure you want to unblock the selected patient?");
            if (unblockingConfirmation == DialogResult.No) return;
            string email = UIService.GetCellValue(patientsTable, "Email").ToString();
            int id = PatientRepository.EmailIDPairs[email];
            Roles.Patient toUnblock = PatientRepository.IDPatientPairs[id];
            PatientService.Unblock(toUnblock);
            ModifyRowOfPatientTable(toUnblock);
            UIService.ShowSuccessMessage("Patient successfully unblocked!");
            SetPatientTabButtonsStates();
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
                UIService.FillPatientSelectionList(patientSelection);
            }
        }

        private void SetRequestsTabButtonStates()
        {
            string modificationType = UIService.GetCellValue(requestsTable, "RequestType").ToString();
            bool isModification = modificationType == "Modify" ? true : false;
       
            if (string.IsNullOrEmpty(UIService.GetCellValue(requestsTable, "Approved").ToString()))
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
            else
            {
                approveButton.Enabled = false;
                denyButton.Enabled = false;
            }
        }

        private void ApprovePatientRequest()
        {
            DialogResult approveConfirmation = UIService.ShowConfirmationMessage("Are you sure you want to approve the selected request?");
            if (approveConfirmation == DialogResult.No) return;

            int requestId = Convert.ToInt32(UIService.GetCellValue(requestsTable, "ID"));
            PatientRequestRepository.Approve(requestId);
            string requestType = UIService.GetCellValue(requestsTable, "RequestType").ToString();
            int examinationId = Convert.ToInt32(UIService.GetCellValue(requestsTable,"ExaminationID"));
            DateTime appointment = DateTime.Parse(UIService.GetCellValue(requestsTable, "DateTime").ToString());

            if (requestType.Equals("Modify"))
            {
                PatientModificationRequest selected = PatientRequestService.GetModificationRequest(requestId);
                appointment = selected.newAppointment;
                AppointmentRepository.Modify(examinationId, selected.newDoctorID, selected.newAppointment);
            }
            else
            {
                AppointmentRepository.Delete(examinationId);
            }

            ModifyRowOfPatientRequestsTable(true, appointment);
            UIService.ShowSuccessMessage("Request successfully executed!");
            DisableAllReferalTabButtons();
        }

        private void DenyPatientRequest()
        {
            DialogResult denyConfirmation = UIService.ShowConfirmationMessage("Are you sure you want to deny the selected request?");
            if (denyConfirmation == DialogResult.No) return;
            int selectedRequestID = Convert.ToInt32(UIService.GetCellValue(requestsTable, "ID"));
            PatientRequestRepository.Deny(selectedRequestID);
            DateTime oldAppointment = DateTime.Parse(UIService.GetCellValue(requestsTable, "DateTime").ToString());
            ModifyRowOfPatientRequestsTable(false, oldAppointment);
            UIService.ShowSuccessMessage("Request successfully denied!");
            DisableAllReferalTabButtons();
        }

        private void DisableAllReferalTabButtons()
        {
            approveButton.Enabled = false;
            denyButton.Enabled = false;
            detailsButton.Enabled = false;
        }

        private void ModifyRowOfPatientRequestsTable(bool isApproved,DateTime newAppointment)
        {
            int selectedRequestIndex = requestsTable.SelectedRows[0].Index;
            DataRow selectedRequest = ((DataTable)requestsTable.DataSource).Rows[selectedRequestIndex];
            selectedRequest["Approved"] = isApproved;
            selectedRequest["DateTime"] = newAppointment;
        }

        private void ScheduleAppointmentThroughReferral()
        {
            int doctorId = -1;
            if (!string.IsNullOrEmpty(refferalTabDoctorField.Text))
            {
                doctorId = UIService.ExtractID(refferalTabDoctorField.Text);
            }
            
            DateTime chosenTime = appointmentPicker.Value;
            if (CreateAppointment(doctorId, chosenTime))
            {
                ReferalRepository.MarkAsUsed(chosenReferralID);
                UIService.ShowSuccessMessage("Appointment successfully scheduled!");
            }
        }

        private bool CreateAppointment(int doctorId,DateTime appointmentStart)
        {
            try
            {
                string error_message = ValidationService.ValidateAppointment(doctorId, appointmentStart);
                if(error_message != null)
                {
                    UIService.ShowErrorMessage(error_message);
                    return false;
                }
                appointmentStart = appointmentStart.AddSeconds(-appointmentStart.Second);

                Appointment newAppointment = new Appointment(-1,
                                                UIService.ExtractID(refferalTabDoctorField.Text),
                                                UIService.ExtractID(patientSelection.SelectedItem.ToString()),
                                                appointmentStart, 1, false, 'E', 15, false, "", false);
                AppointmentRepository.GetInstance().Create(newAppointment);
                return true;
            }
            catch(DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }

            return false;
        }

        private void FindSuitableDoctor()
        {
            Roles.Doctor suitableDoctor = DoctorService.GetSuitable(UIService.ExtractID(specializationField.Text), appointmentPicker.Value);
            if (suitableDoctor != null)
            {
                refferalTabDoctorField.Text = suitableDoctor.ID + ". " + suitableDoctor.Name + " " + suitableDoctor.Surname;
            }
        }

    }

}
