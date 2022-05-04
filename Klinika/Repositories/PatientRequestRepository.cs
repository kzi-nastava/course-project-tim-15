using Klinika.Data;
using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class PatientRequestRepository
    {
        public static Dictionary<int, PatientModificationRequest> IdRequestPairs { get; set; }
        public static DataTable GetAll()
        {
            DataTable? retrievedRequests = null;
            IdRequestPairs = new Dictionary<int, PatientModificationRequest>();
            string getAllQuery = "SELECT [PatientRequest].ID, [User].Name + ' ' + [User].Surname AS Patient, " +
                                 "[MedicalAction].ID AS ExaminationID, [MedicalAction].DoctorID, " +
                                 "[MedicalAction].DateTime, " +
                                 "CASE " +
                                 "WHEN [PatientRequest].Type = 'D' THEN 'Delete' " +
                                 "WHEN [PatientRequest].Type = 'M' THEN 'Modify' " +
                                 "END AS RequestType, " +
                                 "[PatientRequest].Approved, [PatientRequest].Description " +
                                 "FROM [PatientRequest] LEFT JOIN [Patient] ON [PatientRequest].PatientID = [Patient].UserID " +
                                 "LEFT JOIN [User] ON [Patient].UserID = [User].ID " +
                                 "LEFT JOIN [MedicalAction] ON [PatientRequest].MedicalActionID = [MedicalAction].ID";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, DatabaseConnection.GetInstance().database);
                retrievedRequests = new DataTable();
                adapter.Fill(retrievedRequests);
                if (retrievedRequests.Rows.Count != 0)
                {
                    foreach (DataRow request in retrievedRequests.Rows)
                    {
                        if (request["RequestType"].ToString() == "Modify")
                        {
                            PatientModificationRequest modification = new PatientModificationRequest(
                               Convert.ToInt32(request["DoctorID"]),
                               DateTime.Parse(request["DateTime"].ToString()),
                               request["Description"].ToString()
                            );
                            IdRequestPairs.Add(Convert.ToInt32(request["ID"]), modification);
                        }
                    }
                }
                retrievedRequests.Columns.Remove("DoctorID");
                retrievedRequests.Columns.Remove("Description");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return retrievedRequests;
        }

        public static void Approve(int id)
        {
            string approveQuery = "UPDATE [PatientRequest] SET Approved = 1 WHERE ID = @ID";
            try
            {
                SqlCommand approve = new SqlCommand(approveQuery, DatabaseConnection.GetInstance().database);
                approve.Parameters.AddWithValue("@ID", id);
                DatabaseConnection.GetInstance().database.Open();
                approve.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public static void Deny(int id)
        {
            string approveQuery = "UPDATE [PatientRequest] SET Approved = 0 WHERE ID = @ID";
            try
            {
                SqlCommand approve = new SqlCommand(approveQuery, DatabaseConnection.GetInstance().database);
                approve.Parameters.AddWithValue("@ID", id);
                DatabaseConnection.GetInstance().database.Open();
                approve.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Create(PatientRequest patientRequest)
        {
            string createQuerry = "INSERT INTO [PatientRequest] " +
                "(PatientID, MedicalActionID, Type, Description)" +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PatientID, @MedicalActionID, @Type, @Description)";

            SqlCommand create = new SqlCommand(createQuerry, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@PatientID", patientRequest.PatientID);
            create.Parameters.AddWithValue("@MedicalActionID", patientRequest.MedicalActionID);
            create.Parameters.AddWithValue("@Type", patientRequest.Type);
            create.Parameters.AddWithValue("@Description", patientRequest.Description);

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
