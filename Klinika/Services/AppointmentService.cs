using Klinika.Models;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class AppointmentService
    {
        private readonly IAppointmentRepo appointmentRepo;
        public AppointmentService(IAppointmentRepo appointmentRepo) => this.appointmentRepo = appointmentRepo;
        public List<Appointment> GetCompleted(int patientID) => appointmentRepo.GetCompleted(patientID);
        public void Create(Appointment appointment) => appointmentRepo.Create(appointment);
        public void Modify(Appointment appointment) => appointmentRepo.Modify(appointment);
        public void Delete(int id)
        {
            appointmentRepo.Delete(id);
            //AppointmentRepository.Delete(id);
            //AppointmentRepository.GetInstance().DeleteFromList(id); ?????
        }
        public void Complete(Appointment appointment)
        {
            appointment.completed = true;
            appointmentRepo.Modify(appointment);
        }
        public Appointment GetById(int id) => appointmentRepo.GetAll().Where(x => x.id == id).FirstOrDefault();
    }
}