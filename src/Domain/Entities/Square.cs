namespace Domain.Entities
{
    using System;

    public sealed record Square : IGeometricShape
    {
        public string Name => nameof(Square);
        public double Side { get; }

        public Square(double side)
        {
            if(side <= 0)
                throw new ArgumentException("Side must be greater than 0.");

            this.Side = side;
        }

        public double CalculateSurfaceArea()
        {
            return this.Side * this.Side;
        }
    }
}