using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Renovation
    {
        public int id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public int advanced { get; set; }
        public int secondId { get; set; }
        public int secondType { get; set; }
        public int secondNumber { get; set; }
    }
}
