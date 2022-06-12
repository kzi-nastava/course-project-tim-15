using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Interfaces
{
    public interface IDoctorRepo
    {
        public List<Specialization> GetSpecializations();
        public User[] GetSpecializedDoctors(int specializationID);
        public Specialization GetSpecialization(int doctorId);
        public List<Doctor> GetAll();
    }
}
