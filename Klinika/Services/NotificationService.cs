using Klinika.Models;
using Klinika.Roles;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class NotificationService
    {
        private readonly INotificationRepo notificationRepo;
        public NotificationService(INotificationRepo notificationRepo) => this.notificationRepo = notificationRepo;
        public void Send(Notification notification) => notificationRepo.Create(notification);
        public void MarkAsRead(int id) => notificationRepo.Modify(id);
        public List<Notification> GetAll(Patient patient) => notificationRepo.Get(patient);
        public void MakeNotificationsForPrescription(Prescription prescription)
        {
            DateTime start = new DateTime(prescription.dateStarted.Year, prescription.dateStarted.Month, prescription.dateStarted.Day,
                prescription.dateStarted.Hour + 1, 0, 0);
            DateTime end = new DateTime(prescription.dateEnded.Year, prescription.dateEnded.Month, prescription.dateEnded.Day,
                prescription.dateStarted.Hour + 1, 0, 0);

            while (start <= end)
            {
                Send(new Notification(prescription.patientID, prescription.comment, start));
                start = start.AddHours(prescription.interval);
            }
        }
    }
}
