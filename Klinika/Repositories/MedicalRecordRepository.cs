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
    internal class MedicalRecordRepository
    {
        public static T CheckNull<T>(object obj)
        {
            return obj == DBNull.Value ? default(T) : (T)obj;
        }
        public static MedicalRecord Get(int patientID)
        {
            MedicalRecord record = new MedicalRecord();
            string getRecordQuerry = "SELECT * " +
                "FROM [Patient] " +
                $"WHERE UserID = {patientID}";
            try
            {
                SqlCommand getRecord = new SqlCommand(getRecordQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getRecord.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        record.ID = patientID;
                        record.Height = CheckNull<decimal>(retrieved["Height"]);
                        record.Weight = CheckNull<decimal>(retrieved["Weight"]);
                        record.BloodType = CheckNull<string>(retrieved["BloodType"]);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            record.Anamneses = GetAnamneses(patientID);
            return record;
        }
         
        private static List<Anamnesis> GetAnamneses(int patientID)
        {
            List<Anamnesis> anamneses = new List<Anamnesis>();

            string getAnamnesesQuerry = 
                "SELECT [Anamnesis].ID, [Anamnesis].MedicalActionID, [Anamnesis].Description, [Anamnesis].Symptoms, [Anamnesis].Conclusion " +
                "FROM [Anamnesis] JOIN [MedicalAction] ON [Anamnesis].MedicalActionID = [MedicalAction].ID " +
                $"WHERE [MedicalAction].PatientID = {patientID}";
            try
            {
                SqlCommand getAnamneses = new SqlCommand(getAnamnesesQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAnamneses.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var anamnesis = new Anamnesis
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            MedicalActionID = Convert.ToInt32(retrieved["MedicalActionID"]),
                            Description = CheckNull<string>(retrieved["Description"]),
                            Symptoms = CheckNull<string>(retrieved["Symptoms"]),
                            Conclusion = CheckNull<string>(retrieved["Conclusion"])
                        };
                        anamneses.Add(anamnesis);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return anamneses;
        }
    }
}
