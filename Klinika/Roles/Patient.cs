namespace Klinika.Roles
{
    internal class Patient : User
    {
        public Patient(string email, string password, string name, string surname, string jmbg, DateOnly birthdate,GenderEnum gender,
              RoleType roleType) : base(email, password, name, surname, jmbg, birthdate, gender, roleType)
        {
        }
    }
}
