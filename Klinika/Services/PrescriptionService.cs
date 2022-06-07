using Klinika.Models;
using Klinika.Repositories;
using Klinika.Interfaces;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepo prescriptionRepo;
        public PrescriptionService()
        {
            prescriptionRepo = new PrescriptionRepository();
        }
        public void StorePrescription(Prescription prescription)
        {
            prescriptionRepo.Create(prescription);
            NotificationService.MakeNotificationsForPrescription(prescription);
        }
    }
}