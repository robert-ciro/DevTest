namespace Domain.Entities
{
    using System;

    public sealed record Square : IGeometricShape
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name => nameof(Square);

        public double SurfaceArea { get; private set; }
        public double Side { get; }

        public Square(double side)
        {
            if(side <= 0)
                throw new ArgumentException("Side must be greater than 0.");

            this.Side = side;
        }

        public double CalculateSurfaceArea()
        {
            SurfaceArea = this.Side * this.Side;
            return this.Side * this.Side;
        }
    }
}