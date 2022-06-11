using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    internal class AnswerRepository
    {
        public static void Create(Answer answer)
        {
            string createQuerry = "INSERT INTO [ANSWER] " +
                "(QuestionnaireID,QuestionID,Grade) " +
                "VALUES(@questionnaireID, @questionID, @grade)";
            DatabaseConnection.GetInstance().ExecuteSelectCommand(createQuerry,
                ("@questionnaireID", answer.questionnaireID),
                ("@questionID", answer.questionID),
                ("@grade", answer.grade));
        }
    }
}
