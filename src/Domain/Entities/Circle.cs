namespace Domain.Entities
{
    using System;

    public sealed record Circle : IGeometricShape
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name => nameof(Circle);

        public double SurfaceArea { get;  private set; }
        public double Radius { get; }

        public Circle(double radius)
        {
            if(radius <= 0)
                throw new ArgumentException("Radius must be greater than 0.");

            this.Radius = radius;
        }
 
        public double CalculateSurfaceArea()
        {
            SurfaceArea = Math.Round(Math.PI * (Radius * Radius), 2);
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}