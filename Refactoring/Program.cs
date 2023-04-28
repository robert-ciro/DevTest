using System;

namespace Refactoring
{
    using Domain;
    using Application;
    using Application.Commands;

    class Program
    {
        static void Main(string[] args)
        {
            var commandFactory = new SurfaceAreaCommandFactory(new SurfaceAreaCalculator());
            var service = new GeometricShapeService(new Logger(), new ConsoleUserInterface(), commandFactory);
            
            service.Start();
        }
    }
}
