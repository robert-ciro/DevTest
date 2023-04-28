namespace Application.Dtos
{
    using System;

    public interface IQuitCommandResponse
    {
        bool ShouldQuit { get; set; }
    }
    
    public interface IExecutionCommandResponse
    {
        bool ExecutedSuccessfully { get; set; }
    }
    
    public class CommandResponse: IExecutionCommandResponse, IQuitCommandResponse
    {
        public bool ExecutedSuccessfully { get; set; }
        public bool ShouldQuit { get; set; }
        
        public string Message { get; set; }
    }
}