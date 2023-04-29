namespace Domain.Entities
{
    using Domain.ValueTypes;

    public sealed record Triangle(Dimension Dimension) : IGeometricShape
    {
        public string Name => nameof(Triangle);
        public double CalculateSurfaceArea()
        {
            return 0.5 * (Dimension.Height * Dimension.Width);
        }
    }

}