using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
