namespace SurfaceAreaCalculatorTest
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Domain.Entities;
    using Domain.Ports;
    using Domain.ValueTypes;
    using Moq;

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
            var geometricShapes = new List<IGeometricShape>
            {
                new Triangle(new Dimension(TriangleHeight, TriangleWidth)),
                new Circle(CircleRadius),
                new Square(SquareSide),
                new Rectangle(new Dimension(RectangleHeight, RectangleWidth)),
                new Trapezoid(TrapezoidTop, TrapezoidBottom, TrapezoidHigh)
            };
            // Arrange
            var repositoryMock = new Mock<IGeometricShapeRepository>();
            repositoryMock.Setup(exp => exp.Save(It.IsAny<IGeometricShape>()))
                          .Returns(true);
            
            repositoryMock.Setup(exp => exp.FindAll())
                          .Returns(geometricShapes);
            // Act
            var surfaceAreaCalculator = new SurfaceAreaCalculator(repositoryMock.Object);
            surfaceAreaCalculator.Add(geometricShapes.First());
            surfaceAreaCalculator.Add(geometricShapes[1]);
            surfaceAreaCalculator.Add(geometricShapes[2]);
            surfaceAreaCalculator.Add(geometricShapes[3]);
            surfaceAreaCalculator.Add(geometricShapes.Last());
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
}