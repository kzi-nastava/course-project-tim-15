public abstract class LoginException : Exception { 

    public LoginException(string message) : base(message)
    { 
        MessageBox.Show(message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
    }
}

public class EmailUnknownException: LoginException
{
    public EmailUnknownException(string message) : base(message) { }
}

public class PasswordIncorrectException : LoginException
{
    public PasswordIncorrectException(string message) : base(message) { }
}

public class UserBlockedException : LoginException
{
    public UserBlockedException(string message) : base(message) { }
}