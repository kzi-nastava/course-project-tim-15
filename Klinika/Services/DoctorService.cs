using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Dependencies;

namespace Klinika.Services
{
    internal class DoctorService
    {
        private readonly DoctorScheduleService scheduleService;
        private DoctorRepository doctorRepository { get; }
        //TODO add IDoctorReopo
        public DoctorService(DoctorScheduleService scheduleService, DoctorRepository doctorRepository)
        {
            this.scheduleService = scheduleService;
            this.doctorRepository = doctorRepository;
        }

        public DoctorService()
        {
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            doctorRepository = DoctorRepository.GetInstance();
        }

        public static List<Appointment> GetAppointments(int doctorID)
        {
            return AppointmentRepository.GetAll(doctorID, User.RoleType.DOCTOR);
        }
        //TODO use scheduleService
        public static Doctor? GetSuitable(int specializationId, DateTime from)
        {
            //foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            //{
            //    if (doctor.specialization.id != specializationId) continue;
            //    if (!scheduleService.IsOccupied(from, doctor.id)) return doctor;
            //}
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
    }
}