using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
