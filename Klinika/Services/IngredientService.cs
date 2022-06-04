using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
