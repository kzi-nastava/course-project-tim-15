using Klinika.Data;
using Klinika.Models;
using Klinika.Roles;
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
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return nameSurname;
        }

        public static List<Specialization> GetSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            
            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT * FROM [Specialization]";

            try
            {
                SqlCommand get = new SqlCommand(getQuery, database);
                database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        specializations.Add(new Specialization
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            Name = retrieved["Name"].ToString()
                        });
                    }
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return specializations;
        }
        public static List<int> GetSpecializedIDs(int specializationID)
        {
            List<int> doctors = new List<int>();

            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT UserID " +
                "FROM [DoctorSpecialization] " +
                $"WHERE SpecializationID = {specializationID}";

            try
            {
                SqlCommand get = new SqlCommand(getQuery, database);
                database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        doctors.Add(Convert.ToInt32(retrieved["UserID"]));
                    }
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return doctors;
        }
    }
}
