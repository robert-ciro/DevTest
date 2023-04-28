namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Application.Dtos;
    using Domain;
    using Domain.Entities;

    public class CreateSquareCommand : IParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private const string PARAMETERS_PATTERN =@"^\d+$";
        
        public CreateSquareCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute(string parameters)
        {
            var match = Regex.Match(parameters, PARAMETERS_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return new ();
 
            var square = new Square(side: double.Parse(match.Groups[0].Value));
            
            surfaceAreaCalculator.Add(square);
            
            return new (ExecutedSuccessfully: true)
            {
                Message = $"{nameof(Square)} created!"
            };
        }
    }
}