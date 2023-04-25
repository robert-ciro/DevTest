namespace Refactoring.Entities
{
    public class Triangle : IGeometricShape
    {
        double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 0.5 * (this.height * this.width);
        }
    }

}