using SokobanModel;
using Xunit;

namespace SokobanModelTests
{
    public class TestLevelChangesWithMoves
    {
        Game game = new Game();
        Level level1 = new Level("Level1");

        [Fact]
        public void TestPlayerMoveUpOneTileAtATime()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 2);
            level1.AddGoal(2, 2);
            level1.AddBlock(2, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Up);
            int expectedX = 0;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerMoveDownOneTileAtATime()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 1);
            level1.AddGoal(2, 2);
            level1.AddBlock(2, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Down);
            int expectedX = 0;
            int expectedY = 2;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerMoveLeftOneTileAtATime()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 1);
            level1.AddGoal(2, 2);
            level1.AddBlock(2, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Left);
            int expectedX = 0;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerMoveRightOneTileAtATime()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            int expectedX = 2;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayeDeniedMovingThroughWall()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 0);
            level1.AddWall(1, 0);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            int expectedX = 0;
            int expectedY = 0;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerDeniedMovingBlockWallBehind()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 0);
            level1.AddBlock(1, 0);
            level1.AddWall(2, 0);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            int expectedX = 0;
            int expectedY = 0;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerMoveOntoGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 0);
            level1.AddGoal(1, 0);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            Part expectedPart = Part.Empty;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(0, 0);
            Part expectedPartMove = Part.PlayerOnGoal;
            Part actualPartMove = game.CurrentLevel.GetPartAtIndex(level1.Player.X, level1.Player.Y);
            int expectedX = 1;
            int expectedY = 0;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPartMove, actualPartMove);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerMoveOutofGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 0);
            level1.AddGoal(1, 0);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            game.Move(Direction.Right);
            Part expectedPart = Part.Goal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(1, 0);
            Part expectedPartMove = Part.Player;
            Part actualPartMove = game.CurrentLevel.GetPartAtIndex(level1.Player.X, level1.Player.Y);
            int expectedX = 2;
            int expectedY = 0;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPartMove, actualPartMove);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerDeniedPushingBlockWithBlockBehind()
        {
            level1.CreateLevel(4, 4);
            level1.AddPlayer(0, 0);
            level1.AddBlock(0, 1);
            level1.AddBlock(0, 2);
            level1.AddGoal(0, 3);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Down);
            Part expectedPart = Part.Goal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(0, 3);
            Part expectedPart2 = Part.Block;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(0, 1);
            int expectedX = 0;
            int expectedY = 0;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockUpOntoGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 2);
            level1.AddBlock(1, 1);
            level1.AddGoal(1, 0);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Up);
            Part expectedPart = Part.BlockOnGoal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(1, 0);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }


        [Fact]
        public void TestPlayerPushBlockUpOntoEmpty()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 2);
            level1.AddBlock(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Up);
            Part expectedPart = Part.Block;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(1, 0);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockDownOntoEmpty()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 0);
            level1.AddBlock(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Down);
            Part expectedPart = Part.Block;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(1, 2);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockDownOntoGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(1, 0);
            level1.AddBlock(1, 1);
            level1.AddGoal(1, 2);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Down);
            Part expectedPart = Part.BlockOnGoal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(1, 2);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockRightOntoEmpty()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 1);
            level1.AddBlock(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            Part expectedPart = Part.Block;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(2, 1);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockRightOntoGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(0, 1);
            level1.AddBlock(1, 1);
            level1.AddGoal(2, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Right);
            Part expectedPart = Part.BlockOnGoal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(2, 1);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockLeftOntoEmpty()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(2, 1);
            level1.AddBlock(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Left);
            Part expectedPart = Part.Block;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(0, 1);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockLeftOntoGoal()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(2, 1);
            level1.AddBlock(1, 1);
            level1.AddGoal(0, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Left);
            Part expectedPart = Part.BlockOnGoal;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(0, 1);
            Part expectedPart2 = Part.Player;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        [Fact]
        public void TestPlayerPushBlockOffGoalOntoEmpty()
        {
            level1.CreateLevel(4, 4);
            level1.AddPlayer(3, 1);
            level1.AddBlock(2, 1);
            level1.AddGoal(1, 1);
            game.AddLevel(level1);
            game.Load("Level1");
            game.Move(Direction.Left);
            game.Move(Direction.Left);
            Part expectedPart = Part.Block;
            Part actualPart = game.CurrentLevel.GetPartAtIndex(0, 1);
            Part expectedPart2 = Part.PlayerOnGoal;
            Part actualPart2 = game.CurrentLevel.GetPartAtIndex(1, 1);
            int expectedX = 1;
            int expectedY = 1;
            int actualX = game.CurrentLevel.Player.X;
            int actualY = game.CurrentLevel.Player.Y;
            Assert.Equal(expectedPart, actualPart);
            Assert.Equal(expectedPart2, actualPart2);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }
    }
}
