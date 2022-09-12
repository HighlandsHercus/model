using SokobanModel;
using System;
using Xunit;

namespace SokobanModelTests
{
    public class TestLevelHoldsParts
    {
        Level level1 = new Level("Level1");
        
        [Fact]
        public void TestLevelHoldsWall()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.Wall;
            level1.AddWall(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestGameHoldsEmpty()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.Empty;
            level1.AddEmpty(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestGameHoldsGoal()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.Goal;
            level1.AddGoal(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }


        [Fact]
        public void TestGameHoldsBlock()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.Block;
            level1.AddBlock(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }


        [Fact]
        public void TestGameHoldsBlockOnGoal()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.BlockOnGoal;
            level1.AddBlockOnGoal(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestGameHoldsPlayer()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.Player;
            level1.AddPlayer(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestGameHoldsPlayerOnGoal()
        {
            level1.CreateLevel(10, 20);
            Part expectedPart = Part.PlayerOnGoal;
            level1.AddPlayerOnGoal(9, 12);
            Part actualPart = level1.GetPartAtIndex(9, 12);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestGameDoesNotHoldWallOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddWall(100, 100));
        }

        [Fact]
        public void TestGameDoesNotHoldEmptyOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddEmpty(100, 100));
        }

        [Fact]
        public void TestGameDoesNotHoldGoalOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddGoal(100, 100));
        }

        [Fact]
        public void TestGameDoesNotHoldBlockOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddBlock(100, 100));
        }


        [Fact]
        public void TestGameDoesNotHoldBlockOnGoalOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddBlockOnGoal(100, 100));
        }


        [Fact]
        public void TestGameDoesNotHoldPlayerOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddPlayer(100, 100));
        }

        [Fact]
        public void TestGameDoesNotHoldPlayerOnGoalOutsideBounds()
        {
            level1.CreateLevel(10, 20);
            Assert.Throws<IndexOutOfRangeException>(() => level1.AddPlayerOnGoal(100, 100));
        }

        [Fact]
        public void TestRemoveWallAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddWall(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestRemoveGoalAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddGoal(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestRemoveBlockAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddBlock(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestRemoveBlockOnGoalAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddBlockOnGoal(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestRemovePlayerAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddPlayer(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }

        [Fact]
        public void TestRemovePlayerOnGoalAtSpecifiedLocation()
        {
            // Also Testing that there cannot be two Parts at the same Location
            // Removing means setting the location to empty
            level1.CreateLevel(8, 9);
            Part expectedPart = Part.Empty;
            level1.AddPlayerOnGoal(0, 0);
            level1.AddEmpty(0, 0);
            Part actualPart = level1.GetPartAtIndex(0, 0);
            Assert.Equal(expectedPart, actualPart);
        }


    }
}
