namespace Refactoring.Commands
{
    using Refactoring;

    public class HelpCommand : INonParameterizedCommand
    {
        private readonly ILogger logger;

        public HelpCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute()
        {
            this.logger.Log("commands:");
            this.logger.Log("- create square {double} (create a new square)");
            this.logger.Log("- create circle {double} (create a new circle)");
            this.logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            this.logger.Log("- create triangle {height} {width} (create a new triangle)");
            this.logger.Log("- print (print the calculated surface areas)");
            this.logger.Log("- calculate (calulate the surface areas of the created shapes)");
            this.logger.Log("- reset (reset)");
            this.logger.Log("- exit (exit the loop)");
            return (false, true);
        }
    }
}