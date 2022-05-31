using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class QuestionnaireService
    {
        public static List<Question> GetQuestions(Question.Types type)
        {
            return QuestionnaireRepository.GetQuestions(type);
        }
        public static void Send(Questionnaire questionnaire, List<Answer> answers)
        {
            // TODO : Logic for insert in database
        }
    }
}
