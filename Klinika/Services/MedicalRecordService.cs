using Klinika.Interfaces;
using Klinika.Models;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        private readonly IMedicalRecordRepo medicalRecordRepo;
        public MedicalRecordService(IMedicalRecordRepo medicalRecordRepo) => this.medicalRecordRepo = medicalRecordRepo;
        public MedicalRecord Get(int patientID) => medicalRecordRepo.Get(patientID);
    }
}
