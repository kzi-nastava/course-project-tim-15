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

            else if (string.IsNullOrEmpty(password))
            {

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

        public static void Login(string email, string password)
        {
            User loggingUser = Validate(email, password);
            switch (loggingUser.Role)
            {
                case "Secretary":
                    new GUI.Secretary.mainWindow().Show();
                    break;
                case "Doctor":
                    new GUI.Doctor.DoctorMain(loggingUser).Show();
                    break;
                case "Manager":
                    new GUI.Manager.Main().Show();
                    break;
                default:
                    if (AppointmentRepository.GetScheduledAppointmentsCount(loggingUser.ID) > 8 || PatientRequestRepository.GetModifyAppointmentsCount(loggingUser.ID) > 5)
                    {
                        loggingUser.IsBlocked = true;
                        UserRepository.Block(loggingUser.ID);
                        throw new UserBlockedException("Your account is blocked because of trolling.");
                    }
                    else
                    {
                        new GUI.Patient.PatientMain(loggingUser).Show();
                        break;
                    }
            }
        }
    }
}

