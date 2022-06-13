using Klinika.Appointments.Models;

namespace Klinika.Appointments.Interfaces
{
    public interface IBaseAppointmentRepo
    {
        List<Appointment> GetAll();
    }
}
