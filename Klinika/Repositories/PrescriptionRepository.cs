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
                ("@PatientID", prescription.patientID),
                ("@DrugID", prescription.drugID),
                ("@DateStarted", prescription.dateStarted),
                ("@DateEnded", prescription.dateEnded),
                ("@Interval", prescription.interval),
                ("@Comment", prescription.comment));
        }
    }
}
