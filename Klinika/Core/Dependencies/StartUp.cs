using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Core.Dependencies
{
    public static class StartUp
    {
        public static IServiceProvider serviceProvider { get; set; }
        public static void Init()
        {
            var _serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureRepositories()
                .BuildServiceProvider();

            serviceProvider = _serviceProvider;
        }
    }
}
