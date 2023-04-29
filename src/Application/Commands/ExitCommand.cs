namespace Application.Commands
{
    using Application.Dtos;

    public class ExitCommand : INonParameterizedCommand
    {
        public CommandResponse Execute() => new (ShouldQuit: true, ExecutedSuccessfully: true);
    }
}