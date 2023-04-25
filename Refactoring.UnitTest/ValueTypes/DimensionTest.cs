namespace DimensionTest.WhenConstructing
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring.ValueTypes;

    [TestClass]
    public class GivenValidInput
    {
        [TestMethod]
        [DataRow(1d, 1d)]
        [DataRow(2d, 2d)]
        public void ShouldValueBeEqual(double height, double width)
        {
            // Arrange
            var dimension = new Dimension(height, width);
            // Act
            var actualHeight = dimension.Height;
            var actualWidth = dimension.Width;
            // Assert
            Assert.AreEqual(expected: height, actualHeight);
            Assert.AreEqual(expected: width, actualWidth);
        }
    }

    [TestClass]
    public class GivenInvalidInput
    {
        [TestMethod]
        [DataRow(-1d, 1d)]
        [DataRow(-2d, -2d)]
        [DataRow(2d, -3d)]
        public void ShouldThrowException(double height, double width)
        {
            Assert.ThrowsException<ArgumentException>(() => new Dimension(height, width));
        }
    }
}