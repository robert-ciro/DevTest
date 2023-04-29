namespace Domain.Entities
{
    using System;

    public sealed record Circle : IGeometricShape
    {
        public string Name => nameof(Circle);
        public double Radius { get; }

        public Circle(double radius)
        {
            if(radius <= 0)
                throw new ArgumentException("Radius must be greater than 0.");

            this.Radius = radius;
        }
 
        public double CalculateSurfaceArea() => Math.Round(Math.PI * (Radius * Radius), 2);
    }
}