using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        public static MedicalRecord Get(int patientID)
        {
            return MedicalRecordRepository.Get(patientID);
        }
    }
}
