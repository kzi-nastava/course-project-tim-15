using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class RoomEquipmentTable : DataGridView
    {
        private List<Equipment> equipment;
        public RoomEquipmentTable() : base()
        {
            equipment = new List<Equipment>();
        }
        public void Fill(List<Equipment> equipments)
        {
            DataTable equipmentData = new DataTable();
            equipmentData.Columns.Add("ID");
            equipmentData.Columns.Add("Name");
            equipmentData.Columns.Add("Quantity");
            equipmentData.Columns.Add("Spent");

            DataSource = equipmentData;
            Columns["ID"].Width = 45;

            equipment = new List<Equipment>();
            foreach (Equipment equipment in equipments) Insert(equipment);

            ClearSelection();
        }
        public void Insert(Equipment equipment)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = equipment.id;
            newRow["Name"] = equipment.name;
            newRow["Quantity"] = equipment.quantity;
            newRow["Spent"] = equipment.spent;
            dt.Rows.Add(newRow);
            this.equipment.Add(equipment);
        }
        public List<Equipment> GetAll() { return equipment; }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public Equipment GetSelected()
        {
            return equipment.Where(x => x.id == GetSelectedID()).First();
        }
        public int DeleteSelected()
        {
            var selected = GetSelectedID();
            Rows.RemoveAt(CurrentRow.Index);
            return selected;
        }
        public void ModifySelected(Equipment equipment)
        {
            SelectedRows[0].SetValues(equipment.id.ToString(),
                equipment.name,
                equipment.quantity,
                equipment.spent);

            this.equipment.Remove(this.equipment.Where(x => x.id == equipment.id).FirstOrDefault());
            this.equipment.Add(equipment);
        }
    }
}
