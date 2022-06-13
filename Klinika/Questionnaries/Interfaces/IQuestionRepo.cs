﻿using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Interfaces
{
    internal interface IQuestionRepo
    {
        List<Question> GetByType(Question.Types type);
    }
}
