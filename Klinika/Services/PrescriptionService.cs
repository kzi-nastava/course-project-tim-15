using Klinika.Interfaces;
using Klinika.Models;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        private readonly NotificationService? notificationService;
        private readonly IPrescriptionRepo prescriptionRepo;
        public PrescriptionService(IPrescriptionRepo prescriptionRepo)
        {
            notificationService = StartUp.serviceProvider.GetService<NotificationService>();
            this.prescriptionRepo = prescriptionRepo;
        }
        public void Create(Prescription prescription)
        {
            prescriptionRepo.Create(prescription);
            notificationService.MakeNotificationsForPrescription(prescription);
        }
    }
}