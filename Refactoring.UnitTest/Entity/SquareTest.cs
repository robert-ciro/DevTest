using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Entities;

namespace SquareTest.WhenConstructing
{
    [TestClass]
    public class GivenSideIsLessThanOrEqualToZero
    {
        [TestMethod]
        [DataRow(0d)]
        [DataRow(-2d)]
        public void ShouldThrowArgumentException(double side)
        {
            Assert.ThrowsException<ArgumentException>(() => new Square(side));
        }
    }

    [TestClass]
    public class GivenValidInput
    {
        [TestMethod]
        [DataRow(1d)]
        [DataRow(2d)]
        public void ShouldSetRadius(double side)
        {
            var circle = new Square(side);
            Assert.AreEqual(circle.Side, side);
        }
    }
}

namespace SquareTest
{
    using Refactoring.Entities;

    [TestClass]
    public class WhenCalculatingSurfaceArea
    {
        [TestMethod]
        [DataRow(17d, 907.92d)]
        [DataRow(23d, 1661.9d)]
        public void ShouldReturnValidSurfaceArea(double side, double expectedSide)
        {
            // Arrange
            var circle = new Circle(side);
            // Act
            var surfaceArea = circle.CalculateSurfaceArea();
            // Assert
            Assert.AreEqual(expectedSide, actual: surfaceArea);
        }
    } 
}