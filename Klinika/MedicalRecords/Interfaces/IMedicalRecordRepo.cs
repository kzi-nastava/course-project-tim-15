using Klinika.MedicalRecords.Models;

namespace Klinika.MedicalRecords.Interfaces
{
    public interface IMedicalRecordRepo
    {
        MedicalRecord Get(int patientID);
        void Create(int patientID);
    }
}
