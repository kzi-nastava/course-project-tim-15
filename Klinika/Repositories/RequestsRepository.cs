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
    internal class RequestsRepository
    {
        public static Dictionary<int, PatientModificationRequest> IdRequestPairs { get; set; }
        public static DataTable GetAll()
        {
            DataTable? retrievedRequests = null;
            IdRequestPairs = new Dictionary<int, PatientModificationRequest>();
            string getAllQuery = "SELECT [PatientRequest].ID, [User].Name + [User].Surname AS Patient " +
                                 "[MedicalAction].ID AS ExaminationID, [MedicalAction].DoctorID " +
                                 "[MedicalAction].DateTime " +
                                 "CASE " +
                                 "WHEN [PatientRequest].Type = 'D' THEN 'Delete' " +
                                 "WHEN [PatientRequest].Type = 'M' THEN 'Modify' " +
                                 "END AS RequestType, " +
                                 "[PatientRequest].Approved, [PatientsRequest].Description" +
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retrievedRequests;
        }
        

        public static 
    }
}
