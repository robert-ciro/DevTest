namespace Refactoring.Entities
{
    using System;

    public class Circle : IGeometricShape
    {
        public string Name { get; } = nameof(Circle);
        public double Radius { get; }

        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentException("Radius must be greater than 0.");
            }
            
            this.Radius = radius;
        }
        
        public double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}