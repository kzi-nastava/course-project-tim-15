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

            UserRepository instance = UserRepository.GetInstance();

            if (string.IsNullOrEmpty(email))
            {
                throw new EmailEmptyException("Email left empty!");
            }

            else if (string.IsNullOrEmpty(password)) {

                throw new PasswordEmptyException("Password left empty!");
            }

            else if (!instance.users.ContainsKey(email))
            {
                throw new EmailUnknownException("There is no user with specified email!");
            }

            else if (!instance.users[email].Password.Equals(password))
            {
                throw new PasswordIncorrectException("Password does not match email!");
            }

            else if (instance.users[email].IsBlocked == true)
            {
                throw new UserBlockedException("The user is blocked!");
            }

            return instance.users[email];


        }


    }
}
