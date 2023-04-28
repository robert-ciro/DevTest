namespace Domain.Entities
{
    public class Trapezoid : IGeometricShape
    {
        public string Name { get; } = nameof(Trapezoid);
        public double Top { get; }
        public double Bottom { get; }
        public double Height { get; }
        
        public Trapezoid(double top, double bottom, double height)
        {
            if (top <= 0 || bottom <= 0 || height <= 0)
            {
                throw new System.ArgumentException("Top, bottom, and height must be greater than 0.");
            }
            
            Top = top;
            Bottom = bottom;
            Height = height;
        }
        public double CalculateSurfaceArea() => (Top + Bottom) * Height / 2.0;
    }
}