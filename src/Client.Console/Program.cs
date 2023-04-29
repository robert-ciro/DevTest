using System;
using Microsoft.Extensions.DependencyInjection;
    
namespace Refactoring
{
    using Application;

    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            var service = serviceProvider.GetService<GeometricShapeService>()!;

            service.Start();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogger, Logger>()
                    .AddTransient<IUserInterface, ConsoleUserInterface>()
                    .AddTransient<GeometricShapeService>()
                    .RegisterApplicationDependencies();
        }
    }
}
