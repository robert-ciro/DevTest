namespace Application.Commands
{
    using System;
    using System.Linq;
    using Application.Dtos;
    using Domain;

    public class PrintCommand : INonParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public PrintCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute()
        {
            if (surfaceAreaCalculator.SurfaceAreas.Count is 0)
                return new CommandResponse
                {
                    ShouldQuit = false,
                    ExecutedSuccessfully = false,
                    Message =  "There are no surface areas to print"
                };

            var geometricShape = surfaceAreaCalculator.GeometricShapes;
            var messageBySurfaceArea = surfaceAreaCalculator.SurfaceAreas
                                               .Select((value, index) => (index, value))
                                               .Select(
                                                   tuple =>
                                                       $"[{tuple.index}] {geometricShape[tuple.index].Name} surface area is {tuple.value}")
                                               .ToArray();
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = string.Join(Environment.NewLine, messageBySurfaceArea)
            };
        }
    }
}