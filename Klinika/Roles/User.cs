namespace Klinika.Roles
{
    internal class User
    {
        #region [ --- VARIABLES --- ]
        string Email { get; set; }
        string Password { get; set; }
        #endregion

        #region [ --- CONSTRUCTORS --- ]
        public User (string email, string password)
        {
            Email = email;
            Password = password;
        }
        #endregion
    }
}
