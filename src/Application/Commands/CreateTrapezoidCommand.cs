namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public class CreateTrapezoidCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN = @"^(\d+) (\d+) (\d+)$";
        
        public CreateTrapezoidCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return new CommandResponse { ShouldQuit = false, ExecutedSuccessfully = false };
 
            var trapezoid = new Trapezoid(top: double.Parse(match.Groups[1].Value),
                                          bottom: double.Parse(match.Groups[2].Value),
                                          height: double.Parse(match.Groups[3].Value));

            surfaceAreaCalculator.Add(trapezoid);
            
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = $"{nameof(Trapezoid)} created!"
            };
        }
    }
}