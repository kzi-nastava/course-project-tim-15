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
            string getQuery = "SELECT Name + ' ' + Surname AS 'Doctor' " +
                                     "FROM [User] " +
                                     "WHERE ID = @ID";
            string nameSurname = "";
            SqlDataReader retrieved = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuery, ("@ID", id));
            DatabaseConnection.GetInstance().database.Open();

            if (retrieved.Read())
            {
                nameSurname = retrieved["Doctor"].ToString();
            }
            
            DatabaseConnection.GetInstance().database.Close();

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
        public static Specialization getSpecialization (int DoctorID)
        {
            string specializationQuerry = "SELECT [Specialization].ID, [Specialization].Name " +
                                          "FROM [Specialization] JOIN [DoctorSpecialization] " +
                                          "ON [Specialization].ID = [DoctorSpecialization].SpecializationID " +
                                          $"WHERE [DoctorSpecialization].UserID = {DoctorID}";

            Specialization specialization = new Specialization();

            try
            {
                SqlCommand getAnamneses = new SqlCommand(specializationQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAnamneses.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        specialization.ID = Convert.ToInt32(retrieved["ID"]);
                        specialization.Name = retrieved["Name"].ToString();
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return specialization;
        }


        public static List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            string getAllQuery = "SELECT [DoctorSpecialization].UserID, [User].Name,[User].Surname, " +
                                 "[DoctorSpecialization].SpecializationID,[Specialization].Name 'Specialization' " +
                                 "FROM [DoctorSpecialization] " +
                                 "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                                 "LEFT OUTER JOIN [Specialization] ON [DoctorSpecialization].SpecializationID = [Specialization].ID";

            SqlDataReader retrieved = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAllQuery);
            DatabaseConnection.GetInstance().database.Open();

            while(retrieved.Read())
            {
                Specialization specialization = new Specialization(
                                                Convert.ToInt32(retrieved["SpecializationID"]),
                                                retrieved["Specialization"].ToString());

                Doctor doctor = new Doctor(
                                Convert.ToInt32(retrieved["UserID"]),
                                retrieved["Name"].ToString(),
                                retrieved["Surname"].ToString(),
                                specialization);
                doctors.Add(doctor);
            }

            DatabaseConnection.GetInstance().database.Close();

            return doctors;
        }
    }
}
