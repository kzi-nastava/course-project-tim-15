using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class AnswerService
    {
        public static void Create(Answer answer)
        {
            AnswerRepository.Create(answer);
        }
    }
}
