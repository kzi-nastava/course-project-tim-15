using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class MedicalRecord
    {
        public int ID { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? BloodType { get; set; }
        public List<Anamnesis> Anamneses { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Allergen> Allergens { get; set; }

        public MedicalRecord() { }
    }
}
