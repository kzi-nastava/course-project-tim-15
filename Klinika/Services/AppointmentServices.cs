using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    internal class AppointmentServices
    {
        public static List<Appointment> GetRecommended (int doctorID, DateTime fromTime, DateTime untilTime, DateTime lastDate, char priotity)
        {
            List<Appointment> recommended = new List<Appointment>();

            Appointment appointment = TryFindFree(doctorID, fromTime, lastDate);

            if (appointment.DoctorID != -1)
            {
                recommended.Add(appointment);
                return recommended;
            }

            return recommended;
        }

        private static Appointment TryFindFree(int doctorID, DateTime fromTime, DateTime lastDate)
        {
            Appointment appointment = new Appointment();

            int numberOfDays = lastDate.Subtract(DateTime.Now).Days;

            for (int i = 0; i <= numberOfDays; i++)
            {
                DateTime current = DateTime.Now.AddDays(i + 1);
                DateTime requested = new DateTime(current.Year, current.Month, current.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);

                if(!AppointmentRepository.GetInstance().IsOccupied(requested, doctorID))
                {
                    appointment.DoctorID = doctorID;
                    appointment.DateTime = requested;
                    return appointment;
                }
                System.Diagnostics.Debug.WriteLine(requested);
            }
            return appointment;
        }

        private static void FindFreeByPriority (int doctorID, DateTime fromTime, DateTime untilTime, DateTime lastDate, char priotity)
        {
            
        }
    }
}
