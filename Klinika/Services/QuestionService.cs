using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class QuestionService
    {
        public static List<Question> GetByType(Question.Types type)
        {
            return QuestionRepository.GetByType(type);
        }
    }
}
