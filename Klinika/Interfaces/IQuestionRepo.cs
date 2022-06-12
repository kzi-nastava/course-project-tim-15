using Klinika.Models;

namespace Klinika.Interfaces
{
    internal interface IQuestionRepo
    {
        List<Question> GetByType(Question.Types type);
    }
}
