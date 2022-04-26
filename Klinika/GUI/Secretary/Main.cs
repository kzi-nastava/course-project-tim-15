using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Data;
using Klinika.Repositories;

namespace Klinika.GUI.Secretary
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }


        private void addPatientButton_Click(object sender, EventArgs e)
        {
            new AddPatient(this).Show();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            DataTable patients = PatientRepository.GetAll();
            if (patients != null)
            {
                patientsTable.DataSource = patients;
                patientsTable.ClearSelection();
            }
            
            updatePatientButton.Enabled = false;
            deletePatientButton.Enabled = false;
        }

        private void patientsTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            updatePatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = MessageBox.Show("Are you sure you want to delete the selected patient? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(deletionConfirmation == DialogResult.Yes)
            {
                string email = patientsTable.SelectedRows[0].Cells["Email"].Value.ToString();
                int ID = PatientRepository.EmailIDPairs[email];
                PatientRepository.Delete(ID,email);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                patientsTable.Rows.RemoveAt(selectedRowNumber);
                MessageBox.Show("Patient successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void updatePatientButton_Click(object sender, EventArgs e)
        {
            new ModifyPatient(this).Show();
        }
    }
}
