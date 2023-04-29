namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public partial class CreateCircleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CreateCircleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = ParameterRegex().Match(parameters);

            if (match.Success is false)
                return new();

            var circle = new Circle(radius: double.Parse(match.Groups[0].Value));
            surfaceAreaCalculator.Add(circle);

            return new(ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Circle)} created!"
            };
        }

        [GeneratedRegex("^\\d+$", RegexOptions.IgnoreCase)]
        private static partial Regex ParameterRegex();
    }
}