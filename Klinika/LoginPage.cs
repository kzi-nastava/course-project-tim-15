using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;

namespace Klinika
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            UserRepository.GetInstance();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string email = emailField.Text.Trim();
                string password = passwordField.Text.Trim();

                User loggingUser = LoginService.Validate(email, password);
                switch (loggingUser.Role)
                {
                    case "Secretary":
                        //Show secretarians window
                        break;
                    case "Doctor":
                        //Show doctors window
                        break;
                    case "Manager":
                        //Show managers window
                        break;
                    default:
                        //Show patients window
                        break;
                }
                this.Close();

            }
            catch(EmailEmptyException)
            {
                passwordField.Text = "";
            }

            catch(EmailUnknownException)
            {
                emailField.Text = "";
                passwordField.Text = "";
            }

            catch (PasswordEmptyException)
            {
                passwordField.Text = "";
                passwordField.Text = "";
            }

            catch (PasswordIncorrectException)
            {
                passwordField.Text = "";
            }

            catch(UserBlockedException)
            {
                emailField.Text = "";
                passwordField.Text = "";
            }
        }
    }
}