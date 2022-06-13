namespace Klinika.Drugs.Models
{
    public class Drug
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? approved { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public Drug()
        {
            ingredients = new List<Ingredient>();
        }

        public string GetIngredientsAsString()
        {
            return string.Join(", ", ingredients.Select(x => x.name));
        }
    }
}
