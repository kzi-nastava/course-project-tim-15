using Klinika.Users.Models;

namespace Klinika.Users.Interfaces
{
    public interface IBaseDoctorRepo
    {
        public List<Doctor> GetAll();
    }
}
