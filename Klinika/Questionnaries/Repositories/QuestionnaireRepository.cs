using Klinika.Core;
using Klinika.Core.Database;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Repositories
{
    internal class QuestionnaireRepository : Repository, IQuestionnaireRepo, IGradeRepo
    {
        public List<Grades> GetDoctorGrades(int doctorID, string doctorName)
        {
            string getGradeQuerry = "SELECT [Questionnaire].ID, AVG(CAST(Grade as Float)) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID = @doctorID " +
                "GROUP BY [Questionnaire].ID";

            List<Grades> grades = new List<Grades>();
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getGradeQuerry, ("@doctorID", doctorID));
            foreach (object row in resoult)
            {
                Grades grade = new Grades
                {
                    questionnaireID = Convert.ToInt32(((object[])row)[0].ToString()),
                    avgGrade = Convert.ToDouble(((object[])row)[1].ToString()),
                    targetID = doctorID,
                    targetName = doctorName,
                    type = 'D'
                };
                grades.Add(grade);
            }

            return grades;
        }
        public int Create(Questionnaire questionnaire)
        {
            string targe1 = questionnaire.targetID == -1 ? "" : ",TargetID";
            string target2 = questionnaire.targetID == -1 ? "" : ", " + questionnaire.targetID;

            string createQuerry = "INSERT INTO [Questionnaire] " +
                $"(PatientID {targe1},Comment,MedicalActionID) " +
                "OUTPUT INSERTED.ID " +
                $"VALUES(@patientID {target2}, @comment, @medicalAction)";
            var result = database.ExecuteNonQueryScalarCommand(createQuerry,
                ("@patientID", questionnaire.patientID),
                ("@comment", questionnaire.comment),
                ("@medicalAction", questionnaire.appointmentID));
            return Convert.ToInt32(result);
        }
        public double GetDoctorGrade(int doctorID)
        {
            string getGradeQuerry = "SELECT AVG(CAST(Grade as Float)) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID = @doctorID";

            var resoult = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getGradeQuerry, ("@doctorID", doctorID));

            return Convert.ToDouble(resoult);
        }
        public bool IsAppointmentGraded(int appointmentID)
        {
            string isGradedQuerry = "SELECT COUNT(*) FROM [Questionnaire] WHERE MedicalActionID = @id";
            var result = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(isGradedQuerry, ("@id", appointmentID));
            return Convert.ToBoolean(result);
        }

        public List<Grades> GetClinicGrades()
        {
            string getGradeQuerry = "SELECT [Questionnaire].ID, AVG(CAST(Grade as Float)) " +
                "FROM [Questionnaire] JOIN [Answer] " +
                "ON [Questionnaire].ID = [Answer].QuestionnaireID " +
                "WHERE [Questionnaire].TargetID IS NULL " +
                "GROUP BY [Questionnaire].ID";

            List<Grades> grades = new List<Grades>();
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getGradeQuerry);
            foreach (object row in resoult)
            {
                Grades grade = new Grades
                {
                    questionnaireID = Convert.ToInt32(((object[])row)[0].ToString()),
                    avgGrade = Convert.ToDouble(((object[])row)[1].ToString()),
                    targetID = -1,
                    targetName = "Clinic",
                    type = 'C'
                };
                grades.Add(grade);
            }

            return grades;
        }
    }
}
