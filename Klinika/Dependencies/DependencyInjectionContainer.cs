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

            return repos;
        }
    }
}
