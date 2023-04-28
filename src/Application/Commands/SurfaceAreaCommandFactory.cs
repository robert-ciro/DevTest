namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Domain;

    public class SurfaceAreaCommandFactory
    {
        private const string COMMAND_PATTERN = @"^(create|calculate|print|reset|exit|show) ?(.*)$";
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public SurfaceAreaCommandFactory(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (ICommand command, string parameters) Create(string command)
        {
            var match = Regex.Match(command, COMMAND_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return (new UnknownCommand(), string.Empty);
            
            var commandName = match.Groups[1].Value;
            var parameters =  match.Groups[2].Value;
          
            switch (commandName)
            {
                case "create":
                    return (new CreateSurfaceAreaCommand(surfaceAreaCalculator), parameters);
                case "calculate":
                    return (new CalculateCommand(surfaceAreaCalculator), parameters);
                case "print":
                    return (new PrintCommand(surfaceAreaCalculator), parameters);
                case "reset":
                    return (new ResetCommand(surfaceAreaCalculator), parameters);
                case "exit":
                    return (new ExitCommand(), parameters);
                case "show":
                    return (new HelpCommand(), parameters);
                default:
                    return (new UnknownCommand(), parameters);
            }
        }
    }
}