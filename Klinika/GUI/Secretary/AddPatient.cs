using Klinika.Core.Database;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Klinika.GUI.Secretary
{
    public partial class AddPatient : Form
    {
        private PatientsManagement parent;
        private readonly PatientService patientService;

        public AddPatient(PatientsManagement parent)
        {
            this.parent = parent;
            patientService = StartUp.serviceProvider.GetService<PatientService>();
            InitializeComponent();
        }

        private void AddPatient_Load(object sender, EventArgs e) => genderSelection.SelectedIndex = 0;

        private void addButton_Click(object sender, EventArgs e) => Add();

        private void Add()
        {
            Users.Models.Patient newPatient = new Users.Models.Patient(
                -1,
                jmbgField.Text.Trim(),
                nameField.Text.Trim(),
                surnameField.Text.Trim(),
                birthdatePicker.Value.Date,
                genderSelection.SelectedItem.ToString()[0],
                emailField.Text.Trim(),
                passwordField.Text.Trim());

            try
            {
                string error_message = ValidatePatient(newPatient);
                if(error_message != "")
                {
                    MessageBoxUtilities.ShowErrorMessage(error_message);
                    return;
                }
                patientService.Add(newPatient);
                parent.AddRowToPatientsTable(newPatient);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully added!");
                Close();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        public string? ValidatePatient(Users.Models.Patient patient)
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

            else if (string.IsNullOrEmpty(patient.email))
            {
                error_messsage = "Email left empty!";
            }

            else if (patientService.GetIdByEmail(patient.email) != null)
            {
                error_messsage = "Email already in use!";
            }

            else if (!IsValidEmail(patient.email))
            {
                error_messsage = "Incorrect email format!";
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
        private bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                             @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
