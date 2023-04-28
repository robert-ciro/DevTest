namespace Refactoring.Commands
{
    public interface ICommand
    {
        
    }

    public interface INonParameterizedCommand : ICommand
    {
        (bool shouldQuit, bool executedSuccesfully) Execute();
    }
    
    public interface IParameterizedCommand : ICommand
    {
        (bool shouldQuit, bool executedSuccesfully) Execute(params string[] parameters);
    }
}