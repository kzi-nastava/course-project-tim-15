using Klinika.Models;

namespace Klinika.Interfaces
{
    internal interface IQuestionnaireRepo
    {
        int Create(Questionnaire questionnaire);
    }
}
