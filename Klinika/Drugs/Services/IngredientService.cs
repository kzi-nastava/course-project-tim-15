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
