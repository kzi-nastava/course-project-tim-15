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
        public DoctorService()
        {
            doctorRepository = DoctorRepository.GetInstance();
        }

        public static List<Appointment> GetAppointments(int doctorID)
        {
            return AppointmentRepository.GetAll(doctorID, User.RoleType.DOCTOR);
        }
        public static List<Appointment> GetAppointments(DateTime date, int doctorID, int days = 1)
        {
            return AppointmentRepository.GetAll(date.ToString("yyyy-MM-dd"), doctorID, User.RoleType.DOCTOR, days);
        }

        public static Doctor? GetSuitable(int specializationId, DateTime from)
        {
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.ID != specializationId) continue;
                if (!IsOccupied(from, doctor.ID)) return doctor;
            }
            return null;
        }
        public static (Doctor?,TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.ID == specializationId)
                {
                    TimeSlot? firstAvailable = ScheduleService.GetFirstSlotAvailableUnderTwoHours(doctor.ID);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                }
            }
            return (null,null);
        }

        public static string GetFullName(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID).ToString();
        }
        public static Room? GetOffice(int officeID)
        {
            return RoomServices.GetExaminationRooms().Where(x => x.ID == officeID).FirstOrDefault();
        }
        public static double GetGrade(int id)
        {
            return QuestionnaireRepository.GetGrade(id);
        }
        public static Specialization GetSpecialization (int id)
        {
            return DoctorRepository.GetSpecialization(id);
        }
        public static Doctor GetById(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.ID == id).FirstOrDefault();
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

        public static bool IsOccupied(int doctorID, TimeSlot timeSlot, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, timeSlot.from.Hour, timeSlot.from.Minute, timeSlot.from.Second);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, timeSlot.to.Hour, timeSlot.to.Minute, timeSlot.to.Second);
            return IsOccupied(doctorID, new TimeSlot(start, end));
        }
        public static bool IsOccupied(DateTime start, int doctorID, int duration = 15, int forAppointmentID = -1)
        {
            return IsOccupied(doctorID, new TimeSlot(start, duration), forAppointmentID);
        }
        public static bool IsOccupied(int doctorID, TimeSlot slot, int forAppointmentID = -1)
        {
            List<Appointment> forSelectedTimeSpan = AppointmentRepository.GetInstance().Appointments.Where(
                x => x.DoctorID == doctorID && slot.DoesOverlap(new TimeSlot(x.DateTime, x.Duration)) && !x.IsDeleted && x.ID != forAppointmentID).ToList();
            bool onVacation = VacationRequestService.IsOnVacation(slot.from, doctorID);
            if (forSelectedTimeSpan.Count == 0) return false || onVacation;
            return true;
        }

    }
}