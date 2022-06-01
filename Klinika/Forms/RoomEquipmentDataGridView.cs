using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Forms
{
    public class RoomEquipmentDataGridView : DataGridView
    {
        private List<Equipment> Equipment;
        public RoomEquipmentDataGridView() : base()
        {
            Equipment = new List<Equipment>();
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

            Equipment = new List<Equipment>();
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
            Equipment.Add(equipment);
        }
        public List<Equipment> GetAll() { return Equipment; }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public Equipment GetSelected()
        {
            return Equipment.Where(x => x.id == GetSelectedID()).First();
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

            Equipment.Remove(Equipment.Where(x => x.id == equipment.id).FirstOrDefault());
            Equipment.Add(equipment);
        }
    }
}
