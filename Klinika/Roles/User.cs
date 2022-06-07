namespace Klinika.Roles
{
    public class User
    {
        #region Consts
        public enum RoleType
        {
            DOCTOR,
            PATIENT,
            SECRETARIAN,
            MANAGER
        }

        #endregion

        #region Variables
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool isBlocked { get; set; }

        public override string ToString()
        {
            return $"{name} {surname}";
        }
        #endregion

        #region Constructors
        public User(string email, string password, string role, bool isBlocked)
        {
            id = -1;
            name = "";
            surname = "";
            this.email = email;
            this.password = password;
            this.role = role;
            this.isBlocked = isBlocked;
        }
        public User (int id, string? name, string? surname, string email, string password, string role, bool isBlocked)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.role = role;
            this.isBlocked = isBlocked;
        }


        public User(int id, string name,string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }

        public User(int id, string? name, string? surname, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
        }
        #endregion


        public string GetIdAndFullName()
        {
            return id + ". " + name + " " + surname;
        }
    }
}
