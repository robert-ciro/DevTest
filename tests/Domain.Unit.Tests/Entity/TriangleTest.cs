using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleTest
{
    using Domain.Entities;
    using Domain.ValueTypes;

    [TestClass]
    public class WhenCalculatingSurfaceArea
    {
        [TestMethod]
        [DataRow(13d, 34d, 221d)]
        [DataRow(43d, 54d, 1161d)]
        public void ShouldReturnValidSurfaceArea(double height, double width, double expectedSurfaceArea)
        {
            // Arrange
            var dimension = new Dimension(height, width);
            var triangle = new Triangle(dimension);
            // Act
            var surfaceArea = triangle.CalculateSurfaceArea();
            // Assert
            Assert.AreEqual(expectedSurfaceArea, actual: surfaceArea);
        }
    } 
}