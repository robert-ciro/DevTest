namespace Refactoring.Commands
{
    using System.Text.RegularExpressions;

    public class CreateSurfaceAreaCommand : IParameterizedCommand
    {
        private const string GEOMETRY_SHAPES_WITH_PARAMETERS_PATTERN = @"^(square|circle|triangle|rectangle|trapezoid) ?(.*)$";

        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateSurfaceAreaCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute(string parameters)
        {
            var match = Regex.Match(parameters, GEOMETRY_SHAPES_WITH_PARAMETERS_PATTERN, RegexOptions.IgnoreCase);

            if (match.Success is false)
                return (false, false);

            var geometryShape = match.Groups[1].Value;
            var nextParameters = match.Groups[2].Value;

            switch (geometryShape)
            {
                case "square":
                    return new CreateSquareCommand(logger, surfaceAreaCalculator).Execute(nextParameters);
                case "circle":
                   return new CreateCircleCommand(logger, surfaceAreaCalculator).Execute(nextParameters);
                case "triangle":
                    return new CreateTriangleCommand(logger, surfaceAreaCalculator).Execute(nextParameters);
                case "rectangle":
                    return new CreateRectangleCommand(logger, surfaceAreaCalculator).Execute(nextParameters);
                case "trapezoid":
                    return new CreateTrapezoidCommand(logger, surfaceAreaCalculator).Execute(nextParameters);
                default:
                    return (false, false);
            }
        }
    }
}