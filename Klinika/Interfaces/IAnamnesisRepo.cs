using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IAnamnesisRepo
    {
        List<Anamnesis> GetAll(int patientID);
        void Create(Anamnesis anamnesis);
    }
}
