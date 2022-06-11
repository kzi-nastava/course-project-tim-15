using Klinika.Models;
using Klinika.Repositories;
using Klinika.Interfaces;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepo prescriptionRepo;
        public PrescriptionService(IPrescriptionRepo prescriptionRepo) => this.prescriptionRepo = prescriptionRepo;
        public void Create(Prescription prescription)
        {
            prescriptionRepo.Create(prescription);
            NotificationService.MakeNotificationsForPrescription(prescription);
        }
    }
}