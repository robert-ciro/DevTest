namespace Domain.Entities
{
    using Domain.ValueTypes;

    public sealed record Rectangle : IGeometricShape
    {
        public Dimension Dimension { get; init; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name => nameof(Rectangle);

        public double SurfaceArea { get; private set; }
        
        public Rectangle(Dimension dimension)
        {
            Dimension = dimension;
        }
        
        private Rectangle() { }

        public double CalculateSurfaceArea() => Dimension.Height * Dimension.Width;
    }
}