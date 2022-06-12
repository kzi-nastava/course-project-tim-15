﻿using Klinika.Models;

namespace Klinika.Repositories
{
    internal class AnswerRepository : Repository
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
