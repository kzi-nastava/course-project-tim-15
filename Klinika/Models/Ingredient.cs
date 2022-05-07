using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }

        public Ingredient() { }
    }
}
