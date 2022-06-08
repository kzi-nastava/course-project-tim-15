using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using System.Data;

namespace Klinika.GUI.Secretary
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PatientsButton_Click(object sender, EventArgs e)
        {
            new PatientsManagement().Show();
        }

        private void PatientsRequestsButton_Click(object sender, EventArgs e)
        {
            new PatientsRequestsManagement().Show();
        }

        private void ReferralsButton_Click(object sender, EventArgs e)
        {
            new Referrals().Show();
        }

        private void DynamicEquipmentOrderingButton_Click(object sender, EventArgs e)
        {
            new DynamicEquipmentOrdering().Show();
        }

        private void DynamicEquipmentTransfersButton_Click(object sender, EventArgs e)
        {
            new LowStockDynamicEquipmentTransfers().Show();
        }
    }

}
