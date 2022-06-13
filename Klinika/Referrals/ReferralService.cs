namespace Klinika.Referrals
{
    internal class ReferralService
    {
        private readonly IReferralRepo referralRepo;
        public ReferralService(IReferralRepo referralRepo) => this.referralRepo = referralRepo;
        public void Create(int patientID, int specializationID, int doctorID) => referralRepo.Create(patientID, specializationID, doctorID);
        public List<Referral> GetReferralsPerPatient(int patientId) => referralRepo.GetReferralsPerPatient(patientId);
        public void MarkAsUsed(int referralId) => referralRepo.MarkAsUsed(referralId);
    }
}
