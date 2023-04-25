namespace Refactoring.Entities
{
    using System;

    public class Circle : IGeometricShape
    {
        public double Radius { get; set; }

        public double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}