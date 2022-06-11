using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class IngredientRepository : Repository
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
        public static IngredientRepository Reload()
        {
            instance = new IngredientRepository();
            return instance;
        }
        private IngredientRepository() : base()
        {
            ingredients = GetAll();
        }
        private List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string getIngredientsQuery = "SELECT * FROM [Ingredient] WHERE IsDeleted = 0";
            var resoult = database.ExecuteSelectCommand(getIngredientsQuery);
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

        public void Delete(int id)
        {
            string deleteQuery = "UPDATE [Ingredient] SET IsDeleted = 1 WHERE ID = @ID";
            database.ExecuteNonQueryCommand(deleteQuery, ("@ID", id));
        }

        public void Create(Ingredient ingredient)
        {
            string createQuery = "INSERT INTO [Ingredient] " +
                "(Name, Type, IsDeleted) " +
                "VALUES (@Name, @Type, 0)";
            database.ExecuteNonQueryCommand(createQuery, ("@Name", ingredient.name), ("@Type", ingredient.type));
        }

        public void Modify(Ingredient ingredient)
        {
            string modifyQuery = "UPDATE [Ingredient] SET Type = @Type, Name = @Name  WHERE ID = @ID";
            database.ExecuteNonQueryCommand(modifyQuery, ("@Type", ingredient.type), ("@Name", ingredient.name), ("@ID", ingredient.id));
        }
    }
}
