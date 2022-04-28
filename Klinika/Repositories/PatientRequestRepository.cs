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
        List<PatientRequest>? patientRequests = new List<PatientRequest>();

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
    }
}
