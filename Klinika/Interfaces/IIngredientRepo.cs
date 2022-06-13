using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IIngredientRepo
    {
        List<Ingredient> GetAll();
        void Delete(int id);
        void Create(Ingredient ingredient);
        void Modify(Ingredient ingredient);
    }
}
