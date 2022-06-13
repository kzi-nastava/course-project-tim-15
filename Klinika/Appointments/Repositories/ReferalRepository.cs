using Klinika.Core;
using Klinika.Referrals;
using System.Data;

namespace Klinika.Appointments.Repositories
{
    internal class ReferalRepository : Repository, IReferralRepo
    {
        public ReferalRepository() : base() { }
        public void Create(int _patientID, int _specializationID, int _doctorID)
        {
            string createQuerry = "INSERT INTO [Referal] " +
                "(PatientID, DoctorID, SpecializationID, IsUsed, Date) " +
                $"VALUES (@PatientID, @DoctorID, @SpecializationID, @IsUsed, @Date)";

            database.ExecuteNonQueryCommand(
                createQuerry,
                ("@PatientID", _patientID),
                ("@DoctorID", _doctorID == -1 ? Convert.DBNull : _doctorID),
                ("@SpecializationID", _specializationID),
                ("IsUsed", false),
                ("Date", DateTime.Now));
        }

        public List<Referral> GetReferralsPerPatient(int patientId)
        {
            List<Referral> referrals = new List<Referral>();
            string getReferralsQuery = "SELECT [Referal].ID, " +
                "CAST([Referal].DoctorID AS varchar) + '. ' + [User].Name + ' ' + [User].Surname 'Doctor', " +
                "CAST([Referal].SpecializationID AS varchar) + '. ' + [Specialization].Name 'Specialization', [Referal].Date 'Date issued',[Referal].IsUsed 'Used' " +
                "FROM [Referal]" +
                "LEFT OUTER JOIN [DoctorSpecialization] ON [Referal].DoctorID = [DoctorSpecialization].UserID " +
                "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                "LEFT OUTER JOIN [Specialization] ON [Referal].SpecializationID = [Specialization].ID " +
                "WHERE [Referal].PatientID = @patientID " +
                "ORDER BY [Referal].Date DESC";

            DataTable retrievedReferrals = database.CreateTableOfData(getReferralsQuery, ("@patientID", patientId));
            foreach (DataRow row in retrievedReferrals.Rows)
            {
                referrals.Add(new Referral((int)row["ID"],
                                            patientId,
                                            row["Doctor"].ToString(),
                                            row["Specialization"].ToString(),
                                            (bool)row["Used"],
                                            DateTime.Parse(row["Date issued"].ToString())
                             ));
            }
            return referrals;
        }

        public void MarkAsUsed(int referralID)
        {
            string markAsUsedQuerry = "UPDATE [Referal] " +
                                      "SET IsUsed = 1 " +
                                      "WHERE ID = @ID";

            database.ExecuteNonQueryCommand(markAsUsedQuerry, ("@ID", referralID));
        }
    }
}
