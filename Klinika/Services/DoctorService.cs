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
        private readonly DoctorScheduleService? scheduleService;
        private IDoctorRepo doctorRepo;
        private IScheduledAppointmentsRepo scheduledAppointmentsRepo;
        public DoctorService(IDoctorRepo doctorRepo, IScheduledAppointmentsRepo scheduledAppointmentsRepo)
        {
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            this.doctorRepo = doctorRepo;
            this.scheduledAppointmentsRepo = scheduledAppointmentsRepo;
        }

        public Doctor GetById(int id) => doctorRepo.GetAll().Where(x => x.id == id).FirstOrDefault();
        public List<Doctor> GetAll() => doctorRepo.GetAll();
        public List<Appointment> GetAppointments(int doctorID)
        {
            return scheduledAppointmentsRepo.GetAll(doctorID, User.RoleType.DOCTOR);
        }
        public Doctor? GetSuitable(int specializationId, DateTime from)
        {
            foreach (Doctor doctor in doctorRepo.GetAll())
            {
                if (doctor.specialization.id != specializationId) continue;
                if (!scheduleService.IsOccupied(from, doctor.id)) return doctor;
            }
            return null;
        }
        public (Doctor?, TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            foreach (Doctor doctor in doctorRepo.GetAll())
            {
                if (doctor.specialization.id == specializationId)
                {
                    TimeSlot? firstAvailable = scheduleService.GetFirstSlotAvailableUnderTwoHours(doctor.id);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                }
            }
            return (null,null);
        }

        public string GetFullName(int doctorID) => doctorRepo.GetAll().Where(x => x.id == doctorID).FirstOrDefault().ToString();
        public Specialization GetSpecialization (int id) => doctorRepo.GetSpecialization(id);

        public List<Doctor> SearchByName(string keyword) => GetAll().Where(x => x.name.ToUpper().Contains(keyword.ToUpper())).ToList();
        public List<Doctor> SearchBySurname(string keyword) => GetAll().Where(x => x.surname.ToUpper().Contains(keyword.ToUpper())).ToList();
        public List<Doctor> SearchBySpecialization(int id) => GetAll().Where(x => x.specialization.id == id).ToList();
    }
}