using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;

namespace CircleTest.WhenConstructing
{
    [TestClass]
    public class GivenRadiusIsLessThanOrEqualToZero
    {
        [TestMethod]
        [DataRow(0d)]
        [DataRow(-2d)]
        public void ShouldThrowArgumentException(double radius)
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
        }
    }

    [TestClass]
    public class GivenValidInput
    {
        [TestMethod]
        [DataRow(1d)]
        [DataRow(2d)]
        public void ShouldSetRadius(double radius)
        {
            var circle = new Circle(radius);
            Assert.AreEqual(circle.Radius, radius);
        }
    }
}

namespace CircleTest
{
    using Domain.Entities;

    [TestClass]
    public class WhenCalculatingSurfaceArea
    {
        [TestMethod]
        [DataRow(1d, 3.14d)]
        [DataRow(23d, 1661.9d)]
        public void ShouldReturnValidSurfaceArea(double radius, double expectedSurfaceArea)
        {
            // Arrange
            var circle = new Circle(radius);
            // Act
            var surfaceArea = circle.CalculateSurfaceArea();
            // Assert
            Assert.AreEqual(expectedSurfaceArea, actual: surfaceArea);
        }
    } 
}