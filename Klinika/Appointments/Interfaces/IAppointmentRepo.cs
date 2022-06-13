using Klinika.Appointments.Models;

namespace Klinika.Appointments.Interfaces
{
    internal interface IAppointmentRepo : IBaseAppointmentRepo
    {
        List<Appointment> GetCompleted(int PatientID);
        void Create(Appointment appointment);
        void Modify(Appointment appointment);
        void Delete(int ID);
    }
}
