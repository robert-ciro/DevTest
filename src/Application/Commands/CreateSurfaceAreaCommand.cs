namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;

    public partial class CreateSurfaceAreaCommand : IParameterizedCommand
    {
        private const string SQUARE = "square";
        private const string CIRCLE = "circle";
        private const string TRIANGLE = "triangle";
        private const string RECTANGLE = "rectangle";
        private const string TRAPEZOID = "trapezoid";
        
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateSurfaceAreaCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = GeometryShapesWithParametersRegex().Match(parameters);

            if (match.Success is false)
                return new();

            var geometryShape = match.Groups[1].Value;
            var nextParameters = match.Groups[2].Value;

            return geometryShape switch
                   {
                       SQUARE => new CreateSquareCommand(surfaceAreaCalculator).Execute(nextParameters),
                       CIRCLE => new CreateCircleCommand(surfaceAreaCalculator).Execute(nextParameters),
                       TRIANGLE => new CreateTriangleCommand(surfaceAreaCalculator).Execute(nextParameters),
                       RECTANGLE => new CreateRectangleCommand(surfaceAreaCalculator).Execute(nextParameters),
                       TRAPEZOID => new CreateTrapezoidCommand(surfaceAreaCalculator).Execute(nextParameters),
                       _ => new(ExecutedSuccessfully: false)
                   };
        }

        [GeneratedRegex($"^({SQUARE}|{CIRCLE}|{TRIANGLE}|{RECTANGLE}|{TRAPEZOID}) ?(.*)$", RegexOptions.IgnoreCase)]
        private static partial Regex GeometryShapesWithParametersRegex();
    }
}