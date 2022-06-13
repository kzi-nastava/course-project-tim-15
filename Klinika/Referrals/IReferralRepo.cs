namespace Klinika.Referrals
{
    public interface IReferralRepo
    {
        void Create(int _patientID, int _specializationID, int _doctorID);

        public List<Referral> GetReferralsPerPatient(int patientId);

        public void MarkAsUsed(int referralID);
    }
}
