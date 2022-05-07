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
        public static List<Appointment> GetRecommended (int doctorID, DateTime fromTime, DateTime untilTime, DateTime deadlineDate, char priotity)
        {
            List<Appointment> recommended = new List<Appointment>();

            Appointment appointment = TryFindFree(doctorID, fromTime, deadlineDate);

            if (appointment.DoctorID != -1)
            {
                recommended.Add(appointment);
                return recommended;
            }

            appointment = FindFreeByPriority (doctorID, fromTime, untilTime, deadlineDate, priotity);
            if (appointment.DoctorID != -1)
            {
                recommended.Add(appointment);
                return recommended;
            }
            return recommended;
        }

        private static Appointment TryFindFree(int doctorID, DateTime fromTime, DateTime deadlineDate)
        {
            Appointment appointment = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

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

        private static Appointment FindFreeByPriority (int doctorID, DateTime fromTime, DateTime untilTime, DateTime deadlineDate, char priotity)
        {

            List<Appointment> appointments = AppointmentRepository.GetInstance().Appointments.Where(x => x.DateTime > DateTime.Now && x.DateTime < deadlineDate).ToList();
            Appointment recommend = new Appointment();
            Appointment backupForPriorityDoctor = new Appointment();
            Appointment backupForPriorityTime = new Appointment();

            int numberOfDays = deadlineDate.Subtract(DateTime.Now).Days;

            foreach (Appointment appointment in appointments)
            {
                for (int i = 0; i <= numberOfDays; i++)
                {
                    //DateTime requested = appointment.DateTime.AddDays(15);

                    DateTime current = DateTime.Now.AddDays(i + 1);
                    DateTime start = new DateTime(current.Year, current.Month, current.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
                    DateTime end = new DateTime(current.Year, current.Month, current.Day, untilTime.Hour, untilTime.Minute, untilTime.Second);

                    DateTime requested = appointment.DateTime.AddMinutes(15);
                    if (IsBetween(start, end, requested) &&
                        appointment.DoctorID == doctorID &&
                        !AppointmentRepository.GetInstance().IsOccupied(requested, appointment.DoctorID))
                    {
                        recommend.DateTime = requested;
                        recommend.DoctorID = appointment.DoctorID;
                        return recommend;
                    }

                    requested = appointment.DateTime.AddDays(-15);
                    if (IsBetween(start, end, requested) &&
                        appointment.DoctorID == doctorID &&
                        !AppointmentRepository.GetInstance().IsOccupied(requested, appointment.DoctorID))
                    {
                        recommend.DateTime = requested;
                        recommend.DoctorID = appointment.DoctorID;
                        return recommend;
                    }

                    // Doctor priority
                    if (appointment.DoctorID == doctorID && !AppointmentRepository.GetInstance().IsOccupied(requested, appointment.DoctorID))
                    {
                        if (IsMoreAccurate(start, appointment.DateTime, backupForPriorityDoctor.DateTime) || backupForPriorityDoctor.DoctorID == -1)
                        {
                            backupForPriorityDoctor.DateTime = requested;
                            backupForPriorityDoctor.DoctorID = appointment.DoctorID;
                        }
                    }

                    // Time priority
                    if (IsBetween(start, end, requested) && !AppointmentRepository.GetInstance().IsOccupied(requested, appointment.DoctorID) && backupForPriorityTime.DoctorID == -1)
                    {
                        backupForPriorityTime.DateTime = requested;
                        backupForPriorityTime.DoctorID= appointment.DoctorID;
                    }
                }
            }
            if (priotity == 'D')
            {
                return backupForPriorityDoctor;
            }
            return backupForPriorityTime;
        }

        private static bool IsMoreAccurate(DateTime referentDate, DateTime first, DateTime second)
        {
            
            var firstAccuracy = referentDate.Subtract(first);
            firstAccuracy.Subtract(new TimeSpan(firstAccuracy.Days, 0, 0, 0));
            var secondAccuracy = referentDate.Subtract(second);
            secondAccuracy.Subtract(new TimeSpan(secondAccuracy.Days, 0, 0, 0));
            return secondAccuracy > firstAccuracy;
        }

        private static bool IsBetween (DateTime start, DateTime end, DateTime date)
        {
            if (date >= start && date < end)
            {
                return true;
            }
            return false;
        }
    }
}
