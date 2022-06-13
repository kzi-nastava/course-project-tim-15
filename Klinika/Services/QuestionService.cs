using Klinika.Models;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class QuestionService
    {
        private readonly IQuestionRepo questionRepo;
        public QuestionService(IQuestionRepo questionRepo) => this.questionRepo = questionRepo;
        public List<Question> GetByType(Question.Types type) => questionRepo.GetByType(type);
    }
}
