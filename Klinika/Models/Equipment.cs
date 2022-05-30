using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoomID { get; set; }
        public int Quantity { get; set; }
        public int Spent { get; set; }

        public Equipment(int id, string name, int roomID, int quantity)
        {
            ID = id;
            Name = name;
            RoomID = roomID;
            Quantity = quantity;
            Spent = 0;
        }
    }
}
