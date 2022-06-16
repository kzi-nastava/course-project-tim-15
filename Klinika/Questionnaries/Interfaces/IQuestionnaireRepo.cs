using Klinika.Questionnaries.Models;

namespace Klinika.Questionnaries.Interfaces
{
    internal interface IQuestionnaireRepo
    {
        int Create(Questionnaire questionnaire);
        List<Grades> GetDoctorGrades(int doctorID, string doctorName);
        List<Grades> GetClinicGrades();
    }
}
