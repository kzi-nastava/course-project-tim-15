using Klinika.Models;
using Klinika.Repositories;
using Klinika.Interfaces;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        private readonly IMedicalRecordRepo medicalRecordRepo;
        public MedicalRecordService(IMedicalRecordRepo medicalRecordRepo) => this.medicalRecordRepo = medicalRecordRepo;
        public MedicalRecord Get(int patientID) => medicalRecordRepo.Get(patientID);
    }
}
