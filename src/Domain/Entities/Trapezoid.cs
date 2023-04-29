namespace Domain.Entities
{
    public class Trapezoid : IGeometricShape
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name => nameof(Trapezoid);
        
        public double SurfaceArea { get; private set; }
        public double Top { get; }
        public double Bottom { get; }
        public double Height { get; }
        
        private Trapezoid() { }
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

        public double CalculateSurfaceArea()
        {
            SurfaceArea = (Top + Bottom) * Height / 2.0;
            return (Top + Bottom) * Height / 2.0;
        }
    }
}