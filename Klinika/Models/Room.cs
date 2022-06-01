using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Room
    {
        public int id { get; set; }
        public int type { get; set; }
        public int number { get; set; }

        public Room(int id, int type, int number)
        {
            this.id = id;
            this.type = type;
            this.number = number;
        }

        public override string ToString()
        {
            return $"Room No.{number}";
        }
    }
}
