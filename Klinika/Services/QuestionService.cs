using Klinika.Repositories;
using Klinika.Models;

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
