namespace Domain.Entities
{
    using Domain.ValueTypes;

    public sealed record Rectangle(Dimension Dimension) : IGeometricShape
    {
        public string Name => nameof(Rectangle);

        public double CalculateSurfaceArea() => Dimension.Height * Dimension.Width;
    }
}