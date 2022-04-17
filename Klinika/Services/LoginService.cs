using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal static class LoginService
    {
        public static User Validate(string email, string password)
        {
            
            if (string.IsNullOrEmpty(email))
            {
                throw new EmailEmptyException("Email left empty!");
            }

            else if (string.IsNullOrEmpty(password)) {

                throw new PasswordEmptyException("Password left empty!");
            }

            else if (!UserRepository.users.ContainsKey(email))
            {
                throw new EmailUnknownException("There is no user with specified email!");
            }

            else if (!UserRepository.users[email].Password.Equals(password))
            {
                throw new PasswordIncorrectException("Password does not match email!");
            }

            return UserRepository.users[email];
        }
    }
}
