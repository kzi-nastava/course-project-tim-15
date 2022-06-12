using Klinika.Dependencies;
using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Klinika.Services
{
    internal class DoctorService
    {
        private readonly DoctorScheduleService scheduleService;
        private IDoctorRepo doctorRepository { get; }
        private IScheduledAppointmentsRepo scheduledAppointmentsRepository;
        public DoctorService(IDoctorRepo doctorRepo,IScheduledAppointmentsRepo scheduledAppointmentsRepo)
        {
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            doctorRepository = doctorRepo;
            scheduledAppointmentsRepository = scheduledAppointmentsRepo;
        }

        public List<Appointment> GetAppointments(int doctorID)
        {
            return scheduledAppointmentsRepository.GetAll(doctorID, User.RoleType.DOCTOR);
        }
        public Doctor? GetSuitable(int specializationId, DateTime from)
        {
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.specialization.id != specializationId) continue;
                if (!scheduleService.IsOccupied(from, doctor.id)) return doctor;
            }
            return null;
        }
        public (Doctor?,TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.specialization.id == specializationId)
                {
                    TimeSlot? firstAvailable = scheduleService.GetFirstSlotAvailableUnderTwoHours(doctor.id);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                }
            }
            return (null,null);
        }

        public string GetFullName(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID).ToString();
        }
        public User GetOne(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID);
        }
        public double GetGrade(int id)
        {
            return QuestionnaireRepository.GetGrade(id);
        }
        public Specialization GetSpecialization (int id)
        {
            return DoctorRepository.GetSpecialization(id);
        }
        public Doctor GetById(int id)
        {
            return  doctorRepository.GetAll().Where(x => x.id == id).FirstOrDefault();
        }

        public List<Doctor> SearchByName(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.name.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public List<Doctor> SearchBySurname(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.surname.ToUpper().Contains(keyword.ToUpper())).ToList();
        }
        public List<Doctor> SearchBySpecialization(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.specialization.id == id).ToList();
        }
    }
}