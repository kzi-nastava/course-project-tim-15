using Klinika.Drugs.Models;
using System.Data;

namespace Klinika.Forms
{
    public class DrugsTable : Base.TableBase<Drug>
    {
        private List<Drug> drugs;
        public DrugsTable() : base()
        {
            drugs = new List<Drug>();
        }
        public override void Fill(List<Drug> drugs)
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
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public Drug GetSelectedDrug()
        {
            return drugs.Where(x => x.id == GetSelectedId()).FirstOrDefault();
        }
    }
}
