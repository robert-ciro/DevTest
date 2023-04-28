namespace Refactoring.Commands
{
    
    public class ResetCommand : INonParameterizedCommand
    {   
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public ResetCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public bool Execute()
        {
            surfaceAreaCalculator.Reset();
            logger.Log("Reset state!!");

            return true;
        }
    }
}