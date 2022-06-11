using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Services;
using Klinika.Interfaces;
using Klinika.Repositories;

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

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection repos)
        {
            repos.AddSingleton<IVacationRequestRepo, VacationRequestRepository>();
            repos.AddSingleton<IScheduledAppointmentsRepo, AppointmentRepository>();
            repos.AddSingleton<IRoomRepo, RoomRepository>();

            return repos;
        }
    }
}
