using Klinika.Repositories;
using Klinika.Interfaces;
using System.Data;
using Klinika.Models;

namespace Klinika.Services
{
    internal class ReferralService
    {
        private readonly IReferralRepo referralRepo;
        public ReferralService()
        {
            referralRepo = new ReferalRepository();
        }
        public void Create(int patientID, int specializationID, int doctorID)
        {
            referralRepo.Create(patientID, specializationID, doctorID);
        }
        public static List<Referral> GetReferralsPerPatient(int patientId)
        {
            return ReferalRepository.GetReferralsPerPatient(patientId);
        }
        public static void MarkAsUsed(int referralId)
        {
            ReferalRepository.MarkAsUsed(referralId);
        }
    }
}
