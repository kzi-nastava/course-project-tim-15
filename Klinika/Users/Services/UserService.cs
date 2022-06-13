using Klinika.Users.Interfaces;
using Klinika.Users.Models;

namespace Klinika.Users.Services
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
