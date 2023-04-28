namespace Refactoring.Commands
{
    public class SurfaceAreaCommandFactory
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;
        private readonly ILogger logger;

        public SurfaceAreaCommandFactory(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
            this.logger = logger;
        }

        public ICommand Create(string command)
        {
            switch (command.ToLower())
            {
                case "create":
                    return new CreateSurfaceAreaCommand(logger, surfaceAreaCalculator);
                case "calculate":
                    return new CalculateCommand(logger, surfaceAreaCalculator);
                case "print":
                    return new PrintCommand(logger, surfaceAreaCalculator);
                case "reset":
                    return new ResetCommand(logger, surfaceAreaCalculator);
                case "exit":
                    return new ExitCommand();
                case "show":
                    return new HelpCommand(logger);
                default:
                    return new UnknownCommand(logger);
            }
        }
    }
}