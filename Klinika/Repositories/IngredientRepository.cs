using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class IngredientRepository
    {
        public List<Ingredient> ingredients { get; }

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
            ingredients = GetAll();
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
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    name = ((object[])row)[1].ToString(),
                    type = ((object[])row)[2].ToString()
                };
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
    }
}
