using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Services
{
    internal class AnswerService
    {
        private readonly IAnswerRepo answerRepo;
        public AnswerService(IAnswerRepo answerRepo) => this.answerRepo = answerRepo;
        public void Create(Answer answer) => answerRepo.Create(answer);
    }
}
