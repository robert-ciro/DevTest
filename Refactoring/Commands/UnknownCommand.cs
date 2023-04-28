namespace Refactoring.Commands
{
    public class UnknownCommand : INonParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly HelpCommand helpCommand;

        public UnknownCommand(ILogger logger)
        {
            this.logger = logger;
            this.helpCommand = new HelpCommand(logger);
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute()
        {
            logger.Log("Unknown command");
            return helpCommand.Execute();
        }
    }
}