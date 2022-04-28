using Klinika.Data;
using Klinika.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class RequestRepository
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
                if (retrievedRequests.Rows.Count != 0) {
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

    }
}
