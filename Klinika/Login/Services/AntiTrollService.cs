using Microsoft.Extensions.DependencyInjection;
using Klinika.Users.Models;
using Klinika.Users.Services;
using Klinika.Core.Dependencies;

namespace Klinika.Login.Services
{
    public class AntiTrollService
    {
        private readonly IAntiTrollRepo antiTrollRepo;
        private readonly PatientService? patientService;
        public AntiTrollService(IAntiTrollRepo antiTrollRepo)
        {
            this.antiTrollRepo = antiTrollRepo;
            patientService = StartUp.serviceProvider.GetService<PatientService>();
        }
        public bool IsPatientBlocked(User patient)
        {

            bool isBlocked = antiTrollRepo.GetScheduledAppointmentsCount(patient.id) > 8
                || GetModifyAppointmentsCount(patient.id) > 5;
            if (!isBlocked) return false;
            patientService.Block(patient, "SYS");
            return true;
        }
        private int GetModifyAppointmentsCount(int patientID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);
            var Descriptions = antiTrollRepo.GetDescriptions(patientID);
            int counter = 0;

            foreach (string description in Descriptions)
            {
                DateTime date = DateTime.ParseExact(description.Substring(9, 10), "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);

                if (date > startDate) counter += 1;
            }
            return counter;
        }
    }
}
