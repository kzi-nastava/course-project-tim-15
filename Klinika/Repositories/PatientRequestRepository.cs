using Klinika.Data;
using Klinika.Models;
using System.Data;

namespace Klinika.Repositories
{
    internal class PatientRequestRepository : Repository
    {
        public static List<PatientRequest> allRequests { get; private set; }

        public PatientRequestRepository()
        {
            allRequests = GetAll();
        }
        
        public static List<PatientRequest>? GetAll()
        {
            string getAllQuery = "SELECT * FROM [PatientRequest]";
            
            DataTable retrievedRequests = DatabaseConnection.GetInstance().CreateTableOfData(getAllQuery);
            List<PatientRequest> requests = new List<PatientRequest>();

            foreach (DataRow request in retrievedRequests.Rows)
            {
                bool? isApproved = null;
                if (!DBNull.Value.Equals(request["Approved"])) isApproved = (bool)request["Approved"];
                requests.Add(new PatientRequest((int)request["ID"],
                                                (int)request["PatientID"],
                                                (int)request["MedicalActionID"],
                                                (char)request["Type"],
                                                request["Description"].ToString(),
                                                isApproved
                             ));
            }

            return requests;
        }

        public static void Approve(int id)
        {
            string approveQuery = "UPDATE [PatientRequest] SET Approved = 1 WHERE ID = @ID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(approveQuery, ("@ID", id));
        }

        public static void Deny(int id)
        {
            string denyQuery = "UPDATE [PatientRequest] SET Approved = 0 WHERE ID = @ID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(denyQuery, ("@ID", id));
        }

        public static void Create(PatientRequest patientRequest)
        {
            string createQuerry = "INSERT INTO [PatientRequest] " +
                "(PatientID, MedicalActionID, Type, Description)" +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PatientID, @MedicalActionID, @Type, @Description)";

            patientRequest.id = (int)DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(
                                                                        createQuerry,
                                                                        ("@PatientID", patientRequest.patientID),
                                                                        ("@MedicalActionID", patientRequest.medicalActionID),
                                                                        ("@Type", patientRequest.type),
                                                                        ("@Description", patientRequest.description)
                );
        }


    }
}
