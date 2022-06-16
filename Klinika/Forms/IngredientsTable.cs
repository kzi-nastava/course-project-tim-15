using System.Data;
using Klinika.Drugs.Models;

namespace Klinika.Forms
{
    public class IngredientsTable : Base.TableBase<Ingredient>
    {
        private List<Ingredient> ingredients;
        public IngredientsTable() : base()
        {
            ingredients = new List<Ingredient>();
        }
        public override void Fill(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;

            DataTable ingredientsData = new DataTable();
            ingredientsData.Columns.Add("ID");
            ingredientsData.Columns.Add("Name");
            ingredientsData.Columns.Add("Type");

            foreach (Ingredient ingredient in ingredients)
            {
                DataRow newRow = ingredientsData.NewRow();
                newRow["ID"] = ingredient.id;
                newRow["Name"] = ingredient.name;
                newRow["Type"] = ingredient.type;
                ingredientsData.Rows.Add(newRow);
            }

            DataSource = ingredientsData;
            //Columns[0].Width = 30;
            //Columns[1].Width = 90;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public Ingredient GetSelectedIngredient()
        {
            return ingredients.Where(x => x.id == GetSelectedId()).FirstOrDefault();
        }
    }
}
