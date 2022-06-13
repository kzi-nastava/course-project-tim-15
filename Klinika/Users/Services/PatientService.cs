using Klinika.Users.Interfaces;
using Klinika.Users.Models;
using System.Data;

namespace Klinika.Users.Services
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
        public Patient GetSingle(int id) => patientRepo.GetSingle(id);
        public int? GetIdByEmail(string email) => patientRepo.GetIdByEmail(email);
        public List<Patient> GetAll() => patientRepo.GetAll();
        public void Add(Patient newPatient) => patientRepo.Create(newPatient);
        public void Modify(Patient patient) => patientRepo.Modify(patient);
        public void Delete(int patientId) => patientRepo.Delete(patientId);
        public string GetFullName(int ID)
        {
            var patient = patientRepo.GetAll().Where(x => x.id == ID).FirstOrDefault();
            return $"{patient.name} {patient.surname}";
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

    }
}