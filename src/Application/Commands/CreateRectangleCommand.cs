namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;
    using Domain.ValueTypes;

    public partial class CreateRectangleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateRectangleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = ParametersRegex().Match(parameters);
            
            if (match.Success is false)
                return new();
 
            var dimension = new Dimension(height: double.Parse(match.Groups[1].Value), width: double.Parse(match.Groups[2].Value));
            var rectangle = new Rectangle(dimension);

            surfaceAreaCalculator.Add(rectangle);
            
            return new(ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Rectangle)} created!"
            };
        }

        [GeneratedRegex("^(\\d+) (\\d+)$", RegexOptions.IgnoreCase)]
        private static partial Regex ParametersRegex();
    }
}