namespace Refactoring.Commands
{
    using System.Linq;

    public class SurfaceAreaCommandExecutor
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private readonly ILogger logger;
        private readonly IUserInterface userInterface;

        public SurfaceAreaCommandExecutor(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator, IUserInterface userInterface)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
            this.logger = logger;
            this.userInterface = userInterface;
        }

        public void ExecuteCommand(string command)
        {
            string[] arrCommands = command.Split(' ');
            switch (arrCommands[0].ToLower())
            {
                case "create":
                    if (arrCommands.Length < 2 || new CreateSurfaceAreaCommand(logger, surfaceAreaCalculator).Execute(arrCommands.Skip(1).ToArray()) is false)
                    {
                        new HelpCommand(logger).Execute();
                    }
                    this.ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "calculate":
                    new CalculateCommand(logger, surfaceAreaCalculator).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "print":
                    new PrintCommand(logger, surfaceAreaCalculator).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "reset":
                    new ResetCommand(logger, surfaceAreaCalculator).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                case "exit":
                    break;
                case "show":
                    new HelpCommand(logger).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
                default:
                    ShowCommands:
                    new UnknownCommand(logger).Execute();
                    new HelpCommand(logger).Execute();
                    ExecuteCommand(userInterface.ReadMessage());
                    break;
            }
        }
    }
}