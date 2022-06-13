using Klinika.Users.Models;
using Klinika.Users.Interfaces;
using Klinika.Appointments.Models;
using Klinika.Schedule.Models;

namespace Klinika.Schedule.Services
{
    internal class ScheduleService
    {
        private readonly IScheduledAppointmentsRepo appointmentsRepo;
        private readonly IDoctorRepo doctorRepo;

        public ScheduleService(IScheduledAppointmentsRepo scheduledAppointmentsRepo, IDoctorRepo doctorRepo)
        {
            appointmentsRepo = scheduledAppointmentsRepo;
            this.doctorRepo = doctorRepo;
        }

        public List<Rescheduling> GetMostMovableAppointments(int specializationId)
        {
            List<Rescheduling> reschedulings = new List<Rescheduling>();

            foreach (Doctor doctor in doctorRepo.GetAll())
            {
                if (doctor.specialization.id != specializationId) continue;

                List<Appointment> scheduled = appointmentsRepo.GetAll(doctor.id, User.RoleType.DOCTOR);
                List<TimeSlot> scheduledSlots = new List<TimeSlot>();
                foreach (Appointment appointment in scheduled)
                {
                    scheduledSlots.Add(new TimeSlot(appointment.dateTime, appointment.dateTime.AddMinutes(appointment.duration)));
                }
                for (int i = 0; i < scheduledSlots.Count; i++)
                {
                    TimeSlot firstUnoccupied = scheduledSlots[i].GetFirstUnoccupied(scheduledSlots, scheduledSlots[i].GetDuration());
                    reschedulings.Add(new Rescheduling(scheduled[i], firstUnoccupied.from));
                }
            }
            return SelectTop5(reschedulings);
        }
        public List<Rescheduling> SelectTop5(List<Rescheduling> appointmentDatePairs)
        {
            appointmentDatePairs = appointmentDatePairs.OrderBy(o => o.appointment.dateTime).ToList();
            return appointmentDatePairs.Take(5).ToList();
        }
        public List<Appointment> GetAll() => appointmentsRepo.GetAll();
        public List<Appointment> GetAll(Patient patient) => appointmentsRepo.GetAll(patient.id, User.RoleType.PATIENT);
    }
}
