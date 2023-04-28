namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;

    public class CreateSurfaceAreaCommand : IParameterizedCommand
    {
        private const string GEOMETRY_SHAPES_WITH_PARAMETERS_PATTERN = @"^(square|circle|triangle|rectangle|trapezoid) ?(.*)$";

        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateSurfaceAreaCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, GEOMETRY_SHAPES_WITH_PARAMETERS_PATTERN, RegexOptions.IgnoreCase);

            if (match.Success is false)
                return new CommandResponse { ShouldQuit = false, ExecutedSuccessfully = false };

            var geometryShape = match.Groups[1].Value;
            var nextParameters = match.Groups[2].Value;

            switch (geometryShape)
            {
                case "square":
                    return new CreateSquareCommand(surfaceAreaCalculator).Execute(nextParameters);
                case "circle":
                   return new CreateCircleCommand(surfaceAreaCalculator).Execute(nextParameters);
                case "triangle":
                    return new CreateTriangleCommand(surfaceAreaCalculator).Execute(nextParameters);
                case "rectangle":
                    return new CreateRectangleCommand(surfaceAreaCalculator).Execute(nextParameters);
                case "trapezoid":
                    return new CreateTrapezoidCommand(surfaceAreaCalculator).Execute(nextParameters);
                default:
                    return new CommandResponse { ShouldQuit = false, ExecutedSuccessfully = false };
            }
        }
    }
}