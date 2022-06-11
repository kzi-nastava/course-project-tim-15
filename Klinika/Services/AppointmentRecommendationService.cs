using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Dependencies;

namespace Klinika.Services
{
    public class AppointmentRecommendationService
    {
        private readonly DoctorScheduleService? scheduleService;
        public AppointmentRecommendationService()
        {
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
        }
        public List<Appointment> Find(int doctorID, TimeSlot timeSlot, DateTime deadlineDate, char priority)
        {
            Appointment bestMatch = FindClosestMatch(doctorID, timeSlot, deadlineDate);

            if (priority == 'D' || bestMatch.IsBetween(timeSlot))
            {
                return new List<Appointment>() { bestMatch };
            }

            List<Appointment> available = new List<Appointment>();
            foreach (User doctor in UserRepository.GetDoctors())
            {
                if (doctor.id == bestMatch.doctorID) continue;
                Appointment personalBest = FindClosestMatch(doctor.id, timeSlot, deadlineDate);
                if (personalBest.IsBetween(timeSlot))
                {
                    return new List<Appointment>() { personalBest };
                }
                available.Add(personalBest);
            }

            List<Appointment> recommended = new List<Appointment>() { bestMatch };
            recommended.Add(FindClosestAvailable(available, timeSlot));
            available.Remove(recommended[1]);
            recommended.Add(FindClosestAvailable(available, timeSlot));

            return recommended;
        }
        
        private Appointment FindClosestMatch(int doctorID, TimeSlot timeSlot, DateTime deadlineDate)
        {
            Appointment best = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

            for (int i = 0; i < numberOfDays + 1; i++)
            {
                DateTime day = DateTime.Now.AddDays(i + 1);
                if (!scheduleService.IsOccupied(doctorID, timeSlot, day))
                {
                    best.doctorID = doctorID;
                    best.dateTime = new DateTime(day.Year, DateTime.Now.Month, day.Day, timeSlot.from.Hour, timeSlot.from.Minute, timeSlot.from.Second);
                    return best;
                }

                Appointment bestMatch = FindBestMatch(timeSlot, GetAppointmentsForDay(doctorID, day));

                if (bestMatch.IsBetween(timeSlot)) return bestMatch;

                if (IsMoreAccurate(timeSlot.from, bestMatch.dateTime, best.dateTime))
                {
                    best = bestMatch;
                }
            }
            return best;
        }
        private Appointment FindBestMatch(TimeSlot timeSlot, List<Appointment> doctorAppointments)
        {
            Appointment bestMatch = new Appointment();

            foreach (Appointment appointment in doctorAppointments)
            {
                for (int i = -15; i <= 15; i += 30)
                {
                    DateTime current = appointment.dateTime.AddMinutes(i);
                    if (appointment.IsBetween(timeSlot, i)
                        && !scheduleService.IsOccupied(current, appointment.doctorID))
                    {
                        bestMatch.doctorID = appointment.doctorID;
                        bestMatch.dateTime = current;
                        return bestMatch;
                    }

                    if (IsMoreAccurate(timeSlot.from, timeSlot.to, bestMatch.dateTime)
                        && !scheduleService.IsOccupied(current, appointment.doctorID))
                    {
                        bestMatch.doctorID = appointment.doctorID;
                        bestMatch.dateTime = current;
                    }
                }
            }
            return bestMatch;
        }
        private List<Appointment> GetAppointmentsForDay(int doctorID, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, 0, 0, 0);

            return AppointmentRepository.GetInstance().appointments.Where(
                x => x.doctorID == doctorID && x.dateTime >= start && x.dateTime < end && !x.isDeleted).ToList();
        }
        private bool IsMoreAccurate(DateTime referentDate, DateTime first, DateTime second)
        {
            first = first.AddDays(referentDate.Day - first.Day);
            var firstAccuracy = referentDate.Subtract(first);
            int firstMinutes = Math.Abs(firstAccuracy.Hours) * 60 + Math.Abs(firstAccuracy.Minutes);

            second = second.AddDays(referentDate.Day - second.Day);
            var secondAccuracy = referentDate.Subtract(second);
            int secondMinutes = Math.Abs(secondAccuracy.Hours) * 60 + Math.Abs(secondAccuracy.Minutes);

            return secondMinutes > firstMinutes;
        }
        private Appointment FindClosestAvailable(List<Appointment> available, TimeSlot timeSlot)
        {
            Appointment best = available[0];
            for (int i = 1; i < available.Count; i++)
            {
                if (IsMoreAccurate(timeSlot.from, available[i].dateTime, best.dateTime))
                {
                    best = available[i];
                }
            }
            return best;
        }
    }
}