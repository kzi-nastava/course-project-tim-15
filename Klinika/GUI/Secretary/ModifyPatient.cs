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
            Modify();            
        }

        private void ModifyPatient_Load(object sender, EventArgs e)
        {
            ShowSelectedPatientData();
        }

        private void ShowSelectedPatientData()
        {
            string selectedEmail = SecretaryService.GetCellValue(parent.patientsTable, "Email").ToString();
            Roles.Patient selectedPatient = PatientRepository.GetSingle(selectedEmail);
            SetFormFieldValues(selectedPatient);
            selectedID = selectedPatient.ID;
        }

        private void SetFormFieldValues(Roles.Patient selectedPatient)
        {
            jmbgField.Text = selectedPatient.jmbg;
            nameField.Text = selectedPatient.Name;
            surnameField.Text = selectedPatient.Surname;
            birthdatePicker.Value = selectedPatient.birthdate;
            if (selectedPatient.gender == 'F')
            {
                genderSelection.SelectedItem = "Female";
            }

            else
            {
                genderSelection.SelectedItem = "Male";
            }
            emailField.Text = selectedPatient.Email;
            passwordField.Text = selectedPatient.Password;
        }


        private void Modify()
        {
            Roles.Patient modifiedPatient = new Roles.Patient(
                selectedID,
                jmbgField.Text.Trim(),
                nameField.Text.Trim(),
                surnameField.Text.Trim(),
                birthdatePicker.Value.Date,
                genderSelection.SelectedItem.ToString()[0],
                emailField.Text.Trim(),
                passwordField.Text.Trim());
            try
            {
                PatientRepository.Modify(modifiedPatient);
            }
            catch (FieldEmptyException) { }

            catch (BirthdateInvalidException) { }

            catch (JMBGFormatInvalidException)
            {
                jmbgField.Text = "";
            }

            parent.ModifyRowOfPatientTable(modifiedPatient);
            SecretaryService.ShowSuccessMessage("Patient successfully modified!");
            Close();
        }

    }
}
