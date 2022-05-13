using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class TimeSlot
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public TimeSlot(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        public TimeSlot(DateTime from)
        {
            this.from = from;
            to = from.AddMinutes(15);
        }
    }
}
