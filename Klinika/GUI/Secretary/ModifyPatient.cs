﻿using Klinika.Exceptions;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class ModifyPatient : Form
    {
        private mainWindow parent;
        private Roles.Patient selected;

        public ModifyPatient(mainWindow parent,Roles.Patient selected)
        {
            this.parent = parent;
            this.selected = selected;
            InitializeComponent();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            Modify();            
        }

        private void ModifyPatient_Load(object sender, EventArgs e)
        {
            SetFormFieldValues();
        }

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
                PatientService.Modify(modifiedPatient);
                parent.ModifyRowOfPatientTable(modifiedPatient);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully modified!");
                Close();
            }
            catch (DatabaseConnectionException error) 
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

    }
}
