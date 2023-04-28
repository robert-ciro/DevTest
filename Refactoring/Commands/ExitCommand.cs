namespace Refactoring.Commands
{
    public class ExitCommand : INonParameterizedCommand
    {
        public (bool shouldQuit, bool executedSuccesfully) Execute()
        {
            return (true, true);
        }
    }
}