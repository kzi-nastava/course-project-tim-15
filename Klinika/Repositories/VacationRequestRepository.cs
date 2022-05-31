﻿using Klinika.Data;
using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static int Create(VacationRequest vacationRequest)
        {
            string createQuery = "INSERT INTO [VacationRequest] " +
                "(DoctorID,FromDate,ToDate,Reason,Status,Emergency,DenyReason) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@DoctorID,@FromDate,@ToDate,@Reason,@Status,@Emergency,@DenyReason)";

            var id = (int)DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(
                createQuery,
                ("@DoctorID", vacationRequest.DoctorID),
                ("@FromDate", vacationRequest.FromDate),
                ("@ToDate", vacationRequest.ToDate),
                ("@Reason", vacationRequest.Reason),
                ("@Status", vacationRequest.Status),
                ("@Emergency", vacationRequest.Emergency),
                ("@DenyReason", vacationRequest.DenyReason));

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
    }
}