using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using Klinika.Models;

namespace Klinika.Services
{
    internal class ScheduleService
    {
        public static TimeSlot? GetFirstSlotAvailableUnderTwoHours(int doctorID, int duration = 15)
        {
            DateTime now = new CleanDateTimeNow().cleanNow;
            TimeSlot broadSpan = new TimeSlot(now.AddHours(-24), now.AddHours(24));
            List<TimeSlot> occupied = AppointmentRepository.GetInstance().GetOccupiedTimeSlotsPerDoctor(broadSpan, doctorID);
            TimeSlot slotToSchedule = new TimeSlot(now, now.AddMinutes(duration));
            TimeSlot? firstAvailable = slotToSchedule.GetFirstUnoccupied(occupied);
            if ((firstAvailable.from - now).Minutes > 120) return null;
            return firstAvailable;
        }

        public static List<Rescheduling> GetMostMovableAppointments(int specializationId)
        {
            List<Rescheduling> reschedulings = new List<Rescheduling>();

            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.ID != specializationId) continue;

                List<Appointment> scheduled = AppointmentRepository.GetAll(doctor.ID, User.RoleType.DOCTOR);
                List<TimeSlot> scheduledSlots = new List<TimeSlot>();
                foreach (Appointment appointment in scheduled)
                {
                    scheduledSlots.Add(new TimeSlot(appointment.DateTime, appointment.DateTime.AddMinutes(appointment.Duration)));
                }
                for (int i = 0; i < scheduledSlots.Count; i++)
                {
                    TimeSlot firstUnoccupied = scheduledSlots[i].GetFirstUnoccupied(scheduledSlots, scheduledSlots[i].GetDuration());
                    reschedulings.Add(new Rescheduling(scheduled[i], firstUnoccupied.from));
                }
            }
            return SelectTop5(reschedulings);
        }

        public static List<Rescheduling> SelectTop5(List<Rescheduling> appointmentDatePairs)
        {
            appointmentDatePairs = appointmentDatePairs.OrderBy(o => o.appointment.DateTime).ToList();
            return appointmentDatePairs.Take(5).ToList();
        }
    }
}
