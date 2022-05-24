using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using System.Text.RegularExpressions;

namespace Klinika.Services
{
    internal class ValidationService
    {
        public static string? ValidateLoginCredentials(string email, string password)
        {
            Dictionary<string, User> allUsers = UserRepository.GetInstance().users;

            string error_message = null;

            if (string.IsNullOrEmpty(email))
            {
                error_message = "Email left empty!";
            }

            else if (string.IsNullOrEmpty(password))
            {

                error_message = "Password left empty!";
            }

            else if (!allUsers.ContainsKey(email))
            {
                error_message = "There is no user with specified email!";
            }

            else if (!allUsers[email].Password.Equals(password))
            {
                error_message = "Password does not match email!";
            }

            else if (allUsers[email].IsBlocked == true)
            {
                error_message = "The user is blocked!";
            }

            return error_message;

        }

        public static string? ValidateAppointment(int doctorID, DateTime appointmentStart)
        {
            string error_message = null;
            if (appointmentStart <= DateTime.Now)
            {
                error_message = "Selected appointment time is incorrect!" ;
            }

            if (doctorID == -1)
            {
                error_message = "Doctor is not selected!" ;
            }

            if (AppointmentRepository.GetInstance().IsOccupied(appointmentStart, doctorID: doctorID))
            {
                error_message = "The selected doctor is not available at the selected time!";
            }

            return error_message;
        }

        public static string? ValidatePatient(Patient patient,bool isModification = false)
        {
            string error_messsage = null;
            if (string.IsNullOrEmpty(patient.jmbg))
            {
                error_messsage = "JMBG left empty!";
            }

            else if (patient.jmbg.Length != 13)
            {
                error_messsage = "JMBG format is not valid!";
            }

            else if (string.IsNullOrEmpty(patient.Name))
            {
                error_messsage = "Name left empty!";
            }

            else if (string.IsNullOrEmpty(patient.Surname))
            {
                error_messsage = "Surname left empty!";
            }

            else if (patient.birthdate > DateTime.Now)
            {
                error_messsage = "Invalid birthdate!";
            }

            else if (string.IsNullOrEmpty(patient.Email) && !isModification)
            {
                error_messsage = "Email left empty!";
            }

            else if (PatientRepository.EmailIDPairs != null &&
                     PatientRepository.EmailIDPairs.ContainsKey(patient.Email) &&
                     !isModification)
            {
                error_messsage = "Email already in use!";
            }

            else if (!IsValidEmail(patient.Email) && !isModification)
            {
                error_messsage = "Incorrect email format!";
            }

            else if (string.IsNullOrEmpty(patient.Password))
            {
                error_messsage = "Password left empty!";
            }

            else if (patient.Password.Length < 4)
            {
                error_messsage = "Password is too short!";
            }

            return error_messsage;

        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                             @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
