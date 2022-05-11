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
                LoginService.Login(emailField.Text.Trim(), passwordField.Text.Trim());
                Hide();
            }
            catch (FieldEmptyException) { }

            catch (EmailUnknownException)
            {
                emailField.Text = "";
                passwordField.Text = "";
            }

            catch (PasswordIncorrectException)
            {
                passwordField.Text = "";
            }

            catch (UserBlockedException)
            {
                emailField.Text = "";
                passwordField.Text = "";
            }
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            Repositories.EquipmentRepository.CheckEquipmentTransfers();
        }
    }
}