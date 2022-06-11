using Klinika.Interfaces;
using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class ReferralService
    {
        private readonly IReferralRepo referralRepo;
        public ReferralService(IReferralRepo referralRepo) => this.referralRepo = referralRepo;
        public void Create(int patientID, int specializationID, int doctorID) => referralRepo.Create(patientID, specializationID, doctorID);
        public static List<Referral> GetReferralsPerPatient(int patientId) => ReferalRepository.GetReferralsPerPatient(patientId);
        public static void MarkAsUsed(int referralId) => ReferalRepository.MarkAsUsed(referralId);
    }
}
