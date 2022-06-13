using Klinika.Core;
using Klinika.Core.Database;
using Klinika.MedicalRecords.Interfaces;
using Klinika.MedicalRecords.Models;

namespace Klinika.MedicalRecords.Repositories
{
    public class AnamnesisRepository : Repository, IAnamnesisRepo
    {
        public AnamnesisRepository() : base() { }
        public List<Anamnesis> GetAll(int patientID)
        {
            List<Anamnesis> anamneses = new List<Anamnesis>();

            string getAnamnesesQuerry =
                "SELECT [Anamnesis].ID, [Anamnesis].MedicalActionID, [Anamnesis].Description, [Anamnesis].Symptoms, [Anamnesis].Conclusion " +
                "FROM [Anamnesis] JOIN [MedicalAction] ON [Anamnesis].MedicalActionID = [MedicalAction].ID " +
                $"WHERE [MedicalAction].PatientID = {patientID}";

            var resoult = database.ExecuteSelectCommand(getAnamnesesQuerry);
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
        public void Create(Anamnesis anamnesis)
        {
            string createQuery = "INSERT INTO [Anamnesis] " +
                    "(MedicalActionID,Description,Symptoms,Conclusion) " +
                    "VALUES (@MedicalActionID,@Description,@Symptoms,@Conclusion)";

            database.ExecuteNonQueryCommand(
                createQuery,
                ("@MedicalActionID", anamnesis.medicalActionID),
                ("@Description", anamnesis.description),
                ("@Symptoms", anamnesis.symptoms),
                ("@Conclusion", anamnesis.conclusion));
        }
    }
}
