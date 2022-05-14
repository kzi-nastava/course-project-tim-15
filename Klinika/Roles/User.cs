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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsBlocked { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
        #endregion

        #region Constructors
        public User(string email, string password, string role, bool isBlocked)
        {
            ID = -1;
            Name = "";
            Surname = "";
            Email = email;
            Password = password;
            Role = role;
            IsBlocked = isBlocked;
        }
        public User (int id, string? name, string? surname, string email, string password, string role, bool isBlocked)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
            IsBlocked = isBlocked;
        }


        public User(int id, string name,string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
        }
        #endregion


        public User(int id,string? name,string? surname, string email,string password)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }


        public string GetIdAndFullName()
        {
            return ID + ". " + Name + " " + Surname;
        }
    }
}
