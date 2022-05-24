using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class Rescheduling
    {
        public Appointment appointment { get; }
        public DateTime to { get; }

        public Rescheduling(Appointment appointment,DateTime to)
        {
            this.appointment = appointment;
            this.to = to;
        }
    }
}
