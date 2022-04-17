namespace Klinika.Roles
{
    abstract class User
    {
        #region [ --- CONSTANTS --- ]
        public enum RoleType
        {
            DOCTOR,
            PATIENT
        }
        #endregion
        #region [ --- VARIABLES --- ]
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
        #endregion

        #region [ --- CONSTRUCTORS --- ]
        public User (string email, string password, RoleType role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
        #endregion
    }
}
