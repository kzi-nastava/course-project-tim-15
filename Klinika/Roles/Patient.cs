namespace Klinika.Roles
{
    public class Patient : User
    {
        public string jmbg { get; }
        public DateTime birthdate { get; }
        public string whoBlocked { get; set; }
        public char gender { get; }
        public Patient(
                        int id,
                        string jmbg,
                        string name,
                        string surname,
                        DateTime birthdate,
                        char gender,
                        string email,
                        string password) : base(id, name, surname, email, password)
        {
            this.jmbg = jmbg;
            this.birthdate = birthdate;
            this.gender = gender;
            IsBlocked = false;
            whoBlocked = "";
        }
    }
}
