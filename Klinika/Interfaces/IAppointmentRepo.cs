using Klinika.Models;

namespace Klinika.Interfaces
{
    internal interface IAppointmentRepo
    {
        List<Appointment> GetAll();
        List<Appointment> GetCompleted(int PatientID);

        void Create(Appointment appointment);
        void Modify(Appointment appointment);
        void Delete(int ID);

        List<string> GetDescriptions(int patientID);
    }
}
