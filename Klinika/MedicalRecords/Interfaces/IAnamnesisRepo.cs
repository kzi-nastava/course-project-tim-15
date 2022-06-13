using Klinika.MedicalRecords.Models;

namespace Klinika.MedicalRecords.Interfaces
{
    public interface IAnamnesisRepo
    {
        List<Anamnesis> GetAll(int patientID);
        void Create(Anamnesis anamnesis);
    }
}
