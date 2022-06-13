using Klinika.Core;
using Klinika.Drugs.Interfaces;
using Klinika.Drugs.Repositories;
using System.Data;

namespace Klinika.Drugs.Services
{
    internal class IngredientService
    {
        private readonly IIngredientRepo ingredientRepo;
        public IngredientService() => ingredientRepo = new IngredientRepository();
        public List<Models.Ingredient> GetAll() => ingredientRepo.GetAll();
        public static void Delete(int id)
        {
            //Repositories.IngredientRepository.Instance.Delete(id);
            //Repositories.IngredientRepository.Reload();
        }
        public static void Modify(Models.Ingredient ingredient)
        {
            if (ingredient.id == -1)
            {
                //Repositories.IngredientRepository.Instance.Create(ingredient);
            }
            else
            {
                //Repositories.IngredientRepository.Instance.Modify(ingredient);
            }
            //Repositories.IngredientRepository.Reload();
        }
        public static List<EnhancedComboBoxItem> GetIngredientList()
        {
            List<EnhancedComboBoxItem> ingredients = new List<EnhancedComboBoxItem>();
            //foreach(Models.Ingredient ingredient in Repositories.IngredientRepository.Instance.ingredients)
            //{
            //    ingredients.Add(new Models.EnhancedComboBoxItem(ingredient.name, ingredient));
            //}
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
