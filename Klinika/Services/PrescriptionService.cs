using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        public PrescriptionService() { }
        public static void StorePrescription(Prescription prescription)
        {
            PrescriptionRepository.Create(prescription);
        }
    }
}