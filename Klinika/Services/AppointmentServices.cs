using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    internal class AppointmentServices
    {
        
        #region Recomended Appointments
        public static List<Appointment> FindRecommended(int doctorID, DateTime fromTime, DateTime untilTime, DateTime deadlineDate, char priority)
        {
            List<Appointment> recommended = new List<Appointment>();

            List<User> doctors = UserRepository.GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.DOCTOR.ToString()).ToList();

            Appointment bestMatch = FindBest(doctorID, fromTime, untilTime, deadlineDate);
            if (priority == 'D')
            {
                recommended.Add(bestMatch);
                return recommended;
            }

            bool isInSelectedTime = bestMatch.IsBetween(fromTime, untilTime);

            if (isInSelectedTime)
            {
                recommended.Add(bestMatch);
                return recommended;
            }

            List<Appointment> available = new List<Appointment>();
            doctors.Remove(doctors.Where(x => x.ID == doctorID).FirstOrDefault());

            foreach (User doctor in doctors)
            {
                Appointment personalBest = FindBest(doctor.ID, fromTime, untilTime, deadlineDate);

                if (personalBest.IsBetween(fromTime, untilTime))
                {
                    recommended.Add(personalBest);
                    return recommended;
                }

                available.Add(personalBest);
            }

            Appointment firstGood = FindClosestAvailable(available, fromTime);
            available.Remove(firstGood);
            Appointment secondGood = FindClosestAvailable(available, fromTime);

            recommended.Add(bestMatch);
            recommended.Add(firstGood);
            recommended.Add(secondGood);

            return recommended;
        }
        private static bool IsDoctorAvailable(int doctorID, DateTime fromTime, DateTime untilTime, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, untilTime.Hour, untilTime.Minute, untilTime.Second);

            List<Appointment> ForSelectedTimeSpan = AppointmentRepository.GetInstance().Appointments.Where(
                x => x.DoctorID == doctorID && x.DateTime >= start && x.DateTime < end && !x.IsDeleted).ToList();

            if (ForSelectedTimeSpan.Count == 0) return true;
            return false;
        }
        private static Appointment FindBest(int doctorID, DateTime fromTime, DateTime untilTime, DateTime deadlineDate)
        {
            Appointment best = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

            for(int i = 0; i < numberOfDays +1; i++)
            {
                DateTime day = DateTime.Now.AddDays(i + 1);
                if (IsDoctorAvailable(doctorID, fromTime, untilTime, day))
                {
                    best.DoctorID = doctorID;
                    best.DateTime = new DateTime(day.Year, DateTime.Now.Month, day.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                    return best;
                }

                Appointment bestMatch = FindBestMatch(fromTime, untilTime, GetAppointmentsForDay(doctorID, day));

                bool isInSelectedTime = bestMatch.IsBetween(fromTime, untilTime);

                if (isInSelectedTime) return bestMatch;

                if (IsMoreAccurate(fromTime, bestMatch.DateTime, best.DateTime))
                {
                    best = bestMatch;
                }
            }
            return best;
        }
        private static List<Appointment> GetAppointmentsForDay(int doctorID, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, 0, 0, 0);

            return AppointmentRepository.GetInstance().Appointments.Where(
                x => x.DoctorID == doctorID && x.DateTime >= start && x.DateTime < end && !x.IsDeleted).ToList();
        }

        private static Appointment FindBestMatch(DateTime fromTime, DateTime untilTime, List<Appointment> doctorAppointments)
        {
            Appointment bestMatch = new Appointment();

            foreach (Appointment appointment in doctorAppointments)
            {
                DateTime current = appointment.DateTime.AddMinutes(-15);

                if (appointment.IsBetween(fromTime, untilTime, -15) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                    return bestMatch;
                }

                if (IsMoreAccurate(fromTime, untilTime, bestMatch.DateTime) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                }

                current = appointment.DateTime.AddMinutes(15);

                if (appointment.IsBetween(fromTime, untilTime, 15) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                    return bestMatch;
                }
                
                if (IsMoreAccurate(fromTime, untilTime, bestMatch.DateTime) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                }
            }
            return bestMatch;
        }
        private static bool IsMoreAccurate(DateTime referentDate, DateTime first, DateTime second)
        {
            first = first.AddDays(referentDate.Day - first.Day);
            var firstAccuracy = referentDate.Subtract(first);
            int firstMinutes = Math.Abs(firstAccuracy.Hours) * 60 + Math.Abs(firstAccuracy.Minutes);

            second = second.AddDays(referentDate.Day - second.Day);
            var secondAccuracy = referentDate.Subtract(second);
            int secondMinutes = Math.Abs(secondAccuracy.Hours) * 60 + Math.Abs(secondAccuracy.Minutes);

            return secondMinutes > firstMinutes;
        }
        private static Appointment FindClosestAvailable(List<Appointment> available, DateTime fromTime)
        {
            Appointment best = available[0];
            for (int i = 1; i < available.Count; i++)
            {
                if (IsMoreAccurate(fromTime, available[i].DateTime, best.DateTime))
                {
                    best = available[i];
                }
            }
            return best;
        }
        #endregion
    }
}
