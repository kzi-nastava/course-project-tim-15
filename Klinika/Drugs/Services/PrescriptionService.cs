using Microsoft.Extensions.DependencyInjection;
using Klinika.Notifications;
using Klinika.Drugs.Models;
using Klinika.Drugs.Interfaces;
using Klinika.Core.Dependencies;

namespace Klinika.Drugs.Services
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