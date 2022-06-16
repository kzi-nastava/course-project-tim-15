using System.Data;
using Klinika.Rooms.Models;

namespace Klinika.Forms
{
    public class EquipmentTable : Base.TableBase<Equipment>
    {
        private List<Equipment> equipments;
        public EquipmentTable() : base()
        {
            equipments = new List<Equipment>();
        }
        public override void Fill(List<Equipment> equipments)
        {
            this.equipments = equipments;

            DataTable equipmentData = new DataTable();
            equipmentData.Columns.Add("ID");
            equipmentData.Columns.Add("Name");
            equipmentData.Columns.Add("RoomID");
            equipmentData.Columns.Add("roomNumber");
            equipmentData.Columns.Add("quantity");
            equipmentData.Columns.Add("spent");

            foreach (Equipment equipment in equipments)
            {
                DataRow newRow = equipmentData.NewRow();
                newRow["ID"] = equipment.id;
                newRow["Name"] = equipment.type;
                newRow["RoomID"] = equipment.roomID;
                newRow["roomNumber"] = equipment.roomNumber;
                newRow["quantity"] = equipment.quantity;
                newRow["spent"] = equipment.spent;
                equipmentData.Rows.Add(newRow);
            }

            DataSource = equipmentData;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public Equipment GetSelectedIngredient()
        {
            return equipments.Where(x => x.id == GetSelectedId()).FirstOrDefault();
        }
    }
}
