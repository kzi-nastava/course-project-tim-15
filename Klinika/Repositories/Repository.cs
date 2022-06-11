using Klinika.Data;

namespace Klinika.Repositories
{
    public abstract class Repository
    {
        protected DatabaseConnection database { get; }

        public Repository()
        {
            database = DatabaseConnection.GetInstance();
        }

    }
}
