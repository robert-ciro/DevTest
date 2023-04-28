namespace Refactoring.Commands
{
    using System.Linq;

    public class PrintCommand : INonParameterizedCommand
    {
        private readonly ILogger logger;
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public PrintCommand(ILogger logger, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.logger = logger;
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }

        public (bool shouldQuit, bool executedSuccesfully) Execute()
        {
            if (surfaceAreaCalculator.SurfaceAreas.Count is 0)
            {
                logger.Log("There are no surface areas to print");
            }

            var surfaceAreasWithIndex = surfaceAreaCalculator.SurfaceAreas.Select((value, index) => (index, value));

            foreach (var (index, value) in surfaceAreasWithIndex)
            {
                var geometricShapeName = surfaceAreaCalculator.GeometricShapes[index].GetType().Name;
                logger.Log($"[{index}] {geometricShapeName} surface area is {value}");
            }

            return (false, true);
        }
    }
}