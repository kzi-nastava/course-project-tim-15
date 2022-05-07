using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Drug
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Approved { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string GetIngredientsAsString()
        {
            return string.Join(", ", Ingredients.Select(x => x.Name));
        }

        public Drug()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
