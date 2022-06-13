using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Interfaces
{
    internal interface IQuestionnaireRepo
    {
        int Create(Questionnaire questionnaire);
    }
}
