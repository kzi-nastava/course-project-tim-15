using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Anamnesis
    {
        public int ID { get; set; }
        public int MedicalActionID { get; set; }
        public string? Description { get; set; }
        public string? Symptoms { get; set; }
        public string? Conclusion { get; set; }

        public Anamnesis() { }
    }
}
