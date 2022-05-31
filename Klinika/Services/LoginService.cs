using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using Klinika.Utilities;

namespace Klinika.Services
{
    internal class LoginService
    {
        public LoginService()
        {
            UserRepository.GetInstance();
        }

        public static string Login(string email, string password)
        {
            string error_message = ValidationUtilities.ValidateLoginCredentials(email, password);
            if (error_message != null)
            {
                return error_message;
            }
            User loggingUser = UserRepository.GetInstance().users[email];

            switch (loggingUser.Role)
            {
                case "Secretary":
                    new GUI.Secretary.mainWindow().Show();
                    break;
                case "Doctor":
                    new GUI.Doctor.DoctorMain(loggingUser.ID).Show();
                    break;
                case "Manager":
                    new GUI.Manager.Main().Show();
                    break;
                default:
                    if (PatientService.IsBlocked(loggingUser))
                    {
                        MessageBoxUtilities.ShowErrorMessage("Your account is blocked because of trolling.");
                        break;
                    }
                    else
                    {
                        new GUI.Patient.PatientMain(loggingUser.ID).Show();
                        break;
                    }
            }

            return null;
        }
    }
}
