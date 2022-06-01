using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class DrugsDataGridView : CustomTable<Drug>
    {
        public DrugsDataGridView() : base() { }
        protected override void CreateTable()
        {
            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("ID");
            drugsData.Columns.Add("Name");
            drugsData.Columns.Add("Ingredients");
            DataSource = drugsData;
            //Columns[0].Width = 30;
            //Columns[1].Width = 90;
        }
        public override void Fill(List<Drug> items)
        {
            DataTable drugsData = (DataTable)DataSource;
            foreach (Drug drug in items)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["ID"] = drug.id;
                newRow["Name"] = drug.name;
                newRow["Ingredients"] = drug.GetIngredientsAsString();
                drugsData.Rows.Add(newRow);
            }
            ClearSelection();
        }
        public override int GetSelectedID()
        {
            if (SelectedRows.Count == 0) return -1;
            int selectedId = Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
            return selectedId;
        }
        public override Drug GetSelected()
        {
            int selectedID = GetSelectedID();
            if (selectedID == -1) return null;
            return items.Where(x => x.id == selectedID).FirstOrDefault();
        }

        public override int DeleteSelected()
        {
            throw new NotImplementedException();
        }
        public override void Insert(Drug item)
        {
            throw new NotImplementedException();
        }
        public override void ModifySelected(Drug item)
        {
            throw new NotImplementedException();
        }

    }
}
