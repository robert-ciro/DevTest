namespace Domain.Entities
{
    using Domain.ValueTypes;

    public sealed record Triangle : IGeometricShape
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name => nameof(Triangle);

        public double SurfaceArea { get; private set; }

        public Dimension Dimension { get; init; }
        
        public Triangle(Dimension dimension)
        {
            Dimension = dimension;
        }
        
        private Triangle() { }

        public double CalculateSurfaceArea()
        {
            SurfaceArea = 0.5 * (Dimension.Height * Dimension.Width);
            return 0.5 * (Dimension.Height * Dimension.Width);
        }
    }

}