using Klinika.Models;
using System.Data;
using Klinika.Roles;
using Klinika.Forms.Base;

namespace Klinika.Forms
{
    public class LowStockDynamicEquipmentTable : TableBase<Equipment>
    {
        public override void Fill(List<Equipment> lowStockDynamicEquipment)
        {
            DataTable lowStockDynamicEquipmentTable = new DataTable();
            lowStockDynamicEquipmentTable.Columns.Add("RoomID");
            lowStockDynamicEquipmentTable.Columns.Add("Room number");
            lowStockDynamicEquipmentTable.Columns.Add("EquipmentID");
            lowStockDynamicEquipmentTable.Columns.Add("Name");
            lowStockDynamicEquipmentTable.Columns.Add("Quantity");

            foreach (Equipment equipment in lowStockDynamicEquipment)
            {
                DataRow newRow = lowStockDynamicEquipmentTable.NewRow();
                newRow["RoomID"] = equipment.roomID;
                newRow["Room number"] = equipment.roomNumber;
                newRow["EquipmentID"] = equipment.id;
                newRow["Name"] = equipment.name;
                newRow["Quantity"] = equipment.quantity;

                lowStockDynamicEquipmentTable.Rows.Add(newRow);
            }
            DataSource = lowStockDynamicEquipmentTable;
            ClearSelection();
        }

        public DataGridViewRow GetSelectedRow()
        {
            return CurrentRow;
        }

        public void DeleteSelectedRow()
        {
            Rows.RemoveAt(CurrentRow.Index);
        }

        public void MarkOutOfStock()
        {
            foreach (DataGridViewRow row in Rows)
            {
                if (Convert.ToInt32(row.Cells["Quantity"].Value) > 0) continue;
                row.DefaultCellStyle.BackColor = Color.Red;
            }

        }
    }
}
