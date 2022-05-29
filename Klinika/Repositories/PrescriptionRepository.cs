using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class PrescriptionRepository
    {
        public static void Create(Prescription prescription)
        {
            string createQuery = "INSERT INTO [Prescription] " +
                "(PatientID,DrugID,DateStarted,DateEnded,Interval,Comment) " +
                "VALUES (@PatientID,@DrugID,@DateStarted,@DateEnded,@Interval,@Comment)";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                createQuery,
                ("@PatientID", prescription.PatientID),
                ("@DrugID", prescription.DrugID),
                ("@DateStarted", prescription.DateStarted),
                ("@DateEnded", prescription.DateEnded),
                ("@Interval", prescription.Interval),
                ("@Comment", prescription.Comment));
        }
    }
}
