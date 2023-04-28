namespace Refactoring.Commands
{
    public class UnknownCommand : INonParameterizedCommand
    {
        private readonly ILogger logger;

        public UnknownCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Execute()
        {
            logger.Log("Unknown command");
            return true;
        }
    }
}