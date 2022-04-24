namespace Klinika.Roles
{
    internal class User
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
        public string Role { get; set; }
        public bool IsBlocked { get; set; }

        #endregion

        #region [ --- CONSTRUCTORS --- ]
        public User (string email, string password, string role, bool isBlocked)
        {
            Email = email;
            Password = password;
            Role = role;
            IsBlocked = isBlocked;
        }
        #endregion
    }
}
