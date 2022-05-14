﻿using Klinika.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    public class ReferalRepository
    {
        public static void Create(int _patientID, int _specializationID, int _doctorID)
        {
            string createQuerry = "INSERT INTO [Referal] " +
                "(PatientID, DoctorID, SpecializationID, IsUsed, Date) " +
                $"VALUES (@PatientID, @DoctorID, @SpecializationID, @IsUsed, @Date)";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                createQuerry,
                ("@PatientID", _patientID),
                ("@DoctorID", _doctorID == -1 ? Convert.DBNull : _doctorID),
                ("@SpecializationID", _specializationID),
                ("IsUsed", false),
                ("Date", DateTime.Now));
        }


        public static DataTable GetReferralsPerPatient(int patientId)
        {
            string getReferralsQuery = "SELECT [Referal].ID, " +
                "CAST([Referal].DoctorID AS varchar) + '. ' + [User].Name + ' ' + [User].Surname 'Doctor', " +
                "[Specialization].Name 'Specialization', [Referal].Date 'Date issued',[Referal].IsUsed 'Used' " +
                "FROM [Referal]" +
                "LEFT OUTER JOIN [DoctorSpecialization] ON [Referal].DoctorID = [DoctorSpecialization].UserID " +
                "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                "LEFT OUTER JOIN [Specialization] ON [Referal].SpecializationID = [Specialization].ID " +
                "WHERE [Referal].PatientID = @patientID " +
                "ORDER BY [Referal].Date DESC";

            DataTable retrievedReferrals = DatabaseConnection.GetInstance().CreateTableOfData(getReferralsQuery, ("@patientID", patientId));
            return retrievedReferrals;
        }


        public static void MarkAsUsed(int referralID)
        {
            string markAsUsedQuerry = "UPDATE [Referal] " +
                                      "SET IsUsed = 1 " +
                                      "WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(markAsUsedQuerry, ("@ID", referralID));
        }
    }
}
