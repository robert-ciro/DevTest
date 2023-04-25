namespace Refactoring.Entities
{
    public class Rectangle : IGeometricShape
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double CalculateSurfaceArea()
        {
            return Height * Width;
        }
    }
}