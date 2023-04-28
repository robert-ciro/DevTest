namespace Refactoring.Commands
{
    using System.Text.RegularExpressions;
    using Refactoring.Entities;

    public class CreateTrapezoidCommand : IParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN = @"^(\d+) (\d+) (\d+)$";
        
        public CreateTrapezoidCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return (false, false);
 
            var trapezoid = new Trapezoid(top: double.Parse(match.Groups[1].Value),
                                          bottom: double.Parse(match.Groups[2].Value),
                                          height: double.Parse(match.Groups[3].Value));

            surfaceAreaCalculator.Add(trapezoid);
            logger.Log($"{nameof(Trapezoid)} created!");
            
            return (false, true);
        }
    }
}