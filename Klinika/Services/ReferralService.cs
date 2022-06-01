using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    internal class ReferralService
    {
        public static DataTable GetReferralsPerPatient(int patientId)
        {
            return ReferalRepository.GetReferralsPerPatient(patientId);
        }
        public static void Create(int patientID, int specializationID, int doctorID)
        {
            ReferalRepository.Create(patientID, specializationID, doctorID);
        }
        public static void MarkAsUsed(int referralId)
        {
            ReferalRepository.MarkAsUsed(referralId);
        }
    }
}
