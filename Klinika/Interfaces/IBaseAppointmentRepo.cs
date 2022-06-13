using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IBaseAppointmentRepo
    {
        List<Appointment> GetAll();
    }
}
