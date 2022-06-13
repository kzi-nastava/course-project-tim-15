using Klinika.Data;
using Klinika.Models;
using Klinika.Interfaces;

namespace Klinika.Repositories
{
    internal class QuestionnaireRepository : Repository, IQuestionnaireRepo, IGradeRepo
    {
        public int Create(Questionnaire questionnaire)
        {
            string targe1 = questionnaire.targetID == -1 ? "" : ",TargetID";
            string target2 = questionnaire.targetID == -1 ? "" : ", " + questionnaire.targetID;

            string createQuerry = "INSERT INTO [Questionnaire] " +
                $"(PatientID {targe1},Comment,MedicalActionID) " +
                "OUTPUT INSERTED.ID " +
                $"VALUES(@patientID {target2}, @comment, @medicalAction)";
            var result = database.ExecuteNonQueryScalarCommand(createQuerry,
                ("@patientID", questionnaire.patientID),
                ("@comment", questionnaire.comment),
                ("@medicalAction", questionnaire.appointmentID));
            return Convert.ToInt32(result);
        }
        public double GetDoctorGrade(int doctorID)
        {
            string getGradeQuerry = "SELECT AVG(CAST(Grade as Float)) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID = @doctorID";

            var resoult = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getGradeQuerry, ("@doctorID", doctorID));

            return Convert.ToDouble(resoult);
        }
        public bool IsAppointmentGraded (int appointmentID)
        {
            string isGradedQuerry = "SELECT COUNT(*) FROM [Questionnaire] WHERE MedicalActionID = @id";
            var result = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(isGradedQuerry, ("@id", appointmentID));
            return Convert.ToBoolean(result);
        }
    }
}
