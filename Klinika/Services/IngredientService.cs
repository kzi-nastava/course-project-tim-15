using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Klinika.Services
{
    internal class IngredientService
    {
        public static List<Models.Ingredient> GetAll()
        {
            return Repositories.IngredientRepository.Instance.ingredients;
        }
        public static void Delete(int id)
        {
            Repositories.IngredientRepository.Instance.Delete(id);
            Repositories.IngredientRepository.Reload();
        }
        public static void Modify(Models.Ingredient ingredient)
        {
            if(ingredient.id == -1)
            {
                Repositories.IngredientRepository.Instance.Create(ingredient);
            }
            else
            {
                Repositories.IngredientRepository.Instance.Modify(ingredient);
            }
            Repositories.IngredientRepository.Reload();
        }
        public static List<Models.EnhancedComboBoxItem> GetIngredientList()
        {
            List<Models.EnhancedComboBoxItem> ingredients = new List<Models.EnhancedComboBoxItem>();
            foreach(Models.Ingredient ingredient in Repositories.IngredientRepository.Instance.ingredients)
            {
                ingredients.Add(new Models.EnhancedComboBoxItem(ingredient.name, ingredient));
            }
            return ingredients;
        }

        public static bool CheckTable(DataTable table, int id)
        {
            foreach (DataRow dataRow in table.Rows)
            {
                if (dataRow["id"].ToString() == id.ToString())
                    return false;
            }
            return true;
        }
    }
}
