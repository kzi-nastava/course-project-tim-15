public abstract class LoginException : Exception { 

    public LoginException(string message) : base(message) { }
}

public class EmailEmptyException : LoginException
{
    public EmailEmptyException(string message) : base(message) { }
}

public class PasswordEmptyException : LoginException
{
    public PasswordEmptyException(string message) : base(message) { }
}


public class EmailUnknownException: LoginException
{
    public EmailUnknownException(string message) : base(message) { }
}

public class PasswordIncorrectException : LoginException
{
    public PasswordIncorrectException(string message) : base(message) { }
}