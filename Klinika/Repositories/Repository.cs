using Klinika.Data;

namespace Klinika.Repositories
{
    internal abstract class Repository
    {
        public DatabaseConnection database { get; }

        public Repository()
        {
            database = DatabaseConnection.GetInstance();
        }

    }
}
