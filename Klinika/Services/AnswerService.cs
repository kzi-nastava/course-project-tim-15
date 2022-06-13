using Klinika.Models;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class AnswerService
    {
        private readonly IAnswerRepo answerRepo;
        public AnswerService(IAnswerRepo answerRepo) => this.answerRepo = answerRepo;
        public void Create(Answer answer) => answerRepo.Create(answer);
    }
}
