namespace Klinika.Roles
{
    public class Patient : User
    {
        public string jmbg { get; }
        public DateTime birthdate { get; }
        public string whoBlocked { get; set; }
        public char gender { get; }
        public int NotificationOffset { get; set; }
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
        public Patient(
                        int id,
                        string jmbg,
                        string name,
                        string surname,
                        DateTime birthdate,
                        char gender,
                        string email,
                        string password, 
                        bool isBlocked,
                        string whoBlocked,
                        int notificationOffset) : base(id, name, surname, email, password)
        {
            this.jmbg = jmbg;
            this.birthdate = birthdate;
            this.gender = gender;
            IsBlocked = isBlocked;
            this.whoBlocked = whoBlocked;
            NotificationOffset = notificationOffset;
        }
    }
}
