﻿using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class AppointmentRecommendationService
    {
        public static List<Appointment> Find(int doctorID, TimeSlot timeSlot, DateTime deadlineDate, char priority)
        {
            Appointment bestMatch = FindClosestMatch(doctorID, timeSlot, deadlineDate);

            if (priority == 'D' || bestMatch.IsBetween(timeSlot))
            {
                return new List<Appointment>() { bestMatch };
            }

            List<Appointment> available = new List<Appointment>();
            foreach (User doctor in UserRepository.GetDoctors())
            {
                if (doctor.ID == bestMatch.DoctorID) continue;
                Appointment personalBest = FindClosestMatch(doctor.ID, timeSlot, deadlineDate);
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
        
        private static Appointment FindClosestMatch(int doctorID, TimeSlot timeSlot, DateTime deadlineDate)
        {
            Appointment best = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

            for (int i = 0; i < numberOfDays + 1; i++)
            {
                DateTime day = DateTime.Now.AddDays(i + 1);
                if (!DoctorService.IsOccupied(doctorID, timeSlot, day))
                {
                    best.DoctorID = doctorID;
                    best.DateTime = new DateTime(day.Year, DateTime.Now.Month, day.Day, timeSlot.from.Hour, timeSlot.from.Minute, timeSlot.from.Second);
                    return best;
                }

                Appointment bestMatch = FindBestMatch(timeSlot, GetAppointmentsForDay(doctorID, day));

                if (bestMatch.IsBetween(timeSlot)) return bestMatch;

                if (IsMoreAccurate(timeSlot.from, bestMatch.DateTime, best.DateTime))
                {
                    best = bestMatch;
                }
            }
            return best;
        }
        private static Appointment FindBestMatch(TimeSlot timeSlot, List<Appointment> doctorAppointments)
        {
            Appointment bestMatch = new Appointment();

            foreach (Appointment appointment in doctorAppointments)
            {
                for (int i = -15; i <= 15; i += 30)
                {
                    DateTime current = appointment.DateTime.AddMinutes(i);
                    if (appointment.IsBetween(timeSlot, i)
                        && !DoctorService.IsOccupied(current, appointment.DoctorID))
                    {
                        bestMatch.DoctorID = appointment.DoctorID;
                        bestMatch.DateTime = current;
                        return bestMatch;
                    }

                    if (IsMoreAccurate(timeSlot.from, timeSlot.to, bestMatch.DateTime)
                        && !DoctorService.IsOccupied(current, appointment.DoctorID))
                    {
                        bestMatch.DoctorID = appointment.DoctorID;
                        bestMatch.DateTime = current;
                    }
                }
            }
            return bestMatch;
        }
        private static List<Appointment> GetAppointmentsForDay(int doctorID, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime end = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, 0, 0, 0);

            return AppointmentRepository.GetInstance().Appointments.Where(
                x => x.DoctorID == doctorID && x.DateTime >= start && x.DateTime < end && !x.IsDeleted).ToList();
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
        private static Appointment FindClosestAvailable(List<Appointment> available, TimeSlot timeSlot)
        {
            Appointment best = available[0];
            for (int i = 1; i < available.Count; i++)
            {
                if (IsMoreAccurate(timeSlot.from, available[i].DateTime, best.DateTime))
                {
                    best = available[i];
                }
            }
            return best;
        }
    }
}