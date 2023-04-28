namespace Application.Commands
{
    using Application.Dtos;

    public class ExitCommand : INonParameterizedCommand
    {
        public CommandResponse Execute()
        {
            return new CommandResponse { ShouldQuit = true, ExecutedSuccessfully = true };
        }
    }
}