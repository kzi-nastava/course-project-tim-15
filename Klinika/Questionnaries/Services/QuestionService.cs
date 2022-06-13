using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Services
{
    internal class QuestionService
    {
        private readonly IQuestionRepo questionRepo;
        public QuestionService(IQuestionRepo questionRepo) => this.questionRepo = questionRepo;
        public List<Question> GetByType(Question.Types type) => questionRepo.GetByType(type);
    }
}
