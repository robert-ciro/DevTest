namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public partial class CreateTrapezoidCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        
        public CreateTrapezoidCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = ParametersRegex().Match(parameters);
            
            if (match.Success is false)
                return new();
 
            var trapezoid = new Trapezoid(top: double.Parse(match.Groups[1].Value),
                                          bottom: double.Parse(match.Groups[2].Value),
                                          height: double.Parse(match.Groups[3].Value));

            surfaceAreaCalculator.Add(trapezoid);
            
            return new(ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Trapezoid)} created!"
            };
        }

        [GeneratedRegex("^(\\d+) (\\d+) (\\d+)$", RegexOptions.IgnoreCase, "en-NL")]
        private static partial Regex ParametersRegex();
    }
}