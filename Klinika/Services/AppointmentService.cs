using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class AppointmentService
    {
        public static string GetTypeFullName(char type)
        {
            switch (type)
            {
                case 'O':
                    return "Operation";
                default:
                    return "Examination";
            }
        }
        public static List<Appointment> GetCompleted(int patientID)
        {
            return AppointmentRepository.GetCompleted(patientID);
        }
        public static void Create(Appointment appointment)
        {
            AppointmentRepository.GetInstance().Create(appointment);
        }
        public static void Modify(Appointment appointment)
        {
            AppointmentRepository.GetInstance().Modify(appointment);
        }
        public static void Delete(int id)
        {
            AppointmentRepository.Delete(id);
            AppointmentRepository.GetInstance().DeleteFromList(id);
        }
        public static void Complete(Appointment appointment)
        {
            appointment.completed = true;
            AppointmentRepository.GetInstance().Modify(appointment);
        }
        public static Appointment GetById(int id)
        {
            return AppointmentRepository.GetInstance().Appointments.Where(x => x.id == id).FirstOrDefault();
        }
        public static int GetModifyAppointmentsCount(int patientID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);

            var Descriptions = AppointmentRepository.GetDescriptions(patientID);
            int counter = 0;

            foreach (string description in Descriptions)
            {
                DateTime date = DateTime.ParseExact(description.Substring(9, 10), "yyyy-MM-dd", 
                    System.Globalization.CultureInfo.InvariantCulture);

                if (date > startDate) counter += 1;
            }
            return counter;
        }
        public static bool IsGraded(int id)
        {
            return QuestionnaireRepository.IsGraded(id);
        }
    }
}