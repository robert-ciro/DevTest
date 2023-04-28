namespace Refactoring.Commands
{
    using System.Text.RegularExpressions;
    using Domain;
    using Domain.Entities;
    using Domain.ValueTypes;

    public class CreateRectangleCommand : IParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^(\d+) (\d+)$";
        
        public CreateRectangleCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return (false, false);
 
            var dimension = new Dimension(height: double.Parse(match.Groups[1].Value), width: double.Parse(match.Groups[2].Value));
            var rectangle = new Rectangle(dimension);

            surfaceAreaCalculator.Add(rectangle);
            logger.Log($"{nameof(Rectangle)} created!");
            
            return (false, true);
        }
    }
}