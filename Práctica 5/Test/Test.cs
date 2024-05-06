using System;
using NUnit.Framework;
using Game;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void IsWallAt_OutOfBounds()
        {
            // Arrange
            Board theBoard = new Board(3,3,"000 iwi 00g", 2);
            // Act
            bool isWall = theBoard.IsWallAt(-1, 0);
            // Assert
            Assert.That(isWall);
        }
    }
}