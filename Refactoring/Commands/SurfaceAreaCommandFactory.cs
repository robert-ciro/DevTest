namespace Refactoring.Commands
{
    using System.Text.RegularExpressions;

    public class SurfaceAreaCommandFactory
    {
        private const string COMMAND_PATTERN = @"^(create|calculate|print|reset|exit|show) ?(.*)$";
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private readonly ILogger logger;

        public SurfaceAreaCommandFactory(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
            this.logger = logger;
        }

        public (ICommand command, string parameters) Create(string command)
        {
            var match = Regex.Match(command, COMMAND_PATTERN, RegexOptions.IgnoreCase);
            
            if (match.Success is false)
                return (new UnknownCommand(logger), string.Empty);
            
            var commandName = match.Groups[1].Value;
            var parameters =  match.Groups[2].Value;
          
            switch (commandName)
            {
                case "create":
                    return (new CreateSurfaceAreaCommand(logger, surfaceAreaCalculator), parameters);
                case "calculate":
                    return (new CalculateCommand(logger, surfaceAreaCalculator), parameters);
                case "print":
                    return (new PrintCommand(logger, surfaceAreaCalculator), parameters);
                case "reset":
                    return (new ResetCommand(logger, surfaceAreaCalculator), parameters);
                case "exit":
                    return (new ExitCommand(), parameters);
                case "show":
                    return (new HelpCommand(logger), parameters);
                default:
                    return (new UnknownCommand(logger), parameters);
            }
        }
    }
}