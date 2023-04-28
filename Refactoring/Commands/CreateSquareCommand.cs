namespace Refactoring.Commands
{
    using System.Text.RegularExpressions;
    using Domain;
    using Domain.Entities;

    public class CreateSquareCommand : IParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^\d+$";
        
        public CreateSquareCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return (false, false);
 
            var square = new Square(side: double.Parse(match.Groups[0].Value));

            surfaceAreaCalculator.Add(square);
            logger.Log($"{nameof(Square)} created!");
            
            return (false, true);
        }
    }
}