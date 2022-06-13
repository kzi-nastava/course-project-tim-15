using Klinika.Data;
using Klinika.Interfaces;
using Klinika.Models;
using System.Data;

namespace Klinika.Repositories
{
    internal class PatientRequestRepository : Repository, IPatientRequestRepo
    {
        public List<PatientRequest>? allRequests { get; private set; }

        public PatientRequestRepository()
        {
            allRequests = GetAll();
        }
        
        public List<PatientRequest>? GetAll()
        {
            string getAllQuery = "SELECT * FROM [PatientRequest]";
            
            DataTable retrievedRequests = database.CreateTableOfData(getAllQuery);
            List<PatientRequest> requests = new List<PatientRequest>();

            foreach (DataRow request in retrievedRequests.Rows)
            {
                bool? isApproved = null;
                if (!DBNull.Value.Equals(request["Approved"])) isApproved = (bool)request["Approved"];
                requests.Add(new PatientRequest((int)request["ID"],
                                                (int)request["PatientID"],
                                                (int)request["MedicalActionID"],
                                                Convert.ToChar(request["Type"]),
                                                request["Description"].ToString(),
                                                isApproved
                             ));
            }

            return requests;
        }

        public void Approve(int id)
        {
            string approveQuery = "UPDATE [PatientRequest] SET Approved = 1 WHERE ID = @ID";
            database.ExecuteNonQueryCommand(approveQuery, ("@ID", id));
        }

        public void Deny(int id)
        {
            string denyQuery = "UPDATE [PatientRequest] SET Approved = 0 WHERE ID = @ID";
            database.ExecuteNonQueryCommand(denyQuery, ("@ID", id));
        }

        public void Create(PatientRequest patientRequest)
        {
            string createQuerry = "INSERT INTO [PatientRequest] " +
                "(PatientID, MedicalActionID, Type, Description)" +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PatientID, @MedicalActionID, @Type, @Description)";

            patientRequest.id = (int)database.ExecuteNonQueryScalarCommand(
                                                                        createQuerry,
                                                                        ("@PatientID", patientRequest.patientID),
                                                                        ("@MedicalActionID", patientRequest.medicalActionID),
                                                                        ("@Type", patientRequest.type),
                                                                        ("@Description", patientRequest.description)
                );
        }

    }
}
