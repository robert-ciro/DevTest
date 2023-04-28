namespace Application.Dtos
{
    public class CommandResponse
    {
        public bool ExecutedSuccessfully { get; set; }
        public bool ShouldQuit { get; set; }
        
        public string Message { get; set; }
    }
}