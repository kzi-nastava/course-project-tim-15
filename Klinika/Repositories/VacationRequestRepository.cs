using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class VacationRequestRepository
    {
        public static List<VacationRequest> GetAll(int doctorID)
        {
            string getAllQuerry = "SELECT * " +
                                  "FROM [VacationRequest] " +
                                  "WHERE DoctorID = @DoctorID";

            var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAllQuerry, ("@DoctorID", doctorID));
            return GenerateList(result);
        }

        public static List<VacationRequest> GetAll()
        {
            string getAllQuerry = "SELECT * " +
                                  "FROM [VacationRequest]";

            var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAllQuerry);
            return GenerateList(result);
        }


        public static int Create(VacationRequest vacationRequest)
        {
            string createQuery = "INSERT INTO [VacationRequest] " +
                "(DoctorID,FromDate,ToDate,Reason,Status,Emergency,DenyReason) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@DoctorID,@FromDate,@ToDate,@Reason,@Status,@Emergency,@DenyReason)";

            var id = (int)DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(
                createQuery,
                ("@DoctorID", vacationRequest.doctorID),
                ("@FromDate", vacationRequest.fromDate),
                ("@ToDate", vacationRequest.toDate),
                ("@Reason", vacationRequest.reason),
                ("@Status", vacationRequest.status),
                ("@Emergency", vacationRequest.emergency),
                ("@DenyReason", vacationRequest.denyReason));

            return id;
        }
        private static List<VacationRequest> GenerateList(List<object> input)
        {
            var output = new List<VacationRequest>();
            foreach (object row in input)
            {
                var vacationRequest = new VacationRequest
                (
                    id: Convert.ToInt32(((object[])row)[0].ToString()),
                    doctorID: Convert.ToInt32(((object[])row)[1].ToString()),
                    fromDate: Convert.ToDateTime(((object[])row)[2].ToString()),
                    toDate: Convert.ToDateTime(((object[])row)[3].ToString()),
                    reason: DatabaseConnection.CheckNull<string>(((object[])row)[4]),
                    status: Convert.ToChar(((object[])row)[5].ToString()),
                    emergency: DatabaseConnection.CheckNull<bool>(((object[])row)[6]),
                    denyReason: DatabaseConnection.CheckNull<string>(((object[])row)[7])
                );
                output.Add(vacationRequest);
            }
            return output;
        }


        public static void Deny(VacationRequest request)
        {
            string denyQuery = "UPDATE [VacationRequest] SET Status = 'D', DenyReason = @reason " +
                               "WHERE ID = @id";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(denyQuery, ("@id", request.id), ("@reason", request.denyReason));
        }

        public static void Approve(VacationRequest request)
        {
            string approveQuery = "UPDATE [VacationRequest] SET Status = 'A' WHERE ID = @id";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(approveQuery, ("@id", request.id));
        }
    }
}
