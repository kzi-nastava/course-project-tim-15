using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using Klinika.Exceptions;

namespace Klinika.Services
{
    internal static class LoginService
    {
        
        public static User Validate(string email, string password)
        {

            Dictionary<string, User> allUsers = UserRepository.GetInstance().users;


            if (string.IsNullOrEmpty(email))
            {
                throw new FieldEmptyException("Email left empty!");
            }

            else if (string.IsNullOrEmpty(password)) {

                throw new FieldEmptyException("Password left empty!");
            }

            else if (!allUsers.ContainsKey(email))
            {
                throw new EmailUnknownException("There is no user with specified email!");
            }

            else if (!allUsers[email].Password.Equals(password))
            {
                throw new PasswordIncorrectException("Password does not match email!");
            }

            else if (allUsers[email].IsBlocked == true)
            {
                throw new UserBlockedException("The user is blocked!");
            }

            return allUsers[email];


        }


    }
}
