namespace Refactoring.Entities
{
    public class Square : IGeometricShape
    {
        public double Side { get; set; }

        public double CalculateSurfaceArea()
        {
            return this.Side * this.Side;
        }
    }
}