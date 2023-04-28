namespace Application.Commands
{
    using Application.Dtos;
    using Domain;

    public class ResetCommand : INonParameterizedCommand
    {   
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public ResetCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public CommandResponse Execute()
        {
            surfaceAreaCalculator.Reset();
            return new CommandResponse
            {
                ShouldQuit = false,
                ExecutedSuccessfully = true,
                Message = "Reset state!!"
            };
        }
    }
}