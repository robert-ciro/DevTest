using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Entities;

namespace TrapezoidTest.WhenConstructing
{
    [TestClass]
    public class GivenRadiusIsLessThanOrEqualToZero
    {
        [TestMethod]
        [DataRow(0d, 23d, 23d)]
        [DataRow(23d, -2d, 23d)]
        [DataRow(23d, 10d, -4d)]
        public void ShouldThrowArgumentException(double top, double bottom, double height) =>
            Assert.ThrowsException<ArgumentException>(() => new Trapezoid(top, bottom, height));

    }

    [TestClass]
    public class GivenValidInput
    {
        [TestMethod]
        [DataRow(44d, 23d, 23d)]
        [DataRow(23d, 32d, 23d)]
        public void ShouldSetDimensions(double top, double bottom, double height)
        {
            var trapezoid = new Trapezoid(top, bottom, height);
            Assert.AreEqual(expected: top, trapezoid.Top);
            Assert.AreEqual(expected: bottom, trapezoid.Bottom);
            Assert.AreEqual(expected: height, trapezoid.Height);
        }
    }
}

namespace TrapezoidTest
{
    using Refactoring.Entities;

    [TestClass]
    public class WhenCalculatingSurfaceArea
    {
        [TestMethod]
        [DataRow(44d, 23d, 23d, 770.5d)]
        [DataRow(23d, 32d, 23d, 632.5d)]
        public void ShouldReturnValidSurfaceArea(double top, double bottom, double height, double expectedSurfaceArea)
        {
            // Arrange
            var trapezoid = new Trapezoid(top, bottom, height);
            // Act
            var surfaceArea = trapezoid.CalculateSurfaceArea();
            // Assert
            Assert.AreEqual(expectedSurfaceArea, actual: surfaceArea);
        }
    } 
}