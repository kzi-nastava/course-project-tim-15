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
    public partial class ModifyPatient : Form
    {

        private mainWindow parent;
        private int selectedID;
        public ModifyPatient(mainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            string jmbg = jmbgField.Text.Trim();
            string name = nameField.Text.Trim();
            string surname = surnameField.Text.Trim();
            DateTime birthdate = birthdatePicker.Value.Date;
            string email = emailField.Text;
            string password = passwordField.Text.Trim();
            char gender = genderSelection.SelectedItem.ToString()[0];
            Roles.Patient modifiedPatient = new Roles.Patient(selectedID, jmbg, name, surname, birthdate, gender, email, password);
            try
            {
                PatientService.Validate(modifiedPatient,isModification:true);
                PatientRepository.Modify(modifiedPatient);
                DataTable patientTable = (DataTable)parent.patientsTable.DataSource;
                int selectedRowIndex = parent.patientsTable.SelectedRows[0].Index;
                DataRow selectedRow = patientTable.Rows[selectedRowIndex];
                SecretaryService.ModifyRowOfPatientTable(ref selectedRow, modifiedPatient);
                patientTable.AcceptChanges();
                SecretaryService.ShowSuccessMessage("Patient successfully modified!");
                Hide();
            }
            catch (FieldEmptyException)
            {

            }
            catch (BirthdateInvalidException)
            {

            }

            catch (JMBGFormatInvalidException)
            {
                jmbgField.Text = "";
            }
        }

        private void ModifyPatient_Load(object sender, EventArgs e)
        {
            string selectedEmail = SecretaryService.GetCellValue(parent.patientsTable,"Email").ToString();
            Roles.Patient selectedPatient = PatientRepository.GetSingle(selectedEmail);
            jmbgField.Text = selectedPatient.jmbg;
            nameField.Text = selectedPatient.Name;
            surnameField.Text = selectedPatient.Surname;
            birthdatePicker.Value = selectedPatient.birthdate;
            if(selectedPatient.gender == 'F')
            {
                genderSelection.SelectedItem = "Female";
            }

            else
            {
                genderSelection.SelectedItem = "Male";
            }
            emailField.Text = selectedEmail;
            passwordField.Text = selectedPatient.Password;
            selectedID = selectedPatient.ID;

        }

    }
}
