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
using Klinika.Models;
using Klinika.Exceptions;
using Klinika.Utilities;

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
            UIUtilities.Fill(patientsTable, PatientService.GetAll());
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
            string selectedPatientEmail = UIUtilities.GetCellValue(patientsTable, "Email").ToString();
            Roles.Patient selected = PatientService.GetSingle(selectedPatientEmail);
            new ModifyPatient(this,selected).Show();
        }

        private void ShowModificationDetailsForm()
        {
            int selectedRequestId = (int)UIUtilities.GetCellValue(requestsTable, "ID");
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
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetPatientTabButtonsStates()
        {
            updatePatientButton.Enabled = true;
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
            DialogResult blockingConfirmation = MessageBoxUtilities.ShowConfirmationMessage("Are you sure you want to block the selected patient?");
            if (blockingConfirmation == DialogResult.No) return;
            string email = UIUtilities.GetCellValue(patientsTable, "Email").ToString();
            try
            {
                Roles.Patient toBlock = PatientService.GetSingle(email);
                PatientService.Block(toBlock, "SEC");
                ModifyRowOfPatientTable(toBlock);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully blocked!");
                SetPatientTabButtonsStates();
            }
            catch(DatabaseConnectionException error)
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
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void InitializeSelectedTab()
        {
            try
            {
                if (tabs.SelectedTab == requests)
                {
                    UIUtilities.Fill(requestsTable, PatientRequestService.GetAll());
                }
                else if (tabs.SelectedTab == referrals)
                {
                    UIUtilities.FillPatientSelectionList(patientSelection);
                }
                else if (tabs.SelectedTab == equipmentRequests)
                {
                    UIUtilities.Fill(dynamicEquipmentTable, EquipmentService.GetMissingDynamicEquipment());
                }
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void SetRequestsTabButtonStates()
        {
            string modificationType = UIUtilities.GetCellValue(requestsTable, "RequestType").ToString();
            bool isModification = modificationType == "Modify" ? true : false;
       
            if (string.IsNullOrEmpty(UIUtilities.GetCellValue(requestsTable, "Approved").ToString()))
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
            DialogResult approveConfirmation = MessageBoxUtilities.ShowConfirmationMessage("Are you sure you want to approve the selected request?");
            if (approveConfirmation == DialogResult.No) return;

            int requestId = (int)UIUtilities.GetCellValue(requestsTable, "ID");
            try
            {
                PatientRequestService.Approve(requestId);
                string requestType = UIUtilities.GetCellValue(requestsTable, "RequestType").ToString();
                int appointmentId = Convert.ToInt32(UIUtilities.GetCellValue(requestsTable, "ExaminationID"));
                DateTime appointmentStart = DateTime.Parse(UIUtilities.GetCellValue(requestsTable, "DateTime").ToString());

                if (requestType.Equals("Modify"))
                {
                    PatientModificationRequest selected = PatientRequestService.GetModificationRequest(requestId);
                    Appointment modified = AppointmentService.GetById(appointmentId);
                    modified.DoctorID = selected.newDoctorID;
                    modified.DateTime = selected.newAppointment;
                    AppointmentService.Modify(modified);
                    appointmentStart = selected.newAppointment;
                }
                else
                {
                    AppointmentService.Delete(appointmentId);
                }

                ModifyRowOfPatientRequestsTable(true, appointmentStart);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully executed!");
                DisableAllReferalTabButtons();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void DenyPatientRequest()
        {
            DialogResult denyConfirmation = MessageBoxUtilities.ShowConfirmationMessage("Are you sure you want to deny the selected request?");
            if (denyConfirmation == DialogResult.No) return;
            int selectedRequestID = (int)UIUtilities.GetCellValue(requestsTable, "ID");
            try
            {
                PatientRequestService.Deny(selectedRequestID);
                DateTime oldAppointment = DateTime.Parse(UIUtilities.GetCellValue(requestsTable, "DateTime").ToString());
                ModifyRowOfPatientRequestsTable(false, oldAppointment);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully denied!");
                DisableAllReferalTabButtons();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
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
                doctorId = UIUtilities.ExtractID(refferalTabDoctorField.Text);
            }
            
            DateTime chosenTime = appointmentPicker.Value;
            try
            {
                if (!CreateAppointment(doctorId, chosenTime)) return;
                ReferralService.MarkAsUsed(chosenReferralID);
                MessageBoxUtilities.ShowSuccessMessage("Appointment successfully scheduled!");
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private bool CreateAppointment(int doctorId,DateTime appointmentStart)
        {

            string error_message = ValidationUtilities.ValidateAppointment(doctorId, appointmentStart);
            if(error_message != null)
            {
                MessageBoxUtilities.ShowErrorMessage(error_message);
                return false;
            }
            appointmentStart = appointmentStart.AddSeconds(-appointmentStart.Second);

            Appointment newAppointment = new Appointment(-1,
                                            UIUtilities.ExtractID(refferalTabDoctorField.Text),
                                            UIUtilities.ExtractID(patientSelection.SelectedItem.ToString()),
                                            appointmentStart, 1, false, 'E', 15, false, "", false);
            AppointmentService.Create(newAppointment);
            return true;
        }

        private void FindSuitableDoctor()
        {
            try
            {
                Roles.Doctor suitableDoctor = DoctorService.GetSuitable(UIUtilities.ExtractID(specializationField.Text), appointmentPicker.Value);
                if (suitableDoctor != null)
                {
                    refferalTabDoctorField.Text = suitableDoctor.GetIdAndFullName();
                }
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            OrderMissingDynamicEquipment();
            SetEquipmentTabCommandStates(disable: true);
        }

        private void dynamicEquipmentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEquipmentTabCommandStates();
        }

        private void SetEquipmentTabCommandStates(bool disable = false)
        {
            quantityPicker.Value = quantityPicker.Minimum;
            if(!disable)
            {
                quantityPicker.Enabled = true;
                orderButton.Enabled = true;
                return;
            }

            quantityPicker.Enabled = false;
            orderButton.Enabled = false;
            dynamicEquipmentTable.ClearSelection();
        }

        private void OrderMissingDynamicEquipment()
        {
            try
            {
                EquipmentService.MakeEquipmentTransferRequest((int)UIUtilities.GetCellValue(dynamicEquipmentTable, "ID"),
                                                          (int)quantityPicker.Value);
                MessageBoxUtilities.ShowSuccessMessage("Selected equipment is ordered and will be stored tomorrow.");
                
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }
    }

}
