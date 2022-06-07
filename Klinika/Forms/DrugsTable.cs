using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class DrugsTable : DataGridView
    {
        private List<Drug> drugs;
        public DrugsTable() : base()
        {
            drugs = new List<Drug>();
        }
        public void Fill(List<Drug> drugs)
        {
            this.drugs = drugs;

            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("ID");
            drugsData.Columns.Add("Name");
            drugsData.Columns.Add("Ingredients");

            foreach (Drug drug in drugs)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["ID"] = drug.id;
                newRow["Name"] = drug.name;
                newRow["Ingredients"] = drug.GetIngredientsAsString();
                drugsData.Rows.Add(newRow);
            }

            DataSource = drugsData;
            Columns[0].Width = 30;
            Columns[1].Width = 90;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            if(SelectedRows.Count == 0) return -1;
            int selectedId = Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
            return selectedId;
        }
        public Drug GetSelectedDrug()
        {
            int selectedID = GetSelectedId();
            if(selectedID == -1) return null;
            return drugs.Where(x => x.id == selectedID).FirstOrDefault();
        }
    }
}
