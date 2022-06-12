using Klinika.Roles;
using Klinika.Utilities;
using Klinika.Interfaces;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Services
{
    internal class LoginService
    {
        private readonly IUserRepo userRepo;
        private readonly PatientService patientService;
        public LoginService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
            patientService = StartUp.serviceProvider.GetService<PatientService>();
        }

        public void Login(string email, string password)
        {
            User loggingUser = userRepo.GetByEmail(email);

            switch (loggingUser.role)
            {
                case "Secretary":
                    new GUI.Secretary.mainWindow().Show();
                    break;
                case "Doctor":
                    new GUI.Doctor.Main(loggingUser.id).Show();
                    break;
                case "Manager":
                    new GUI.Manager.Main().Show();
                    break;
                default:
                    if (patientService.IsBlocked(loggingUser))
                    {
                        MessageBoxUtilities.ShowErrorMessage("Your account is blocked because of trolling.");
                        break;
                    }
                    else
                    {
                        new GUI.Patient.Main(loggingUser.id).Show();
                        break;
                    }
            }
        }
    }
}
