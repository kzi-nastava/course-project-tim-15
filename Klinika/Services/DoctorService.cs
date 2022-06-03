using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
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
                if (doctor.specialization.id != specializationId) continue;
                if (!IsOccupied(from, doctor.id)) return doctor;
            }
            return null;
        }
        public static (Doctor?,TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.id == specializationId)
                {
                    TimeSlot? firstAvailable = ScheduleService.GetFirstSlotAvailableUnderTwoHours(doctor.id);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                }
            }
            return (null,null);
        }

        public static string GetFullName(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID).ToString();
        }
        public static User GetOne(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID);
        }
        public static Room? GetOffice(int officeID)
        {
            return RoomServices.GetExaminationRooms().Where(x => x.id == officeID).FirstOrDefault();
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
            return DoctorRepository.GetInstance().doctors.Where(x => x.id == id).FirstOrDefault();
        }

        public static List<Doctor> SearchByName(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.name.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public static List<Doctor> SearchBySurname(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.surname.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public static List<Doctor> SearchBySpecialization(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.specialization.id == id).ToList();
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
            List<Appointment> forSelectedTimeSpan = AppointmentRepository.GetInstance().appointments.Where(
                x => x.doctorID == doctorID && slot.DoesOverlap(new TimeSlot(x.dateTime, x.duration)) && !x.isDeleted && x.id != forAppointmentID).ToList();
            bool onVacation = VacationRequestService.IsOnVacation(slot.from, doctorID);
            if (forSelectedTimeSpan.Count == 0) return false || onVacation;
            return true;
        }

    }
}