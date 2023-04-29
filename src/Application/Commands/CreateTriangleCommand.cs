namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;
    using Domain.ValueTypes;

    public partial class CreateTriangleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        
        public CreateTriangleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = ParametersRegex().Match(parameters);
            
            if (match.Success is false)
                return new();
 
            var dimension = new Dimension(height: double.Parse(match.Groups[1].Value), width: double.Parse(match.Groups[2].Value));
            var triangle = new Triangle(dimension);

            surfaceAreaCalculator.Add(triangle);
            
            return new(ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Triangle)} created!"
            };
        }

        [GeneratedRegex("^(\\d+) (\\d+)$", RegexOptions.IgnoreCase)]
        private static partial Regex ParametersRegex();
    }
}