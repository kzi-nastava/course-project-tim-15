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

namespace Klinika.GUI.Secretary
{
    public partial class ChooseReferal : Form
    {
        private mainWindow parent;
        public ChooseReferal(mainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void ChooseReferal_Load(object sender, EventArgs e)
        {
            string chosenPatient = parent.patientSelection.SelectedItem.ToString();
            int chosenPatientID = Convert.ToInt32(chosenPatient.Split('.')[0]);
            referralsTable.DataSource = ReferalRepository.GetReferralsPerPatient(chosenPatientID);
        }
    }
}
