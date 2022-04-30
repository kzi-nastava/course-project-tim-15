using Klinika.Data;
using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class PatientRequestRepository
    {
        public static void Create(PatientRequest patientRequest)
        {
            string createQuerry = "INSERT INTO [PatientRequest] " +
                "(PatientID, MedicalActionID, Type, Description, Approved)" +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PatientID, @MedicalActionID, @Type, @Description, @Approved)";

            SqlCommand create = new SqlCommand(createQuerry, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@PatientID", patientRequest.PatientID);
            create.Parameters.AddWithValue("@MedicalActionID", patientRequest.MedicalActionID);
            create.Parameters.AddWithValue("@Type", patientRequest.Type);
            create.Parameters.AddWithValue("@Description", patientRequest.Description);
            create.Parameters.AddWithValue("@Approved", patientRequest.Approved);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                patientRequest.ID = (int)create.ExecuteScalar();
                DatabaseConnection.GetInstance().database.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static int GetPersonalCount(int ID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);

            var Descriptions = GetAllDescriptions(ID);
            int counter = 0;

            foreach (string description in Descriptions)
            {
                DateTime date = DateTime.ParseExact(description.Substring(9, 10), "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                if (date > startDate)
                {
                    counter += 1;
                }
            }
            return counter;
        }
        private static List<string> GetAllDescriptions(int ID)
        {
            var Descriptions = new List<string>();

            string getDescriptionsQuerry = "SELECT Description " +
                                 "FROM [PatientRequest] " +
                                 $"WHERE PatientID = {ID}";
            try
            {
                SqlCommand getDescriptons = new SqlCommand(getDescriptionsQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getDescriptons.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        string description = retrieved["Description"].ToString();
                        Descriptions.Add(description);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Descriptions;
        }
    }
}
