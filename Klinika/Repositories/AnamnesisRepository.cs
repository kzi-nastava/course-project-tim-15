using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class AnamnesisRepository
    {
        public static List<Anamnesis> Get(int patientID)
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
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    medicalActionID = Convert.ToInt32(((object[])row)[1].ToString()),
                    description = DatabaseConnection.CheckNull<string>(((object[])row)[2]),
                    symptoms = DatabaseConnection.CheckNull<string>(((object[])row)[3]),
                    conclusion = DatabaseConnection.CheckNull<string>(((object[])row)[4])
                };
                anamneses.Add(anamnesis);
            }
            return anamneses;
        }
        public static void Create(Anamnesis anamnesis)
        {
            string createQuery = "INSERT INTO [Anamnesis] " +
                    "(MedicalActionID,Description,Symptoms,Conclusion) " +
                    "VALUES (@MedicalActionID,@Description,@Symptoms,@Conclusion)";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                createQuery,
                ("@MedicalActionID", anamnesis.medicalActionID),
                ("@Description", anamnesis.description),
                ("@Symptoms", anamnesis.symptoms),
                ("@Conclusion", anamnesis.conclusion));
        }
    }
}
