using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Interfaces
{
    public interface IDoctorRepo : IBaseDoctorRepo
    {
        public List<Specialization> GetSpecializations();
        public User[] GetSpecializedDoctors(int specializationID);
        public Specialization GetSpecialization(int doctorId);
    }
}
