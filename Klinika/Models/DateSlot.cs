using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class DateSlot
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public DateSlot(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
