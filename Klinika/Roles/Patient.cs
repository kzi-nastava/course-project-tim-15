namespace Klinika.Roles
{
    internal class Patient : User
    {
        public Patient(string email, string password, RoleType role) : base(email, password, role)
        {
        }
    }
}
