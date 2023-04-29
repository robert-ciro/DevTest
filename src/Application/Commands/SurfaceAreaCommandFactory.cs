namespace Application.Commands
{
    using System.Text.RegularExpressions;
    using Domain;

    public partial class SurfaceAreaCommandFactory
    {
        private const string CREATE_COMMAND_NAME = "create";
        private const string CALCULATE_COMMAND_NAME = "calculate";
        private const string PRINT_COMMAND_NAME = "print";
        private const string RESET_COMMAND_NAME = "reset";
        private const string EXIT_COMMAND_NAME = "exit";
        private const string SHOW_COMMAND_NAME = "show";

        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public SurfaceAreaCommandFactory(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (ICommand command, string parameters) Create(string command)
        {
            var match = CommandRegex().Match(command);

            if (match.Success is false)
                return (new UnknownCommand(), string.Empty);

            var commandName = match.Groups[1].Value;
            var parameters = match.Groups[2].Value;

            return commandName switch
                   {
                       CREATE_COMMAND_NAME => (new CreateSurfaceAreaCommand(surfaceAreaCalculator), parameters),
                       CALCULATE_COMMAND_NAME => (new CalculateCommand(surfaceAreaCalculator), parameters),
                       PRINT_COMMAND_NAME => (new PrintCommand(surfaceAreaCalculator), parameters),
                       RESET_COMMAND_NAME => (new ResetCommand(surfaceAreaCalculator), parameters),
                       EXIT_COMMAND_NAME => (new ExitCommand(), parameters),
                       SHOW_COMMAND_NAME => (new HelpCommand(), parameters),
                       _ => (new UnknownCommand(), parameters)
                   };
        }

        [GeneratedRegex(
            $"^({CREATE_COMMAND_NAME}|{CALCULATE_COMMAND_NAME}|{PRINT_COMMAND_NAME}|{RESET_COMMAND_NAME}|{EXIT_COMMAND_NAME}|{SHOW_COMMAND_NAME}) ?(.*)$",
            RegexOptions.IgnoreCase)]
        private static partial Regex CommandRegex();
    }
}