using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klinika.Data
{
    internal class DatabaseConnection
    {
        public SqlConnection database { get; }
        private static DatabaseConnection? singletonInstance;

        private DatabaseConnection()
        {
            SqlConnectionStringBuilder credentials = new SqlConnectionStringBuilder();
            credentials.DataSource = "usiprojekat.database.windows.net";
            credentials.UserID = "dracooya";
            credentials.Password = "UsiTim15#";
            credentials.InitialCatalog = "Clinic";

            database = new SqlConnection(credentials.ConnectionString);
        }

        public static DatabaseConnection GetInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new DatabaseConnection();
            }
            return singletonInstance;
        }
    }
}
