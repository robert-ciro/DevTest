namespace Application.Commands
{
    using System;
    using Application.Dtos;

    public class UnknownCommand : INonParameterizedCommand
    {
        public CommandResponse Execute()
        {
            return new (ExecutedSuccessfully: true)
            {
                Message = string.Join(Environment.NewLine, "Unknown command", new HelpCommand().Execute().Message)
            };
        }
    }
}