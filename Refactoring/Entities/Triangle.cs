namespace Refactoring.Entities
{
    using Refactoring.ValueTypes;

    public class Triangle : IGeometricShape
    {
        public Dimension Dimension { get; }

        public Triangle(Dimension dimension)
        {
            Dimension = dimension;
        }
        public double CalculateSurfaceArea()
        {
            return 0.5 * (Dimension.Height * Dimension.Width);
        }
    }

}