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
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //DoctorRepository.Instance.Put(new Doctor("doctor1@gmail.com", "doctor1", User.RoleType.DOCTOR));
            //PatientRepository.Instance.Put(new Patient("patient1@gmail.com", "patient1", User.RoleType.PATIENT));
            try
            {
                string email = emailField.Text.Trim();
                string password = passwordField.Text.Trim();
                User loggedUser = LoginService.Validate(email, password);
                switch (loggedUser)
                {
                    case Secretarian:
                        //Show secretarians window
                        break;
                    case Doctor:
                        //Show doctors window
                        break;
                    case Manager:
                        //Show managers window
                        break;
                    default:
                        //Show patients window
                        break;
                }
                this.Close();

            }
            catch(EmailEmptyException ex)
            {
                passwordField.Text = "";
                MessageBox.Show(ex.Message);
            }

            catch(EmailUnknownException ex)
            {
                emailField.Text = "";
                passwordField.Text = "";
                MessageBox.Show(ex.Message);
            }

            catch (PasswordEmptyException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (PasswordIncorrectException ex)
            {
                passwordField.Text = "";
                MessageBox.Show(ex.Message);
            }
        }
    }
}