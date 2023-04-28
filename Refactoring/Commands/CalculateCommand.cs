namespace Refactoring.Commands
{
    using Domain;

    public class CalculateCommand : INonParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CalculateCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }
        
        public (bool shouldQuit, bool executedSuccesfully) Execute()
        {
            surfaceAreaCalculator.CalculateSurfaceAreas();
            logger.Log("Surface areas calculated!");
            return (false, true);
        }
    }
}