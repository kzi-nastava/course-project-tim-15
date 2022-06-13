using Klinika.Core.Database;

namespace Klinika.Core
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
