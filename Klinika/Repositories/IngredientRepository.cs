using Klinika.Data;
using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    public class IngredientRepository
    {
        public List<Ingredient> Ingredients { get; }

        private static IngredientRepository? instance;
        public static IngredientRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IngredientRepository();
                }
                return instance;
            }
        }
        private IngredientRepository()
        {
            Ingredients = GetAll();
        }
        private List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string getIngredientsQuery = "SELECT * FROM [Ingredient]";
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getIngredientsQuery);
            foreach(object row in resoult)
            {
                var ingredient = new Ingredient
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    Name = ((object[])row)[1].ToString(),
                    Type = ((object[])row)[2].ToString()
                };
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
    }
}
