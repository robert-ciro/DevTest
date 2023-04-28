namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;
    using Domain.ValueTypes;

    public class CreateTriangleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^(\d+) (\d+)$";
        
        public CreateTriangleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return new CommandResponse { ShouldQuit = false, ExecutedSuccessfully = false };
 
            var dimension = new Dimension(height: double.Parse(match.Groups[1].Value), width: double.Parse(match.Groups[2].Value));
            var triangle = new Triangle(dimension);

            surfaceAreaCalculator.Add(triangle);
            
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = $"{nameof(Triangle)} created!"
            };
        }
    }
}