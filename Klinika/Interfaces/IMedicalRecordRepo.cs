using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IMedicalRecordRepo
    {
        MedicalRecord Get(int patientID);
        void Create(int patientID);
    }
}
