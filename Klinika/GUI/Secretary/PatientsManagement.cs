using Klinika.Core.Database;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Secretary
{
    public partial class PatientsManagement : Form
    {
        private readonly PatientService patientService;
        
        public PatientsManagement()
        {
            patientService = StartUp.serviceProvider.GetService<PatientService>();
            InitializeComponent();
        }

        private void DeletePatientButton_Click(object sender, EventArgs e) => DeletePatient();

        private void AddPatientButton_Click(object sender, EventArgs e) => new AddPatient(this).Show();

        private void ModifyPatientButton_Click(object sender, EventArgs e) => ShowModifyPatientForm();

        private void BlockButton_Click(object sender, EventArgs e) => BlockPatient();

        private void UnblockButton_Click(object sender, EventArgs e) => UnblockPatient();

        private void UrgentSchedulingButton_Click(object sender, EventArgs e) => new UrgentScheduling().Show();

        private void DeletePatient()
        {
            bool deletionConfirmation = UIUtilities.Confirm("Are you sure you want to delete the selected patient?");
            if (!deletionConfirmation) return;
            int id = Convert.ToInt32(patientsTable.GetCellValue("ID"));
            try
            {
                patientService.Delete(id);
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
                Users.Models.Patient toBlock = (Users.Models.Patient)patientService.GetSingle(id);
                patientService.Block(toBlock, "SEC");
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
                Users.Models.Patient toUnblock = (Users.Models.Patient)patientService.GetSingle(id);
                patientService.Unblock(toUnblock);
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
            Users.Models.Patient selected = (Users.Models.Patient)patientService.GetSingle(selectedPatient);
            new ModifyPatient(this, selected).Show();
        }

        public void AddRowToPatientsTable(Users.Models.Patient newPatient) => patientsTable.AddRow(newPatient);

        public void ModifyRowOfPatientsTable(Users.Models.Patient modified) => patientsTable.ModifyRow(patientsTable.GetSelectedRow(), modified);

        private void PatientsManagement_Load(object sender, EventArgs e) => patientsTable.Fill(patientService.GetAll());

        private void PatientsTable_CellClick(object sender, DataGridViewCellEventArgs e) => SetButtonsStates();
    }
}
