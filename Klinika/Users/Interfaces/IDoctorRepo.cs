using Klinika.Users.Models;

namespace Klinika.Users.Interfaces
{
    public interface IDoctorRepo : IBaseDoctorRepo
    {
        public List<Specialization> GetSpecializations();
        public List<int> GetSpecializedIDs(int specializationID);
        public Specialization GetSpecialization(int doctorId);
    }
}
