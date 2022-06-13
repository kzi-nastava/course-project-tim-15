using Klinika.Exceptions;
using Klinika.Services;
using Klinika.Utilities;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Secretary
{
    public partial class ModifyPatient : Form
    {
        private PatientsManagement parent;
        private Roles.Patient selected;
        private PatientService patientService;
        public ModifyPatient(PatientsManagement parent,Roles.Patient selected)
        {
            this.parent = parent;
            this.selected = selected;
            patientService = StartUp.serviceProvider.GetService<PatientService>();
            InitializeComponent();
        }

        private void modifyButton_Click(object sender, EventArgs e) => Modify();

        private void ModifyPatient_Load(object sender, EventArgs e) => SetFormFieldValues();

        private void SetFormFieldValues()
        {
            jmbgField.Text = selected.jmbg;
            nameField.Text = selected.name;
            surnameField.Text = selected.surname;
            birthdatePicker.Value = selected.birthdate;
            if (selected.gender == 'F')
            {
                genderSelection.SelectedItem = "Female";
            }

            else
            {
                genderSelection.SelectedItem = "Male";
            }
            emailField.Text = selected.email;
            passwordField.Text = selected.password;
        }

        private void Modify()
        {
            Roles.Patient modifiedPatient = new Roles.Patient(
                selected.id,
                jmbgField.Text.Trim(),
                nameField.Text.Trim(),
                surnameField.Text.Trim(),
                birthdatePicker.Value.Date,
                genderSelection.SelectedItem.ToString()[0],
                emailField.Text.Trim(),
                passwordField.Text.Trim(), 
                selected.notificationOffset);
            try
            {
                string error_message = ValidatePatient(modifiedPatient);
                if(error_message != "") 
                {
                    MessageBoxUtilities.ShowErrorMessage(error_message);
                    return;
                }
                patientService.Modify(modifiedPatient);
                parent.ModifyRowOfPatientsTable(modifiedPatient);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully modified!");
                Close();
            }
            catch (DatabaseConnectionException error) 
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        public string? ValidatePatient(Roles.Patient patient)
        {
            string error_messsage = null;
            if (string.IsNullOrEmpty(patient.jmbg))
            {
                error_messsage = "JMBG left empty!";
            }

            else if (patient.jmbg.Length != 13)
            {
                error_messsage = "JMBG format is not valid!";
            }

            else if (string.IsNullOrEmpty(patient.name))
            {
                error_messsage = "Name left empty!";
            }

            else if (string.IsNullOrEmpty(patient.surname))
            {
                error_messsage = "Surname left empty!";
            }

            else if (patient.birthdate > DateTime.Now)
            {
                error_messsage = "Invalid birthdate!";
            }

            else if (string.IsNullOrEmpty(patient.password))
            {
                error_messsage = "Password left empty!";
            }

            else if (patient.password.Length < 4)
            {
                error_messsage = "Password is too short!";
            }

            return error_messsage;

        }
    }
}
