using Klinika.Forms.Base;
using Klinika.Rooms.Models;
using System.Data;

namespace Klinika.Forms
{
    public class MissingDynamicEquipmentTable : TableBase<Equipment>
    {
        public override void Fill(List<Equipment> missingDynamicEquipment)
        {
            DataTable missingDynamicEquipmentTable = new DataTable();
            missingDynamicEquipmentTable.Columns.Add("ID");
            missingDynamicEquipmentTable.Columns.Add("Name");

            foreach (Equipment equipment in missingDynamicEquipment)
            {
                DataRow newRow = missingDynamicEquipmentTable.NewRow();
                newRow["ID"] = equipment.id;
                newRow["Name"] = equipment.name;

                missingDynamicEquipmentTable.Rows.Add(newRow);
            }
            DataSource = missingDynamicEquipmentTable;
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
    }
}
