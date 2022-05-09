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
            else if (IsBetween(
                new DateTime(bestMatch.DateTime.Year, bestMatch.DateTime.Month, bestMatch.DateTime.Day, fromTime.Hour, fromTime.Minute, fromTime.Second),
                new DateTime(bestMatch.DateTime.Year, bestMatch.DateTime.Month, bestMatch.DateTime.Day, untilTime.Hour, untilTime.Minute, untilTime.Second),
                bestMatch.DateTime))
            {
                recommended.Add(bestMatch);
                return recommended;
            }

            List<Appointment> available = new List<Appointment>();
            User removeDoctor = doctors.Where(x => x.ID == doctorID).FirstOrDefault();
            doctors.Remove(removeDoctor);

            foreach(User doctor in doctors)
            {
                Appointment personalBest = FindBest(doctor.ID, fromTime, untilTime, deadlineDate);

                if(IsBetween(
                    new DateTime(personalBest.DateTime.Year, personalBest.DateTime.Month, personalBest.DateTime.Day, fromTime.Hour, fromTime.Minute, fromTime.Second),
                    new DateTime(personalBest.DateTime.Year, personalBest.DateTime.Month, personalBest.DateTime.Day, untilTime.Hour, untilTime.Minute, untilTime.Second),
                    personalBest.DateTime))
                {
                    recommended.Add(personalBest);
                    return recommended;
                }

                available.Add(personalBest);
            }

            Appointment firstGood = FindBestAvailable(available, fromTime);
            available.Remove(firstGood);
            Appointment secondGood = FindBestAvailable(available, fromTime);

            recommended.Add(bestMatch);
            recommended.Add(firstGood);
            recommended.Add(secondGood);

            return recommended;
        }
        private static Appointment FindBest(int doctorID, DateTime fromTime, DateTime untilTime, DateTime deadlineDate)
        {
            Appointment best = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

            for(int i = 0; i < numberOfDays +1; i++)
            {
                DateTime day = DateTime.Now.AddDays(i + 1);
                DateTime start = new DateTime(day.Year, day.Month, day.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                DateTime end = new DateTime(day.Year, day.Month, day.Day, untilTime.Hour, untilTime.Minute, untilTime.Second);

                List<Appointment> doctorAppointmentsForCurrentTimeSpan = AppointmentRepository.GetInstance().Appointments.Where(
                    x => x.DoctorID == doctorID && x.DateTime >= start && x.DateTime < end && !x.IsDeleted).ToList();

                // if the doctor does not have an appointment for the current day in the given time period
                if (doctorAppointmentsForCurrentTimeSpan.Count == 0)
                {
                    best.DoctorID = doctorID;
                    best.DateTime = new DateTime(day.Year, DateTime.Now.Month, day.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                    return best;
                }
                else
                {
                    start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
                    end = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, 0, 0, 0);

                    List<Appointment> doctorAppointmentsForCurrentDate = AppointmentRepository.GetInstance().Appointments.Where(
                     x => x.DoctorID == doctorID && x.DateTime >= start && x.DateTime < end && !x.IsDeleted).ToList();

                    Appointment bestMatch = FindBestMatch(fromTime, untilTime, doctorAppointmentsForCurrentDate);

                    DateTime from = new DateTime(day.Year, DateTime.Now.Month, day.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                    DateTime until = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, fromTime.Hour, fromTime.Minute, fromTime.Second);

                    if (IsBetween(
                        new DateTime(bestMatch.DateTime.Year, bestMatch.DateTime.Month, bestMatch.DateTime.Day, fromTime.Hour, fromTime.Minute, fromTime.Second),
                        new DateTime(bestMatch.DateTime.Year, bestMatch.DateTime.Month, bestMatch.DateTime.Day, untilTime.Hour, untilTime.Minute, untilTime.Second),
                        bestMatch.DateTime))
                    {
                        return bestMatch;
                    }
                    else
                    {
                        if(IsMoreAccurate(from, bestMatch.DateTime, best.DateTime))
                        {
                            best = bestMatch;
                        }
                    }
                }
            }
            return best;
        }

        private static Appointment FindBestMatch(DateTime fromTime, DateTime untilTime, List<Appointment> doctorAppointments)
        {
            Appointment bestMatch = new Appointment();

            foreach (Appointment appointment in doctorAppointments)
            {
                //DateTime start = new DateTime(requestedDate.Year, requestedDate.Month, requestedDate.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                DateTime start = new DateTime(appointment.DateTime.Year, appointment.DateTime.Month, appointment.DateTime.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                DateTime end = new DateTime(appointment.DateTime.Year, appointment.DateTime.Month, appointment.DateTime.Day, untilTime.Hour, untilTime.Minute, untilTime.Second);

                DateTime current = appointment.DateTime.AddMinutes(-15);

                if (IsBetween(start, end, current) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                    return bestMatch;
                }

                if (IsMoreAccurate(start, current, bestMatch.DateTime) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                }

                current = appointment.DateTime.AddMinutes(15);

                if (IsBetween(start, end, current) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
                {
                    bestMatch.DoctorID = appointment.DoctorID;
                    bestMatch.DateTime = current;
                    return bestMatch;
                }
                
                if (IsMoreAccurate(start, current, bestMatch.DateTime) && !AppointmentRepository.GetInstance().IsOccupied(current, appointment.DoctorID))
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
        private static bool IsBetween(DateTime start, DateTime end, DateTime date)
        {
            if (date >= start && date < end)
            {
                return true;
            }
            return false;
        }
        private static Appointment FindBestAvailable(List<Appointment> available, DateTime fromTime)
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
