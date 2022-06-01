namespace Klinika.Exceptions
{
    internal class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
    }
}
