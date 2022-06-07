using Klinika.Repositories;
using Klinika.Models;

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
