namespace Klinika.Roles
{
    abstract class User
    {
        #region [ --- CONSTANTS --- ]

        public enum RoleType
        {
            DOCTOR,
            PATIENT,
            SECRETARIAN,
            MANAGER
        }

        public enum GenderEnum
        {
            M,
            F
        }
        #endregion
        #region [ --- VARIABLES --- ]
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public DateOnly Birthdate { get; set; }
        public GenderEnum Gender { get; set; }

        #endregion

        #region [ --- CONSTRUCTORS --- ]
        public User (string email, string password,string name,string surname,string jmbg,DateOnly birthdate,GenderEnum gender, RoleType role)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Birthdate = birthdate;
            Gender = gender;
            Role = role;
        }
        #endregion
    }
}
