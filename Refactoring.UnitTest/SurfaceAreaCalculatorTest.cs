namespace SurfaceAreaCalculatorTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;
    using Refactoring.Entities;
    using Refactoring.ValueTypes;

    [TestClass]
    public class WhenCalculatingSurfaceAreas
    {
        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double TriangleSurfaceArea = 221d;
        private const double CircleRadius = 23d;
        private const double CircleSurfaceArea = 1661.9d;
        private const double SquareSide = 17d;
        private const double SquareSurfaceArea = 289d;
        private const double RectangleHeight = 23d;
        private const double RectangleWidth = 67d;
        private const double RectangleSurfaceArea = 1541d;
        private const double TrapezoidTop = 44d;
        private const double TrapezoidBottom = 23d;
        private const double TrapezoidHigh = 23d;
        private const double TrapezoidSurfaceArea = 770.5d;
        
        [TestMethod]
        public void ShouldReturnValidSurfaceAreas()
        {
            // Arrange
            var triangleDimension = new Dimension(TriangleHeight, TriangleWidth);
            var triangle = new Triangle(triangleDimension);
            var circle = new Circle(CircleRadius);
            var square = new Square(SquareSide);
            var dimension = new Dimension(RectangleHeight, RectangleWidth);
            var rectangle = new Rectangle(dimension);
            var trapezoid = new Trapezoid(TrapezoidTop, TrapezoidBottom, TrapezoidHigh);

            // Act
            var surfaceAreaCalculator = new SurfaceAreaCalculator(new YummyLogger());
            surfaceAreaCalculator.Add(triangle);
            surfaceAreaCalculator.Add(circle);
            surfaceAreaCalculator.Add(square);
            surfaceAreaCalculator.Add(rectangle);
            surfaceAreaCalculator.Add(trapezoid);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            var surfaceAreas = surfaceAreaCalculator.SurfaceAreas;
            // Assert
            Assert.AreEqual(expected: TriangleSurfaceArea, surfaceAreas[0]);
            Assert.AreEqual(expected: CircleSurfaceArea, surfaceAreas[1]);
            Assert.AreEqual(expected: SquareSurfaceArea, surfaceAreas[2]);
            Assert.AreEqual(expected: RectangleSurfaceArea, surfaceAreas[3]);
            Assert.AreEqual(expected: TrapezoidSurfaceArea, surfaceAreas[4]);
        }
    }
    
    internal class YummyLogger : ILogger
    {
        public void Log(string pLog)
        {
        }
    }
}