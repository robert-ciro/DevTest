namespace Refactoring.Entities
{
    using Refactoring.ValueTypes;

    public class Rectangle : IGeometricShape
    {
        public Dimension Dimension { get; } 
        
        public Rectangle(Dimension dimension)
        {
            Dimension = dimension;
        }

        public double CalculateSurfaceArea()
        {
            return Dimension.Height * Dimension.Width;
        }
    }
}