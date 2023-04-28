namespace Application.Dtos
{
    public record CommandResponse(bool ExecutedSuccessfully = false, bool ShouldQuit = false, string Message = "");
}