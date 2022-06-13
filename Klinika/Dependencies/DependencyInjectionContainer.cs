using Klinika.Interfaces;
using Klinika.Repositories;
using Klinika.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Dependencies
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<VacationRequestService>();
            services.AddTransient<DoctorScheduleService>();
            services.AddTransient<RoomServices>();
            services.AddTransient<DoctorService>();
            services.AddTransient<EquipmentService>();
            services.AddTransient<DrugService>();
            services.AddTransient<AnamnesisService>();
            services.AddTransient<MedicalRecordService>();
            services.AddTransient<ReferralService>();
            services.AddTransient<PrescriptionService>();
            services.AddTransient<DoctorService>();
            services.AddTransient<PatientService>();
            services.AddTransient<SpecializationService>();
            services.AddTransient<LoginService>();
            services.AddTransient<NotificationService>();
            services.AddTransient<PatientRequestService>();
            services.AddTransient<ScheduleService>();
            services.AddTransient<UserService>();
            services.AddTransient<QuestionService>();
            services.AddTransient<AnswerService>();
            services.AddTransient<QuestionnaireService>();
            services.AddTransient<AppointmentService>();
            services.AddTransient<AppointmentRecommendationService>();
            services.AddTransient<AntiTrollService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection repos)
        {
            repos.AddSingleton<IVacationRequestRepo, VacationRequestRepository>();
            repos.AddSingleton<IScheduledAppointmentsRepo, AppointmentRepository>();
            repos.AddSingleton<IRoomRepo, RoomRepository>();
            repos.AddSingleton<IRoomEquipmentRepo, EquipmentRepository>();
            repos.AddSingleton<IDrugRepo, DrugRepository>();
            repos.AddSingleton<IReferralRepo, ReferalRepository>();
            repos.AddSingleton<IAnamnesisRepo, AnamnesisRepository>();
            repos.AddSingleton<IMedicalRecordRepo, MedicalRecordRepository>();
            repos.AddSingleton<IPrescriptionRepo, PrescriptionRepository>();
            repos.AddSingleton<IDoctorRepo,DoctorRepository>();
            repos.AddSingleton<INotificationRepo, NotificationRepository>();
            repos.AddSingleton<IPatientRepo,PatientRepository>();
            repos.AddSingleton<IPatientRequestRepo, PatientRequestRepository>();
            repos.AddSingleton<ITransferRepo, EquipmentRepository>();
            repos.AddSingleton<IUserRepo, UserRepository>();
            repos.AddSingleton<IQuestionRepo, QuestionRepository>();
            repos.AddSingleton<IAnswerRepo, AnswerRepository>();
            repos.AddSingleton<IQuestionnaireRepo, QuestionnaireRepository>();
            repos.AddSingleton<IGradeRepo, QuestionnaireRepository>();
            repos.AddSingleton<IAppointmentRepo, AppointmentRepository>();
            repos.AddSingleton<IBaseDoctorRepo, DoctorRepository>();
            repos.AddSingleton<IAppointmentRepo, AppointmentRepository>();
            repos.AddSingleton<IAntiTrollRepo, AppointmentRepository>();

            return repos;
        }
    }
}
