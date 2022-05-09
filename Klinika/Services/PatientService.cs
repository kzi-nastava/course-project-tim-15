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
using Klinika.GUI.Secretary;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class PatientService
    {

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + 
                             @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static void Validate(Roles.Patient patientInputData,bool isModification = false)
        {

            if (string.IsNullOrEmpty(patientInputData.jmbg))
            {
                throw new FieldEmptyException("JMBG left empty!");
            }

            else if (patientInputData.jmbg.Length != 13)
            {
                throw new JMBGFormatInvalidException("JMBG format is not valid!");
            }

            else if (string.IsNullOrEmpty(patientInputData.Name))
            {
                throw new FieldEmptyException("Name left empty!");
            }

            else if (string.IsNullOrEmpty(patientInputData.Surname))
            {
                throw new FieldEmptyException("Surname left empty!");
            }

            else if (patientInputData.birthdate > DateTime.Now)
            {
                throw new BirthdateInvalidException("Invalid birthdate!");
            }

            else if (string.IsNullOrEmpty(patientInputData.Email) && !isModification)
            {
                throw new FieldEmptyException("Email left empty!");
            }

            else if (PatientRepository.EmailIDPairs != null &&
                     PatientRepository.EmailIDPairs.ContainsKey(patientInputData.Email) &&
                     !isModification)
            {
                throw new ExistingEmailException("Email already in use!");
            }

            else if (!IsValidEmail(patientInputData.Email) && !isModification)
            {
                throw new EmailFormatInvalidException("Incorrect email format!");
            }

            else if (string.IsNullOrEmpty(patientInputData.Password))
            {
                throw new FieldEmptyException("Password left empty!");
            }

            else if (patientInputData.Password.Length < 4)
            {
                throw new FieldEmptyException("Password is too short!");
            }

        }


    }
}
