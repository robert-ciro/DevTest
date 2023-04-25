using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RectangleTest
{
    using Refactoring.Entities;
    using Refactoring.ValueTypes;

    [TestClass]
    public class WhenCalculatingSurfaceArea
    {
        [TestMethod]
        [DataRow(23d, 67d, 1541d)]
        [DataRow(55d, 33d, 1815d)]
        public void ShouldReturnValidSurfaceArea(double height, double width, double expectedSurfaceArea)
        {
            // Arrange
            var dimension = new Dimension(height, width);
            var rectangle = new Rectangle(dimension);
            // Act
            var surfaceArea = rectangle.CalculateSurfaceArea();
            // Assert
            Assert.AreEqual(expectedSurfaceArea, actual: surfaceArea);
        }
    } 
}