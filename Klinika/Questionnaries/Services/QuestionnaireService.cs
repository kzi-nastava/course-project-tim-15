using Klinika.Core.Dependencies;
using Klinika.Questionnaries.Interfaces;
using Klinika.Questionnaries.Models;
using Klinika.Users.Models;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Questionnaries.Services
{
    internal class QuestionnaireService
    {
        private readonly AnswerService? answerService;
        DoctorService doctorService = StartUp.serviceProvider.GetService<DoctorService>();
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

        public List<Grades> GetAll()
        {
            List<Grades> grades = new List<Grades>();
            List<Doctor> doctors = doctorService.GetAll();
            foreach(Doctor doctor in doctors)
            {
                foreach(Grades grade in questionnaireRepo.GetDoctorGrades(doctor.id, doctor.name + " " + doctor.surname))
                {
                    grades.Add(grade);
                }
            }

            foreach (Grades grade in questionnaireRepo.GetClinicGrades())
            {
                grades.Add(grade);
            }
            return grades;
        }
        public double GetDoctorGrade(int id) => gradeRepo.GetDoctorGrade(id);
        public bool IsAppointmentGraded(int id) => gradeRepo.IsAppointmentGraded(id);
    }
}
