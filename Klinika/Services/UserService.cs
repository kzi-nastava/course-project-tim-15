using Klinika.Interfaces;
using Klinika.Roles;

namespace Klinika.Services
{
    internal class UserService
    {
        private readonly IUserRepo userRepo;
        public UserService(IUserRepo userRepo) => this.userRepo = userRepo;
        public User? GetByEmail(string email)
        {
            return userRepo.GetByEmail(email);
        }
        public User GetSingle(int userID) => userRepo.GetSingle(userID);
    }
}
