using Klinika.Models;

namespace Klinika.Interfaces
{
    internal interface IAppointmentRepo : IBaseAppointmentRepo
    {
        List<Appointment> GetCompleted(int PatientID);
        void Create(Appointment appointment);
        void Modify(Appointment appointment);
        void Delete(int ID);
    }
}
