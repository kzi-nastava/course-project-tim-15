using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Data;

namespace Klinika.Repositories
{
    internal class QuestionnaireRepository
    {
        public static double GetGrade(int doctorID)
        {
            string getGradeQuerry = "SELECT AVG(Grade) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID = @doctorID";

            var resoult = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getGradeQuerry, ("@doctorID", doctorID));

            return Convert.ToDouble(resoult);
        }
    }
}
