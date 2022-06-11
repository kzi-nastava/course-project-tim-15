using Klinika.Models;
using Klinika.Services;

namespace Klinika.GUI.Secretary
{
    public partial class LowStockDynamicEquipmentTransfers : Form
    {
        public LowStockDynamicEquipmentTransfers()
        {
            InitializeComponent();
        }

        private void GetFromButton_Click(object sender, EventArgs e)
        {
            EquipmentTransfer newTransfer = new EquipmentTransfer(Convert.ToInt32(lowStockDynamicEquipmentTable.GetCellValue("RoomID")),
            Convert.ToInt32(lowStockDynamicEquipmentTable.GetCellValue("EquipmentID")));
            new Manager.PickDate(newTransfer, true, this).Show();
        }

        private void LowStockDynamicEquipmentTransfers_Load(object sender, EventArgs e)
        {
            lowStockDynamicEquipmentTable.Fill(EquipmentService.GetDynamicEquipmentInRooms());
            lowStockDynamicEquipmentTable.MarkOutOfStock();
        }

        private void LowStockDynamicEquipmentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getFromButton.Enabled = true;
        }

        public void UpdateLowStockDynamicEquipmentTable(EquipmentTransfer transfer)
        {
            lowStockDynamicEquipmentTable.SelectedRows[0].Cells["Quantity"].Value =
            Convert.ToInt32(lowStockDynamicEquipmentTable.SelectedRows[0].Cells["Quantity"].Value) + transfer.quantity;
            lowStockDynamicEquipmentTable.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;

            if (transfer.fromId != 0)
            {
                foreach (DataGridViewRow row in lowStockDynamicEquipmentTable.Rows)
                {
                    if (Convert.ToInt32(row.Cells["RoomID"].Value) != transfer.fromId || Convert.ToInt32(row.Cells["EquipmentID"].Value) != transfer.equipment) continue;
                    row.Cells["Quantity"].Value = Convert.ToInt32(row.Cells["Quantity"].Value) - transfer.quantity;
                    if (Convert.ToInt32(row.Cells["Quantity"].Value) == 0) row.DefaultCellStyle.BackColor = Color.Red;
                    break;
                }
            }
        }

    }
}
