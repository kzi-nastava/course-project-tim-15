using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Interfaces
{
    public interface IUserRepo
    {
        public User[] GetPatients();
        public List<User> GetDoctors();
        public User? GetDoctor(int ID);
        public void Block(int id, string whoBlocked);
        public void Unblock(int id);
        public User GetByEmail(string email);
    }
}
