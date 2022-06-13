using Klinika.Appointments.Models;

namespace Klinika.Schedule.Models
{
    internal class Rescheduling
    {
        public Appointment appointment { get; }
        public DateTime to { get; }

        public Rescheduling(Appointment appointment, DateTime to)
        {
            this.appointment = appointment;
            this.to = to;
        }
    }
}
