namespace Application.Commands
{
    using Application.Dtos;
    using Domain;

    public class CalculateCommand : INonParameterizedCommand
    {
        private readonly SurfaceAreaCalculator surfaceAreaCalculator;

        public CalculateCommand(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            this.surfaceAreaCalculator = surfaceAreaCalculator;
        }
        
        public CommandResponse Execute()
        {
            surfaceAreaCalculator.CalculateSurfaceAreas();

            return new(ExecutedSuccessfully: true)
            {
                Message = "Surface areas calculated!"
            };
        }
    }
}