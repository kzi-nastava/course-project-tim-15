using Klinika.Drugs.Models;
using System.Data;

namespace Klinika.Forms
{
    public class AllergensTable : Base.ViewOnlyTableBase<Ingredient>
    {
        public override void Fill(List<Ingredient> items)
        {
            DataTable allergensData = new DataTable();
            allergensData.Columns.Add("ID");
            allergensData.Columns.Add("Name");
            allergensData.Columns.Add("Type");

            foreach (Ingredient ingredient in items)
            {
                DataRow newRow = allergensData.NewRow();
                newRow["ID"] = ingredient.id;
                newRow["Name"] = ingredient.name;
                newRow["Type"] = ingredient.type;
                allergensData.Rows.Add(newRow);
            }

            DataSource = allergensData;
            Columns[0].Width = 30;
            ClearSelection();
        }
    }
}
