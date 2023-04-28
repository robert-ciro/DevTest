namespace Domain.Entities
{
    using Domain.ValueTypes;

    public class Rectangle : IGeometricShape
    {
        public string Name { get; } = nameof(Rectangle);
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