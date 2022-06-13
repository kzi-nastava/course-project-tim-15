using Klinika.Users.Models;

namespace Klinika.Users.Interfaces
{
    public interface IUserRepo
    {
        public User[] GetPatients();
        public List<User> GetDoctors();
        public User? GetSingle(int ID);
        public void Block(int id, string whoBlocked);
        public void Unblock(int id);
        public User? GetByEmail(string email);
    }
}
