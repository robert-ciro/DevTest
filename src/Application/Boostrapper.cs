namespace Application;

using Application.Commands;
using Domain;
using Domain.Ports;
using Infrastructure.FileDB;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static void RegisterApplicationDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection.AddTransient<SurfaceAreaCalculator>()
                         .AddTransient<SurfaceAreaCommandFactory>()
                         .AddTransient<LiteDatabase>(_ => new LiteDatabase(@"LiteDbTest.db"))
                         .AddTransient<IGeometricShapeRepository, GeometricShapeRepository>();
}