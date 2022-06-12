using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Utilities;
using System.Data;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class PatientService
    {
        private readonly IPatientRepo patientRepo;
        private readonly IUserRepo userRepo;

        public PatientService(IPatientRepo patientRepo, IUserRepo userRepo)
        {
            this.patientRepo = patientRepo;
            this.userRepo = userRepo;
        }
        
        public User? GetSingle(int id)
        {
            return patientRepo.GetAll().Where(x => x.id == id).FirstOrDefault();
        }
        public List<Patient> GetAll()
        {
            return patientRepo.GetAll();
        }

        public void Add(Patient newPatient)
        {
            patientRepo.Create(newPatient);
        }
        public void Modify(Patient patient)
        {
            patientRepo.Modify(patient);
        }
        public void Delete(int patientId)
        {
            patientRepo.Delete(patientId);
        }

        public string GetFullName(int ID)
        {
            var patient = UserRepository.GetInstance().Users.Where(x => x.id == ID).FirstOrDefault();
            return $"{patient.name} {patient.surname}";
        }
        public Patient GetById(int id)
        {
            return PatientRepository.GetSingle(id);
        }

        public bool IsBlocked(User patient)
        {
            bool isBlocked = AppointmentRepository.GetScheduledAppointmentsCount(patient.id) > 8 
                || AppointmentService.GetModifyAppointmentsCount(patient.id) > 5;
            if (!isBlocked) return false;
            Block(patient, "SYS");
            return true;
        }
        public void Block(User patient, string whoBlocked)
        {
            patient.isBlocked = true;
            userRepo.Block(patient.id, whoBlocked);
        }
        public void Unblock(Patient patient)
        {
            patient.whoBlocked = "";
            patient.isBlocked = false;
            userRepo.Unblock(patient.id);
        }

        public int? GetIdByEmail(string email)
        {
            return patientRepo.GetIdByEmail(email);
        }
    }
}