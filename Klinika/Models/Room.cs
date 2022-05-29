using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }

        public Room(int id, int type, int number)
        {
            ID = id;
            Type = type;
            Number = number;
        }

        public override string ToString()
        {
            return $"Room No.{Number}";
        }
    }
}
