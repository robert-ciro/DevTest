namespace Refactoring.Commands
{
    public interface ICommand
    {
        
    }

    public interface INonParameterizedCommand : ICommand
    {
        bool Execute();
    }
    
    public interface IParameterizedCommand : ICommand
    {
        bool Execute(params string[] parameters);
    }
}