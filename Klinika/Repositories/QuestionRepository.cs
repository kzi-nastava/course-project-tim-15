using Klinika.Models;
using Klinika.Data;

namespace Klinika.Repositories
{
    internal class QuestionRepository
    {
        public static List<Question> GetByType(Question.Types type)
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
