using Klinika.Core.Dependencies;
using Klinika.Drugs.Interfaces;
using Klinika.Drugs.Models;
using Klinika.Notifications;
using Microsoft.Extensions.DependencyInjection;

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