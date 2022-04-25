using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Klinika.Data;
using Klinika.Exceptions;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class PatientService
    {

        public static bool IsValid(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + 
                             @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static void Validate(string JMBG,
                                    string name,
                                    string surname,
                                    DateTime birthdate,
                                    string email,
                                    string password,
                                    bool isModification = false)
        {
            if (string.IsNullOrEmpty(JMBG))
            {
                throw new FieldEmptyException("JMBG left empty!");
            }

            else if (JMBG.Length != 13)
            {
                throw new JMBGFormatInvalidException("JMBG format is not valid!");
            }

            else if (string.IsNullOrEmpty(name))
            {
                throw new FieldEmptyException("Name left empty!");
            }

            else if (string.IsNullOrEmpty(surname))
            {
                throw new FieldEmptyException("Surname left empty!");
            }

            else if (birthdate > DateTime.Now)
            {
                throw new BirthdateInvalidException("Invalid birthdate!");
            }

            else if (string.IsNullOrEmpty(email) && !isModification)
            {
                throw new FieldEmptyException("Email left empty!");
            }

            else if (PatientRepository.EmailIDPairs != null &&
                     PatientRepository.EmailIDPairs.ContainsKey(email) &&
                     !isModification)
            {
                throw new ExistingEmailException("Email already in use!");
            }

            else if (!IsValid(email) && !isModification)
            {
                throw new EmailFormatInvalidException("Incorrect email format!");
            }

            else if (string.IsNullOrEmpty(password))
            {
                throw new FieldEmptyException("Password left empty!");
            }
            else if (password.Length < 4)
            {
                throw new FieldEmptyException("Password is too short!");
            }

        }


    }
}
