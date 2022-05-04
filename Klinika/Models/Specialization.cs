using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Specialization
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Specialization()
        {
            ID = -1;
            Name = "";
        }
        public Specialization(int _id, string _name)
        {
            ID = _id;
            Name = _name;
        }
    }
}
