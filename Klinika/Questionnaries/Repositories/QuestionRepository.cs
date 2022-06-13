using Klinika.Core;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;

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
    }
}
