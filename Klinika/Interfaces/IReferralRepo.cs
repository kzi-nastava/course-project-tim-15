namespace Klinika.Interfaces
{
    public interface IReferralRepo
    {
        void Create(int _patientID, int _specializationID, int _doctorID);
    }
}
