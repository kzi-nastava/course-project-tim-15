using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class QuestionnaireService
    {
        public static void Send(Questionnaire questionnaire, List<Answer> answers)
        {
            
            var id = QuestionnaireRepository.Create(questionnaire);
            foreach (var answer in answers)
            {
                answer.questionnaireID = id;
                AnswerService.Create(answer);
            }
        }
    }
}
