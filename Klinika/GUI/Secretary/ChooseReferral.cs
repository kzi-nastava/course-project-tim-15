using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Repositories;
using Klinika.Services;

namespace Klinika.GUI.Secretary
{
    public partial class ChooseReferral : Form
    {
        private mainWindow parent;
        public ChooseReferral(mainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void ChooseReferal_Load(object sender, EventArgs e)
        {
            string chosenPatient = parent.patientSelection.SelectedItem.ToString();
            int chosenPatientID = SecretaryService.ExtractID(chosenPatient);
            referralsTable.DataSource = ReferalRepository.GetReferralsPerPatient(chosenPatientID);
            referralsTable.ClearSelection();
        }

        private void chooseReferalButton_Click(object sender, EventArgs e)
        {
            string chosenDoctor = referralsTable.SelectedRows[0].Cells["Doctor"].Value.ToString();
            string chosenSpecialization = referralsTable.SelectedRows[0].Cells["Specialization"].Value.ToString();
            parent.doctorField.Text = chosenDoctor;
            parent.specializationField.Text = chosenSpecialization;
            parent.chosenReferralID = Convert.ToInt32(referralsTable.SelectedRows[0].Cells["ID"].Value);
            parent.appointmentPicker.Enabled = true;
            if (string.IsNullOrEmpty(chosenDoctor))
            {
                parent.findAvailableDoctorButton.Enabled = true;
            }
            else
            {
                parent.findAvailableDoctorButton.Enabled = false;
            }
            
            Close();
        }

        private void referralsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isUsed = Convert.ToBoolean(referralsTable.SelectedRows[0].Cells["Used"].Value);
            if (!isUsed)
            {
                chooseReferalButton.Enabled = true;
            }
        }
    }
}
