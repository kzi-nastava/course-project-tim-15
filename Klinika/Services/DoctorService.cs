using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Models;
using System.Data;

namespace Klinika.Services
{
    internal class DoctorService
    {
        private DoctorRepository doctorRepository { get; }
        public AppointmentRepository appointmentRepository { get; }
        public TimeSlotRepository timeSlotRepository { get; }

        public DoctorService()
        {
            doctorRepository = DoctorRepository.GetInstance();
            appointmentRepository = AppointmentRepository.GetInstance();
            timeSlotRepository = TimeSlotRepository.GetInstance();
        }

        public (Doctor?,TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            List<Doctor> allDoctors = doctorRepository.doctors; 
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.specialization.ID == specializationId)
                {
                    TimeSlot? firstAvailable = GetFirstAvailableUnderTwoHours(doctor.ID);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                    
                }
            }
            return (null,null);
        }

        public TimeSlot? GetFirstAvailableUnderTwoHours(int doctorID, int duration = 15)
        {
            DateTime now = new CleanDateTimeNow().now;
            TimeSlot broadSpan = new TimeSlot(now.AddHours(-24), now.AddHours(24));
            List<TimeSlot> occupied = timeSlotRepository.GetOccupiedTimeSlotsPerDoctor(broadSpan, doctorID);
            TimeSlot slotToSchedule = new TimeSlot(now, now.AddMinutes(duration));
            TimeSlot? firstAvailable = slotToSchedule.GetFirstUnoccupied(occupied);
            if ((firstAvailable.from - now).Minutes > 120) return null;
            return firstAvailable;
        }


        public Dictionary<Appointment, DateTime> GetMostMovableAppointments(int specializationId, int duration)
        {
            Dictionary<Appointment, DateTime> appointmentRescheduleDatePairs = new Dictionary<Appointment, DateTime>();

            foreach (Doctor doctor in doctorRepository.doctors)
            {
                if (doctor.specialization.ID != specializationId) continue;

                CleanDateTimeNow today = new CleanDateTimeNow();
                TimeSlot broadSpan = new TimeSlot(today.now.AddHours(-2), today.now.AddYears(1));
                List<TimeSlot> occupied = timeSlotRepository.GetOccupiedTimeSlotsPerDoctor(broadSpan,doctor.ID);
                foreach (Appointment appointment in AppointmentRepository.GetInstance().Appointments)
                {
                    if (appointment.DoctorID != doctor.ID) continue;
                    TimeSlot appointmentSlot = new TimeSlot(appointment.DateTime, appointment.DateTime.AddMinutes(Convert.ToInt32(appointment.Duration)));
                    for (int i = 0; i < occupied.Count; i++)
                    {
                        if (occupied[i].from == appointment.DateTime)
                        {
                            TimeSlot firstUnoccupied = appointmentSlot.GetFirstUnoccupied(occupied, -1);
                            appointmentRescheduleDatePairs.Add(appointment, firstUnoccupied.from);
                            break;
                        }
                    }
                }
            }

            var midSortedDictionary = from entry in appointmentRescheduleDatePairs orderby entry.Key.DateTime ascending select entry;
            var sortedDictionary = from entry in midSortedDictionary orderby entry.Value ascending select entry;
            return sortedDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        // TODO This needs to move
        public static void FillAppointmentTypeField(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Type"] = AppointmentService.GetTypeFullName(Convert.ToChar(row["Type"]));
            }
        }
        public static string GetFullName(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID).ToString();
        }
        public static List<Doctor> SearchByName(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public static List<Doctor> SearchBySurname(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.Surname.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public static List<Doctor> SearchBySpecialization(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.specialization.ID == id).ToList();
        }
        
    }
}
