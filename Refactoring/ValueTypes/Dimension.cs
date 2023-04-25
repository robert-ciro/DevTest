namespace Refactoring.ValueTypes
{
    using System;

    public sealed class Dimension
    {
        public double Height { get; }

        public double Width { get; }

        public Dimension(double height, double width)
        {
            if(height <= 0 || width <= 0)
            {
                throw new ArgumentException("Height and width must be greater than 0.");
            }
            Height = height;
            Width = width;
        }
    }
}