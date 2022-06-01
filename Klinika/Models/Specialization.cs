using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Specialization
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }

        public Specialization()
        {
            id = -1;
            name = "";
        }
        public Specialization(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}
