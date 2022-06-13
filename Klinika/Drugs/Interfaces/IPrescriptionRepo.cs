using Klinika.Drugs.Models;

namespace Klinika.Drugs.Interfaces
{
    public interface IPrescriptionRepo
    {
        void Create(Prescription prescription);
    }
}
