using Klinika.Models;
using Klinika.Repositories;
using Klinika.Interfaces;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        private readonly IMedicalRecordRepo medicalRecordRepo;
        public MedicalRecordService() => medicalRecordRepo = new MedicalRecordRepository();
        public MedicalRecord Get(int patientID) => medicalRecordRepo.Get(patientID);
    }
}
