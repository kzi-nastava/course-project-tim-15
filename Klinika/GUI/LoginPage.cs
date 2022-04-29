using Klinika.Exceptions;
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
                        new GUI.Secretary.mainWindow().Show();
                        break;
                    case "Doctor":
                        new GUI.Doctor.DoctorMain(loggingUser).Show();
                        break;
                    case "Manager":
                        //Show managers window
                        break;
                    default:
                        new GUI.Patient.PatientMain(loggingUser).Show();
                        break;
                }
                this.Hide();

            }
            catch(FieldEmptyException)
            {
            }

            catch(EmailUnknownException)
            {
                emailField.Text = "";
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

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}