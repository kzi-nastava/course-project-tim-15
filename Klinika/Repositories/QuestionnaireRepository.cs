using Klinika.Models;
using Klinika.Data;

namespace Klinika.Repositories
{
    internal class QuestionnaireRepository
    {
        public static int GetGrade(int doctorID)
        {
            string getGradeQuerry = "SELECT AVG(Grade) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID = @doctorID";

            var resoult = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getGradeQuerry, ("@doctorID", doctorID));

            return Convert.ToInt32(resoult);
        }
        public static List<Question> GetQuestions(Question.Types type)
        {
            string getQuestionsQuerry = "SELECT ID, Name FROM [Question] WHERE Type = @Type";
            var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuestionsQuerry, ("@Type", (char)type));
            var questions = new List<Question>();
            foreach (object row in result)
            {
                var question = new Question(
                    Convert.ToInt32(((object[])row)[0].ToString()),
                    ((object[])row)[1].ToString(),
                    type);
                questions.Add(question);
            }
            return questions;
        }
        public static int Create(Questionnaire questionnaire)
        {
            string targe1 = questionnaire.TargetID == -1 ? "" : ",TargetID";
            string target2 = questionnaire.TargetID == -1 ? "" : ", " + questionnaire.TargetID;

            string createQuerry = "INSERT INTO [Questionnaire] " +
                $"(PatientID {targe1},Comment,MedicalActionID) " +
                "OUTPUT INSERTED.ID " +
                $"VALUES(@patientID {target2}, @comment, @medicalAction)";
            var result = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(createQuerry,
                ("@patientID", questionnaire.PatientID),
                ("@comment", questionnaire.Comment),
                ("@medicalAction", questionnaire.AppointmentID));
            return Convert.ToInt32(result);
        }

        public static void CreateAnswer (Answer answer)
        {
            string createQuerry = "INSERT INTO [ANSWER] " +
                "(QuestionnaireID,QuestionID,Grade) " +
                "VALUES(@questionnaireID, @questionID, @grade)";
            DatabaseConnection.GetInstance().ExecuteSelectCommand(createQuerry,
                ("@questionnaireID", answer.QuestionnaireID),
                ("@questionID", answer.QuestionID),
                ("@grade", answer.Grade));
        }
    }
}
