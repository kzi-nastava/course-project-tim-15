using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class PatientsRequestsManagement : Form
    {
        public PatientsRequestsManagement()
        {
            InitializeComponent();
        }

        private void RequestsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonStates();
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            new ModificationRequestDetails(PatientRequestService.GetModificationRequest((int)requestsTable.GetCellValue("ID"))).Show();
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            ApprovePatientRequest();
        }

        private void DenyButton_Click(object sender, EventArgs e)
        {
            DenyPatientRequest();
        }

        private void SetButtonStates()
        {
            string modificationType = requestsTable.GetCellValue("Type").ToString();
            bool isModification = modificationType == "Modify" ? true : false;

            if (string.IsNullOrEmpty(requestsTable.GetCellValue("Approved").ToString()))
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
            bool approveConfirmation = UIUtilities.Confirm("Are you sure you want to approve the selected request?");
            if (!approveConfirmation) return;

            int requestId = (int)requestsTable.GetCellValue("ID");
            PatientRequest selected = PatientRequestService.GetRequest(requestId);
            try
            {
                PatientRequestService.Approve(requestId);
                string requestType = requestsTable.GetCellValue("Type").ToString();
                int appointmentId = (int)requestsTable.GetCellValue("Appointment ID");
                
                if (requestType.Equals("Modify"))
                {
                    PatientModificationRequest modificationSelected = PatientRequestService.GetModificationRequest(requestId);
                    Appointment modified = AppointmentService.GetById(appointmentId);
                    modified.doctorID = modificationSelected.newDoctorID;
                    modified.dateTime = modificationSelected.newAppointment;
                    AppointmentService.Modify(modified);
                }
                else
                {
                    AppointmentService.Delete(appointmentId);
                }

                selected.approved = true;
                ModifyRowOfPatientRequestsTable(selected);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully executed!");
                DisableAllButtons();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void DenyPatientRequest()
        {
            bool denyConfirmation = UIUtilities.Confirm("Are you sure you want to deny the selected request?");
            if (!denyConfirmation) return;
            int requestId = (int)requestsTable.GetCellValue("ID");
            PatientRequest selected = PatientRequestService.GetRequest(requestId);
            try
            {
                PatientRequestService.Deny(requestId);
                ModifyRowOfPatientRequestsTable(selected);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully denied!");
                DisableAllButtons();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void DisableAllButtons()
        {
            approveButton.Enabled = false;
            denyButton.Enabled = false;
            detailsButton.Enabled = false;
        }

        private void ModifyRowOfPatientRequestsTable(PatientRequest request)
        {
            requestsTable.ModifyRow(requestsTable.GetSelectedRow(), request);
        }


    }
}
