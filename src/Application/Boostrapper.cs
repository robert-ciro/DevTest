namespace Application;

using Application.Commands;
using Domain;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static void RegisterApplicationDependencies(this IServiceCollection serviceCollection) => 
        serviceCollection.AddTransient<SurfaceAreaCalculator>()
                         .AddTransient<SurfaceAreaCommandFactory>();
}