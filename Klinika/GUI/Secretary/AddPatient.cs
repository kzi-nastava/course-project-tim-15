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
using Klinika.Services;
using Klinika.Utilities;

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
            Add();
        }

        private void Add()
        {
            Roles.Patient newPatient = new Roles.Patient(
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
                PatientService.Add(newPatient);
                parent.AddRowToPatientTable(newPatient);
                MessageBoxUtilities.ShowSuccessMessage("Patient successfully added!");
                Close();
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
          
        }
    }
}
