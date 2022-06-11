using Klinika.Dependencies;
using Klinika.Interfaces;
using Klinika.Repositories;
using Klinika.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Klinika
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            StartUp.Init();
            Application.Run(new LoginPage());
        }

    }
}