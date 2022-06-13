using Microsoft.Extensions.DependencyInjection;
using Klinika.Rooms.Services;
using Klinika.Core.Dependencies;
using Klinika.Core.Database;
using Klinika.Core.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class DynamicEquipmentOrdering : Form
    {
        private readonly EquipmentService equipmentService;
        
        public DynamicEquipmentOrdering()
        {
            equipmentService = StartUp.serviceProvider.GetService<EquipmentService>();
            InitializeComponent();
        }

        private void DynamicEquipmentOrdering_Load(object sender, EventArgs e) =>
        missingDynamicEquipmentTable.Fill(equipmentService.GetMissingDynamicEquipment());

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
                equipmentService.MakeEquipmentTransferRequest(Convert.ToInt32(missingDynamicEquipmentTable.GetCellValue("ID")),
                                                          (int)quantityPicker.Value);
                MessageBoxUtilities.ShowSuccessMessage("Selected equipment is ordered and will be stored tomorrow.");

            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void MissingDynamicEquipmentTable_CellClick(object sender, DataGridViewCellEventArgs e) => SetCommandStates(); 
    }
}
