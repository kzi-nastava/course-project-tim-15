using Klinika.MedicalRecords.Interfaces;
using Klinika.MedicalRecords.Models;

namespace Klinika.MedicalRecords.Services
{
    public class MedicalRecordService
    {
        private readonly IMedicalRecordRepo medicalRecordRepo;
        public MedicalRecordService(IMedicalRecordRepo medicalRecordRepo) => this.medicalRecordRepo = medicalRecordRepo;
        public MedicalRecord Get(int patientID) => medicalRecordRepo.Get(patientID);
    }
}
