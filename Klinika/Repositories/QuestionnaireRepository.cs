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
    }
}
