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
        public List<Doctor> GetBest()
        {
            List<Doctor> doctors = doctorService.GetAll();
            double[] bestD = new double[3];
            int[] top3 = new int[3];
            bestD[0] = -1;
            bestD[1] = -1;
            bestD[2] = -1;
            foreach (Doctor doctor in doctors)
            {
                double temp = GetDoctorGrade(doctor.id);
                if (temp > bestD[0])
                {
                    top3[2] = top3[1];
                    bestD[2] = bestD[1];
                    top3[1] = top3[0];
                    bestD[1] = bestD[0];
                    top3[0] = doctor.id;
                    bestD[0] = temp;
                }
                else if (temp > bestD[1])
                {
                    bestD[2] = bestD[1];
                    top3[2] = top3[1];
                    top3[1] = doctor.id;
                    bestD[1] = temp;
                }
                else if (temp > bestD[2])
                {
                    top3[2] = doctor.id;
                    bestD[2] = temp;
                }
            }
            List<Doctor> best = new List<Doctor>();
            best.Add(doctorService.GetById(top3[0]));
            best.Add(doctorService.GetById(top3[1]));
            best.Add(doctorService.GetById(top3[2]));
            return best;
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

        public List<Doctor> GetWorse()
        {
            List<Doctor> doctors = doctorService.GetAll();
            double[] worseD = new double[3];
            int[] top3 = new int[3];
            worseD[0] = 6;
            worseD[1] = 6;
            worseD[2] = 6;
            foreach (Doctor doctor in doctors)
            {
                double temp = GetDoctorGrade(doctor.id);
                if (temp < worseD[0])
                {
                    top3[2] = top3[1];
                    worseD[2] = worseD[1];
                    top3[1] = top3[0];
                    worseD[1] = worseD[0];
                    top3[0] = doctor.id;
                    worseD[0] = temp;
                }
                else if (temp < worseD[1])
                {
                    worseD[2] = worseD[1];
                    top3[2] = top3[1];
                    top3[1] = doctor.id;
                    worseD[1] = temp;
                }
                else if (temp < worseD[2])
                {
                    top3[2] = doctor.id;
                    worseD[2] = temp;
                }
            }
            List<Doctor> best = new List<Doctor>();
            best.Add(doctorService.GetById(top3[0]));
            best.Add(doctorService.GetById(top3[1]));
            best.Add(doctorService.GetById(top3[2]));
            return best;
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
