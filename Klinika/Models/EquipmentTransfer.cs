using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class EquipmentTransfer
    {
        public int fromId;
        public int maxQuantity;
        public int toId;
        public int quantity;
        public string equipment;
        public EquipmentTransfer()
        {
            fromId = -1;
            toId = -1;
        }
    }
}
