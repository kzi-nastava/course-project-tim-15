using Klinika.Exceptions;
using Klinika.Repositories;
using Klinika.Services;
using Klinika.Utilities;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Roles;

namespace Klinika
{
    public partial class LoginPage : Form
    {
        private readonly LoginService loginService;
        private readonly UserService userService;
        public LoginPage()
        {
            InitializeComponent();
            loginService = StartUp.serviceProvider.GetService<LoginService>();
            userService = StartUp.serviceProvider.GetService<UserService>();
        }

        private void LoginButton_Click(object sender, EventArgs e) => TryLogin();

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void LoginPage_Load(object sender, EventArgs e)
        {
            //TODO: Change communication from repository to service
            //TODO: Add appropriate services
            //EquipmentRepository.CheckEquipmentTransfers();
            //RoomRepository.CheckRenovations();
        }

        private void TryLogin()
        {
            try
            {
                string error_message = ValidateLoginCredentials(emailField.Text.Trim(), passwordField.Text.Trim());
                
                if (error_message != null)
                {
                    MessageBoxUtilities.ShowErrorMessage(error_message);
                    return;
                }
                loginService.Login(emailField.Text.Trim(), passwordField.Text.Trim());
                Hide();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public string? ValidateLoginCredentials(string email, string password)
        {
            string error_message = null;

            if (string.IsNullOrEmpty(email))
            {
                error_message = "Email left empty!";
            }

            else if (string.IsNullOrEmpty(password))
            {

                error_message = "Password left empty!";
            }

            else if (userService.GetByEmail(email) == null)
            {
                error_message = "There is no user with specified email!";
            }

            else if (!userService.GetByEmail(email).password.Equals(password))
            {
                error_message = "Password does not match email!";
            }

            else if (userService.GetByEmail(email).isBlocked == true)
            {
                error_message = "The user is blocked!";
            }

            return error_message;

        }
    }
}