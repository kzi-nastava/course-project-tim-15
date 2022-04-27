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

        private void patientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updatePatientButton.Enabled = true;
            deletePatientButton.Enabled = true;
            if (Convert.ToBoolean(patientsTable.SelectedRows[0].Cells["Blocked"].Value) == true)
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

        private void blockButton_Click(object sender, EventArgs e)
        {
            DialogResult blockingConfirmation = MessageBox.Show("Are you sure you want to block the selected patient?", "Block", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (blockingConfirmation == DialogResult.Yes)
            {
                string email = patientsTable.SelectedRows[0].Cells["Email"].Value.ToString();
                int ID = PatientRepository.EmailIDPairs[email];
                PatientRepository.Block(ID);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber]["Blocked"] = true;
                ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber]["BlockedBy"] = "SEC";
                MessageBox.Show("Patient successfully blocked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unblockButton.Enabled = true;
                blockButton.Enabled = false;
            }
        }

        private void unblockButton_Click(object sender, EventArgs e)
        {
            DialogResult unblockingConfirmation = MessageBox.Show("Are you sure you want to unblock the selected patient?", "Unblock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (unblockingConfirmation == DialogResult.Yes)
            {
                string email = patientsTable.SelectedRows[0].Cells["Email"].Value.ToString();
                int ID = PatientRepository.EmailIDPairs[email];
                PatientRepository.Unblock(ID);
                int selectedRowNumber = patientsTable.CurrentCell.RowIndex;
                ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber]["Blocked"] = false;
                ((DataTable)patientsTable.DataSource).Rows[selectedRowNumber]["BlockedBy"] = "";
                MessageBox.Show("Patient successfully unblocked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unblockButton.Enabled = false;
                blockButton.Enabled = true;
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabs.SelectedTab == requests)
            {
                requestsTable.DataSource = RequestsRepository.GetAll();
                requestsTable.ClearSelection();
            }
        }

        private void requestsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            bool isModification = requestsTable.SelectedRows[0].Cells["RequestType"].Value.ToString() == "Modify" ? true:false;
            
            if(string.IsNullOrEmpty(requestsTable.SelectedRows[0].Cells["Approved"].Value.ToString()))
            {
                if (isModification)
                {
                    detailsButton.Enabled = true;
                }
                else
                {
                    detailsButton.Enabled = false;
                }

                allowButton.Enabled = true;
                denyButton.Enabled = true;
            }
            else
            {
                bool isApproved = Convert.ToBoolean(requestsTable.SelectedRows[0].Cells["Approved"].Value);
                if (isModification)
                {
                    detailsButton.Enabled = true;
                }
                else
                {
                    detailsButton.Enabled = false;
                }
            }
        }
    }
}
