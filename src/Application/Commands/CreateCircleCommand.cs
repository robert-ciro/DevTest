namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public class CreateCircleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^\d+$";
        
        public CreateCircleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return new CommandResponse { ShouldQuit = false, ExecutedSuccessfully = false };
 
            var circle = new Circle(radius: double.Parse(match.Groups[0].Value));
            surfaceAreaCalculator.Add(circle);

            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = $"{nameof(Circle)} created!"
            };
        }
    }
}