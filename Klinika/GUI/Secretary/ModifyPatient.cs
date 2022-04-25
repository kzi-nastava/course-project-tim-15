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
            string jmbg = JMBGField.Text.Trim();
            string name = nameField.Text.Trim();
            string surname = surnameField.Text.Trim();
            DateTime birthdate = birthdatePicker.Value.Date;
            string email = emailField.Text;
            string password = passwordField.Text.Trim();
            char gender = genderSelection.SelectedItem.ToString()[0];
            try
            {
                PatientService.Validate(jmbg, name, surname, birthdate, email, password,true);
                PatientService.Modify(selectedID,jmbg, name, surname, birthdate, gender, email, password);
                DataTable patientTable = (DataTable)parent.patientsTable.DataSource;
                int selectedRowIndex = parent.patientsTable.SelectedRows[0].Index;
                DataRow selectedRow = patientTable.Rows[selectedRowIndex];
                selectedRow["JMBG"] = jmbg;
                selectedRow["Name"] = name;
                selectedRow["Surname"] = surname;
                selectedRow["Birthdate"] = birthdate.Date;
                selectedRow["Gender"] = gender;
                selectedRow["Email"] = email;
                patientTable.AcceptChanges();
                MessageBox.Show("Patient successfully modified!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                JMBGField.Text = "";
            }
        }

        private void ModifyPatient_Load(object sender, EventArgs e)
        {
            string selectedEmail = parent.patientsTable.SelectedRows[0].Cells["Email"].Value.ToString();
            (int id, string jmbg, string name, string surname, DateTime birthdate, char gender, string password) =
            PatientService.GetSingle(selectedEmail);
            JMBGField.Text = jmbg;
            nameField.Text = name;
            surnameField.Text = surname;
            birthdatePicker.Value = birthdate;
            if(gender == 'F')
            {
                genderSelection.SelectedItem = "Female";

            }

            if (gender == 'M')
            {
                genderSelection.SelectedItem = "Male";

            }
            emailField.Text = selectedEmail;
            passwordField.Text = password;
            selectedID = id;

        }

    }
}
