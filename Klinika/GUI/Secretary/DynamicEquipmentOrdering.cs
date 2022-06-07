using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Utilities;
using Klinika.Exceptions;

namespace Klinika.GUI.Secretary
{
    public partial class DynamicEquipmentOrdering : Form
    {
        public DynamicEquipmentOrdering()
        {
            InitializeComponent();
        }

        private void DynamicEquipmentOrdering_Load(object sender, EventArgs e)
        {
            missingDynamicEquipmentTable.Fill(EquipmentService.GetMissingDynamicEquipment());
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            OrderMissingDynamicEquipment();
            SetCommandStates(disable: true);
        }


        private void SetCommandStates(bool disable = false)
        {
            quantityPicker.Value = quantityPicker.Minimum;
            if (!disable)
            {
                quantityPicker.Enabled = true;
                orderButton.Enabled = true;
                return;
            }

            quantityPicker.Enabled = false;
            orderButton.Enabled = false;
            missingDynamicEquipmentTable.ClearSelection();
        }

        private void OrderMissingDynamicEquipment()
        {
            try
            {
                EquipmentService.MakeEquipmentTransferRequest(Convert.ToInt32(missingDynamicEquipmentTable.GetCellValue("ID")),
                                                          (int)quantityPicker.Value);
                MessageBoxUtilities.ShowSuccessMessage("Selected equipment is ordered and will be stored tomorrow.");

            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void MissingDynamicEquipmentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetCommandStates();
        }
    }
}
