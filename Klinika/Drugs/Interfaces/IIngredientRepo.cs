using Klinika.Drugs.Models;

namespace Klinika.Drugs.Interfaces
{
    public interface IIngredientRepo
    {
        List<Ingredient> GetAll();
        void Delete(int id);
        void Create(Ingredient ingredient);
        void Modify(Ingredient ingredient);
    }
}
