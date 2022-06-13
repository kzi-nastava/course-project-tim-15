using Klinika.Core;
using Klinika.Drugs.Interfaces;
using Klinika.Drugs.Models;

namespace Klinika.Drugs.Repositories
{
    public class PrescriptionRepository : Repository, IPrescriptionRepo
    {
        public PrescriptionRepository() : base() { }
        public void Create(Prescription prescription)
        {
            string createQuery = "INSERT INTO [Prescription] " +
                "(PatientID,DrugID,DateStarted,DateEnded,Interval,Comment) " +
                "VALUES (@PatientID,@DrugID,@DateStarted,@DateEnded,@Interval,@Comment)";

            database.ExecuteNonQueryCommand(
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
