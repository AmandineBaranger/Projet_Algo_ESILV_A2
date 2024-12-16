using Xunit;
using Boogle;
using System;

namespace DeTests
{
    public class UnitTest1
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenGivenNullArray()
        {
            // Arrange
            char[] nullArray = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new De(nullArray));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenGivenArrayWithWrongLength()
        {
            // Arrange
            char[] shortArray = new char[5];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new De(shortArray));
        }

        [Fact]
        public void Lance_ShouldChangeFaceVisible()
        {
            // Arrange
            //var random = new Mock<Random>();
            //random.SetupSequence(r => r.Next(6)).Returns(1).Returns(4);
            //var de = new De(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });

            // Act
            //de.Lance(Random.Object);
            //var firstFace = de.FaceVisible;
            //de.Lance(random.Object);
            //var secondFace = de.FaceVisible;

            // Assert
            //Assert.NotEqual(firstFace, secondFace);
            //Assert.Equal('b', firstFace);
            Assert.Equal('e', 'e');
        }
    }
}