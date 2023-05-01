using Microsoft.Extensions.DependencyInjection;
using Application;
using Client.Console;

IServiceCollection services = new ServiceCollection();

ConfigureServices(services);

IServiceProvider serviceProvider = services.BuildServiceProvider();
            
var service = serviceProvider.GetService<GeometricShapeService>()!;

service.Start();

static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ILogger, Logger>()
            .AddTransient<IUserInterface, ConsoleUserInterface>()
            .AddTransient<GeometricShapeService>()
            .RegisterApplicationDependencies();
}