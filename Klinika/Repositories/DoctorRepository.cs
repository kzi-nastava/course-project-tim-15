using Klinika.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class DoctorRepository
    {
        public static string GetNameSurname(int id)
        {
            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT Name + ' ' + Surname AS 'Doctor' " +
                                     "FROM [User] " +
                                     "WHERE ID = @ID";
            string nameSurname = "";
            try
            {
                SqlCommand get = new SqlCommand(getQuery, database);
                get.Parameters.AddWithValue("@ID", id);
                database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    if (retrieved.Read())
                    {
                        nameSurname = retrieved["Doctor"].ToString();
                    }
                }
                database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return nameSurname;
        }
    }
}
