using Klinika.Appointments.Interfaces;
using Klinika.Appointments.Models;

namespace Klinika.Appointments.Services
{
    internal class AppointmentService
    {
        private readonly IAppointmentRepo appointmentRepo;
        public AppointmentService(IAppointmentRepo appointmentRepo) => this.appointmentRepo = appointmentRepo;
        public List<Appointment> GetCompleted(int patientID) => appointmentRepo.GetCompleted(patientID);
        public void Create(Appointment appointment) => appointmentRepo.Create(appointment);
        public void Modify(Appointment appointment) => appointmentRepo.Modify(appointment);
        public void Delete(int id) => appointmentRepo.Delete(id);
        public void Complete(Appointment appointment)
        {
            appointment.completed = true;
            appointmentRepo.Modify(appointment);
        }
        public Appointment GetById(int id) => appointmentRepo.GetAll().Where(x => x.id == id).FirstOrDefault();
    }
}