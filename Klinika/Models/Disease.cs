using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Disease
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Disease() { }
    }
}
