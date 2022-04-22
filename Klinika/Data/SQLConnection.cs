using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klinika.Data
{
    internal class SQLConnection
    {
        public SqlConnection databaseConnection { get; }
        private static SQLConnection? instance;
            
        private SQLConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "usiprojekat.database.windows.net";
            builder.UserID = "dracooya";
            builder.Password = "UsiTim15#";
            builder.InitialCatalog = "Clinic";

            databaseConnection = new SqlConnection(builder.ConnectionString);
        }

        public static SQLConnection GetInstance()
        {
            if(instance == null) 
            { 
                instance = new SQLConnection();
            }
            return instance;
        }
    }
}
