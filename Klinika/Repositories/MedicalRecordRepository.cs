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
        private static SqlConnection database = DatabaseConnection.GetInstance().database;
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
            record.Diseases = GetDiseases(patientID);
            record.Allergens = GetAllergens(patientID);
            return record;
        }
         
        public static List<Anamnesis> GetAnamneses(int patientID)
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
        private static List<Disease> GetDiseases(int patientID)
        {
            List<Disease> diseases = new List<Disease>();

            string getDiseasesQuerry =
                "SELECT [Disease].ID, [Disease].Name, [Disease].Description, [PatientDisease].PatientID, [PatientDisease].DateDiagnosed " +
                "FROM [Disease] JOIN [PatientDisease] ON [Disease].ID = [PatientDisease].Diseaseid " +
                $"WHERE [PatientDisease].PatientID = {patientID}";
            try
            {
                SqlCommand getDiseases = new SqlCommand(getDiseasesQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getDiseases.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var disease = new Disease
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            PatientID = Convert.ToInt32(retrieved["PatientID"]),
                            Description = CheckNull<string>(retrieved["Description"]),
                            Name = CheckNull<string>(retrieved["Name"]),
                            DateDiagnosed = CheckNull<DateTime>(retrieved["DateDiagnosed"])
                        };
                        diseases.Add(disease);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return diseases;
        }
        private static List<Ingredient> GetAllergens(int patientID)
        {
            List<Ingredient> allergens = new List<Ingredient>();
            var ingredientsIDs = GetAllergensIds(patientID);

            foreach(int id in ingredientsIDs)
            {
                var ingredient = DrugRepository.Instance.Ingredients.Where(x => x.ID == id).FirstOrDefault();
                if (ingredient != null)
                {
                    allergens.Add(ingredient);
                }
            }

            return allergens;
        }
        private static List<int> GetAllergensIds(int patientID)
        {
            List<int> IDs = new List<int>();

            string getAllergensQuerry =
                "SELECT [PatientAllergen].IngredientID " +
                "FROM [PatientAllergen] " +
                $"WHERE [PatientAllergen].PatientID = {patientID}";
            try
            {
                SqlCommand getAllergens = new SqlCommand(getAllergensQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAllergens.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var IngredientID = Convert.ToInt32(retrieved["IngredientID"]);
                        IDs.Add(IngredientID);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return IDs;
        }

        public static int CreateAnamnesis(Anamnesis anamnesis)
        {
            string createQuery = "INSERT INTO [Anamnesis] " +
                    "(MedicalActionID,Description,Symptoms,Conclusion) " +
                    "OUTPUT INSERTED.ID " +
                    "VALUES (@MedicalActionID,@Description,@Symptoms,@Conclusion)";

            SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@MedicalActionID", anamnesis.MedicalActionID);
            create.Parameters.AddWithValue("@Description", anamnesis.Description);
            create.Parameters.AddWithValue("@Symptoms", anamnesis.Symptoms);
            create.Parameters.AddWithValue("@Conclusion", anamnesis.Conclusion);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                anamnesis.ID = (int)create.ExecuteScalar();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return anamnesis.ID;
        }


        public static void Create(int patientID)
        {
            try
            {
                string createMedicalRecordQuery = "INSERT INTO [Patient] (UserID) VALUES (@ID)";
                SqlCommand createMedicalRecord = new SqlCommand(createMedicalRecordQuery, database);
                createMedicalRecord.Parameters.AddWithValue("@ID",patientID);
                database.Open();
                createMedicalRecord.ExecuteNonQuery();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }
        }
    }
}
