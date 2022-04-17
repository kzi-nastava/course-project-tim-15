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
        string Email { get; set; }
        string Password { get; set; }
        RoleType Role { get; set; }
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
