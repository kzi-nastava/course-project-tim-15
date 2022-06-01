using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;

namespace Klinika.Services
{
    internal class NotificationService
    {
        public static List<Notification> Get(Patient patient)
        {
            return NotificationRepository.Get(patient);
        }
        public static void Send(Notification notification)
        {
            NotificationRepository.Send(notification);
        }
        public static void MakeNotificationsForPrescription(Prescription prescription)
        {
            DateTime start = new DateTime(prescription.dateStarted.Year, prescription.dateStarted.Month, prescription.dateStarted.Day,
                prescription.dateStarted.Hour + 1, 0, 0);
            DateTime end = new DateTime(prescription.dateEnded.Year, prescription.dateEnded.Month, prescription.dateEnded.Day,
                prescription.dateStarted.Hour + 1, 0, 0);

            while (start <= end)
            {
                Send(new Notification(prescription.patientID, GenerateMessage(prescription), start));
                start = start.AddHours(prescription.interval);
            }
        }
        private static string GenerateMessage (Prescription prescription)
        {
            Drug drug = DrugRepository.Instance.Drugs.Where(x => x.id == prescription.drugID).FirstOrDefault();
            return "Drug: " + drug.name + "\nComment: " + prescription.comment;
        }
        public static void MarkAsRead(int id)
        {
            NotificationRepository.Modify(id);
        }
    }
}
