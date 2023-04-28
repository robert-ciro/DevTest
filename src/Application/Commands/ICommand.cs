namespace Application.Commands
{
    using Application.Dtos;

    public interface ICommand
    {
        
    }

    public interface INonParameterizedCommand : ICommand
    {
        CommandResponse Execute();
    }
    
    public interface IParameterizedCommand : ICommand 
    {
        CommandResponse Execute(string parameters);
    }
}