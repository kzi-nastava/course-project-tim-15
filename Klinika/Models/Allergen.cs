using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Allergen
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }

        public Allergen() { }
    }
}
