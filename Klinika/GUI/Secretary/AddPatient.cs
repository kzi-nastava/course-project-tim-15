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
using Klinika.Repositories;
using Klinika.Services;

namespace Klinika.GUI.Secretary
{
    public partial class AddPatient : Form
    {
        private mainWindow parent;
        public AddPatient(mainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

       

        private void AddPatient_Load(object sender, EventArgs e)
        {
            genderSelection.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string jmbg = jmbgField.Text.Trim();
            string name = nameField.Text.Trim();
            string surname = surnameField.Text.Trim();
            DateTime birthdate = birthdatePicker.Value;
            string email = emailField.Text.Trim(); 
            string password = passwordField.Text.Trim();
            char gender = genderSelection.SelectedItem.ToString()[0];
            Roles.Patient newPatient = new Roles.Patient(-1, jmbg, name, surname, birthdate, gender, email, password);
            try
            {
                PatientService.Validate(newPatient);
                PatientRepository.Create(newPatient);
                DataTable patientTable = (DataTable)parent.patientsTable.DataSource;
                SecretaryService.AddRowToPatientTable(ref patientTable, newPatient);
                SecretaryService.ShowSuccessMessage("Patient successfully added!");
                Close();
            }
            catch (FieldEmptyException)
            {

            }
            catch (BirthdateInvalidException)
            {

            }
            catch (ExistingEmailException)
            {
                emailField.Text = "";
            }
            catch (EmailFormatInvalidException)
            {
                emailField.Text = "";
            }

            catch (JMBGFormatInvalidException)
            {
                jmbgField.Text = "";
            }
        }
    }
}
