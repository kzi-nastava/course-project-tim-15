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
            new LoginService();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            EquipmentRepository.CheckEquipmentTransfers();
            RoomRepository.CheckRenovations();
        }

        private void TryLogin()
        {
            try
            {
                string error_message = LoginService.Login(emailField.Text.Trim(), passwordField.Text.Trim());
                if (error_message != null)
                {
                    UIService.ShowErrorMessage(error_message);
                    return;
                }
                Hide();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}