namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;
    using Domain.ValueTypes;

    public class CreateRectangleCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^(\d+) (\d+)$";
        
        public CreateRectangleCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return new CommandResponse{ ShouldQuit = false, ExecutedSuccessfully = false};
 
            var dimension = new Dimension(height: double.Parse(match.Groups[1].Value), width: double.Parse(match.Groups[2].Value));
            var rectangle = new Rectangle(dimension);

            surfaceAreaCalculator.Add(rectangle);
            
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = false,
                Message = $"{nameof(Rectangle)} created!"
            };
        }
    }
}