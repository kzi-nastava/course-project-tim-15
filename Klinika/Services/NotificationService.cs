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
            DateTime start = new DateTime(prescription.DateStarted.Year, prescription.DateStarted.Month, prescription.DateStarted.Day,
                prescription.DateStarted.Hour + 1, 0, 0);
            DateTime end = new DateTime(prescription.DateEnded.Year, prescription.DateEnded.Month, prescription.DateEnded.Day,
                prescription.DateStarted.Hour + 1, 0, 0);

            while (start < end)
            {
                Send(new Notification(prescription.PatientID, GenerateMessage(prescription), start));
                start = start.AddHours(prescription.Interval);
            }
        }
        private static string GenerateMessage (Prescription prescription)
        {
            Drug drug = DrugRepository.Instance.Drugs.Where(x => x.ID == prescription.DrugID).FirstOrDefault();
            return "Drug: " + drug.Name + "\nComment: " + prescription.Comment;
        }
    }
}
