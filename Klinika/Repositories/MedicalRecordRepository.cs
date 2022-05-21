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
        public static MedicalRecord Get(int patientID)
        {
            MedicalRecord record = new MedicalRecord();
            string getRecordQuerry = "SELECT * " +
                "FROM [Patient] " +
                $"WHERE UserID = {patientID}";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getRecordQuerry);
            foreach(object row in resoult)
            {
                record.ID = patientID;
                record.Height = DatabaseConnection.CheckNull<decimal>(((object[])row)[1]);
                record.Weight = DatabaseConnection.CheckNull<decimal>(((object[])row)[2]);
                record.BloodType = DatabaseConnection.CheckNull<string>(((object[])row)[3]);
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

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAnamnesesQuerry);
            foreach (object row in resoult)
            {
                var anamnesis = new Anamnesis
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    MedicalActionID = Convert.ToInt32(((object[])row)[1].ToString()),
                    Description = DatabaseConnection.CheckNull<string>(((object[])row)[2]),
                    Symptoms = DatabaseConnection.CheckNull<string>(((object[])row)[3]),
                    Conclusion = DatabaseConnection.CheckNull<string>(((object[])row)[4])
                };
                anamneses.Add(anamnesis);
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

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDiseasesQuerry);
            foreach (object row in resoult)
            {
                var disease = new Disease
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    Name = DatabaseConnection.CheckNull<string>(((object[])row)[1]),
                    Description = DatabaseConnection.CheckNull<string>(((object[])row)[2]),
                    PatientID = Convert.ToInt32(((object[])row)[3].ToString()),
                    DateDiagnosed = DatabaseConnection.CheckNull<DateTime>(((object[])row)[4])
                };
                diseases.Add(disease);
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
            List<int> ids = new List<int>();

            string getAllergensQuerry =
                "SELECT [PatientAllergen].IngredientID " +
                "FROM [PatientAllergen] " +
                $"WHERE [PatientAllergen].PatientID = {patientID}";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAllergensQuerry);
            foreach(object row in resoult)
            {
                var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                ids.Add(IngredientID);
            }

            return ids;
        }
        
        public static void CreateAnamnesis(Anamnesis anamnesis)
        {
            string createQuery = "INSERT INTO [Anamnesis] " +
                    "(MedicalActionID,Description,Symptoms,Conclusion) " +
                    "VALUES (@MedicalActionID,@Description,@Symptoms,@Conclusion)";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                createQuery,
                ("@MedicalActionID", anamnesis.MedicalActionID),
                ("@Description", anamnesis.Description),
                ("@Symptoms", anamnesis.Symptoms),
                ("@Conclusion", anamnesis.Conclusion));
        }
        public static void Create(int patientID)
        {
            string createMedicalRecordQuery = "INSERT INTO [Patient] (UserID) VALUES (@ID)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(createMedicalRecordQuery, ("@ID", patientID));
        }
    }
}
