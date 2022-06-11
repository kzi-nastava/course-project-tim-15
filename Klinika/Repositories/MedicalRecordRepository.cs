using Klinika.Data;
using Klinika.Interfaces;
using Klinika.Models;
namespace Klinika.Repositories
{
    internal class MedicalRecordRepository : Repository, IMedicalRecordRepo
    {
        private readonly IAnamnesisRepo anamnesisRepo;
        public MedicalRecordRepository() : base()
        {
            anamnesisRepo = new AnamnesisRepository();
        }
        public MedicalRecord Get(int patientID)
        {
            MedicalRecord record = new MedicalRecord();
            string getRecordQuerry = "SELECT * " +
                "FROM [Patient] " +
                $"WHERE UserID = {patientID}";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getRecordQuerry);
            foreach(object row in resoult)
            {
                record.id = patientID;
                record.height = DatabaseConnection.CheckNull<decimal>(((object[])row)[1]);
                record.weight = DatabaseConnection.CheckNull<decimal>(((object[])row)[2]);
                record.bloodType = DatabaseConnection.CheckNull<string>(((object[])row)[3]);
            }

            record.anamneses = anamnesisRepo.GetAll(patientID);
            record.diseases = GetDiseases(patientID);
            record.allergens = GetAllergens(patientID);

            return record;
        }
        public void Create(int patientID)
        {
            string createMedicalRecordQuery = "INSERT INTO [Patient] (UserID) VALUES (@ID)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(createMedicalRecordQuery, ("@ID", patientID));
        }
        private List<Disease> GetDiseases(int patientID)
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
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    name = DatabaseConnection.CheckNull<string>(((object[])row)[1]),
                    description = DatabaseConnection.CheckNull<string>(((object[])row)[2]),
                    patientID = Convert.ToInt32(((object[])row)[3].ToString()),
                    dateDiagnosed = DatabaseConnection.CheckNull<DateTime>(((object[])row)[4])
                };
                diseases.Add(disease);
            }
            return diseases;
        }
        private List<Ingredient> GetAllergens(int patientID)
        {
            List<Ingredient> allergens = new List<Ingredient>();
            var ingredientsIDs = GetAllergensIds(patientID);

            foreach(int id in ingredientsIDs)
            {
                var ingredient = IngredientRepository.Instance.ingredients.Where(x => x.id == id).FirstOrDefault();
                if (ingredient != null)
                {
                    allergens.Add(ingredient);
                }
            }

            return allergens;
        }
        private List<int> GetAllergensIds(int patientID)
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
    }
}
