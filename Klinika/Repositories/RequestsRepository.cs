using Klinika.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class RequestsRepository
    {
        public static DataTable GetAll()
        {
            DataTable? retrievedRequests = null;
            string getAllQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Email, IsBlocked as Blocked, WhoBlocked as BlockedBy " +
                                      "FROM [User] " +
                                      "WHERE UserType = 1 AND IsDeleted = 0";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, DatabaseConnection.GetInstance().database);
                retrievedRequests = new DataTable();
                adapter.Fill(retrievedRequests);
                retrievedRequests.Columns.Remove("ID");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retrievedRequests;
        } 
    }
}
