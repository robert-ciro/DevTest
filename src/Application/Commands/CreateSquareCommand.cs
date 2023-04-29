namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public partial class CreateSquareCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateSquareCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = ParameterRegex().Match(parameters);
            
            if (match.Success is false)
                return new();
 
            var square = new Square(side: double.Parse(match.Groups[0].Value));
            
            surfaceAreaCalculator.Add(square);
            
            return new(ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Square)} created!"
            };
        }

        [GeneratedRegex("^\\d+$", RegexOptions.IgnoreCase, "en-NL")]
        private static partial Regex ParameterRegex();
    }
}