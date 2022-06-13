using Klinika.Core;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Repositories
{
    internal class AnswerRepository : Repository, IAnswerRepo
    {
        public void Create(Answer answer)
        {
            string createQuerry = "INSERT INTO [ANSWER] " +
                "(QuestionnaireID,QuestionID,Grade) " +
                "VALUES(@questionnaireID, @questionID, @grade)";
            database.ExecuteSelectCommand(createQuerry,
                ("@questionnaireID", answer.questionnaireID),
                ("@questionID", answer.questionID),
                ("@grade", answer.grade));
        }
    }
}
