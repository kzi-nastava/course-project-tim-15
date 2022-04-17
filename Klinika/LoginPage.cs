using Klinika.Repositories;
using Klinika.Roles;
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
            emailField.Text = "Login Successful!";
        }
    }
}