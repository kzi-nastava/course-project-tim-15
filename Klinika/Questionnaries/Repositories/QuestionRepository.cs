using Klinika.Core;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;
using Klinika.Core.Database;

namespace Klinika.Questionnaries.Repositories
{
    public class QuestionRepository : Repository, IQuestionRepo
    {
        public List<Question> GetByType(Question.Types type)
        {
            string getQuestionsQuerry = "SELECT ID, Name FROM [Question] WHERE Type = @Type";
            var result = database.ExecuteSelectCommand(getQuestionsQuerry, ("@Type", (char)type));
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

        public List<Details> GetById(int qID, int targetID)
        {
            List<Details> details = new List<Details>();
            string getGradeQuerry = "SELECT [Question].ID, [Question].Name, COUNT(Grade) " +
                "FROM [Questionnaire], [Answer], [Question] " +
                "WHERE [Questionnaire].TargetID = @targetID AND " +
                "[Answer].QuestionID = [Question].ID AND [Answer].QuestionnaireID = [Questionnaire].ID " +
                "" +
                "GROUP BY [Questionnaire].TargetID, [Question].ID";

            /*var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getGradeQuerry, ("@targetID", targetID));
            foreach (object row in resoult)
            {
                Grades grade = new Grades
                {
                    questionnaireID = Convert.ToInt32(((object[])row)[0].ToString()),
                    avgGrade = Convert.ToDouble(((object[])row)[1].ToString()),
                    targetID = doctorID,
                    targetName = doctorName,
                    type = 'D'
                };
                grades.Add(grade);
            }*/
            return details;
        }
    }
}
