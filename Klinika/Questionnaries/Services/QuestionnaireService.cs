using Microsoft.Extensions.DependencyInjection;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;
using Klinika.Core.Dependencies;

namespace Klinika.Questionnaries.Services
{
    internal class QuestionnaireService
    {
        private readonly AnswerService? answerService;
        private readonly IQuestionnaireRepo questionnaireRepo;
        private readonly IGradeRepo gradeRepo;
        public QuestionnaireService(IQuestionnaireRepo questionnaireRepo, IGradeRepo gradeRepo)
        {
            this.questionnaireRepo = questionnaireRepo;
            this.gradeRepo = gradeRepo;
            answerService = StartUp.serviceProvider.GetService<AnswerService>();
        }
        public void Send(Questionnaire questionnaire, List<Answer> answers)
        {
            var id = questionnaireRepo.Create(questionnaire);
            foreach (var answer in answers)
            {
                answer.questionnaireID = id;
                answerService.Create(answer);
            }
        }
        public double GetDoctorGrade(int id) => gradeRepo.GetDoctorGrade(id);
        public bool IsAppointmentGraded(int id) => gradeRepo.IsAppointmentGraded(id);
    }
}
