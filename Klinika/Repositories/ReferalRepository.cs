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
                "(PatientID, DoctorID, SpecializationID) " +
                $"VALUES (@PatientID, @DoctorID, @SpecializationID)";

            SqlCommand create = new SqlCommand(createQuerry, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@PatientID", _patientID);
            create.Parameters.AddWithValue("@DoctorID", _doctorID == -1 ? Convert.DBNull : _doctorID);
            create.Parameters.AddWithValue("@SpecializationID", _specializationID);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static DataTable GetReferralsPerPatient(int patientId)
        {
            DataTable retrievedReferrals = null;
            string getReferralsQuery = "SELECT [Referal].ID, " +
                "CAST([Referal].DoctorID AS varchar) + '. ' + [User].Name + ' ' + [User].Surname 'Doctor', " +
                "[Specialization].Name 'Specialization', [Referal].Date 'Date issued' " +
                "FROM [Referal]" +
                "LEFT OUTER JOIN [DoctorSpecialization] ON [Referal].DoctorID = [DoctorSpecialization].UserID " +
                "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                "LEFT OUTER JOIN [Specialization] ON [Referal].SpecializationID = [Specialization].ID " +
                "WHERE [Referal].PatientID = @patientID " +
                "ORDER BY [Referal].Date DESC";
            try
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(getReferralsQuery, DatabaseConnection.GetInstance().database);
                adapter.SelectCommand.Parameters.AddWithValue("@patientID", patientId);
                retrievedReferrals = new DataTable();
                adapter.Fill(retrievedReferrals);
            }

            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return retrievedReferrals;
        }
    }
}
