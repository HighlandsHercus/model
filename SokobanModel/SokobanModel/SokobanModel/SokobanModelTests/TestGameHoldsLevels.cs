using SokobanModel;
using Xunit;

namespace SokobanModelTests
{
    public class TestGameHoldsLevels
    {
        Game game = new Game();

        Level level1 = new Level("Level1");
        Level level2 = new Level("Level2");

        [Fact]
        public void TestGetLevelWidth()
        {
            level1.CreateLevel(10, 20);
            int expectedWidth = 10;
            int actualWidth = level1.GetLevelWidth();
            Assert.Equal(expectedWidth, actualWidth);
        }

        [Fact]
        public void TestGetLevelHeight()
        {
            level1.CreateLevel(10, 20);
            int expecteHeight = 20;
            int actualHeight = level1.GetLevelHeight();
            Assert.Equal(expecteHeight, actualHeight);
        }

        [Fact]
        public void TestGameHasNoLevels()
        {
            int expectedGameListLength = 0;
            int actualGameListLength = game.LevelList.Count;
            Assert.Equal(expectedGameListLength, actualGameListLength);
        }

        [Fact]
        public void TestGetLevelCountWithOneLevel()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(2, 0);
            level1.AddGoal(2, 2);
            level1.AddBlock(2, 1);
            game.LevelList.Add(level1);
            int expectedGameListLength = 1;
            int actualGameListLength = game.LevelList.Count;
            Assert.Equal(expectedGameListLength, actualGameListLength);
        }

        [Fact]
        public void TestGetLevelCountWithTwoLevels()
        {
            level1.CreateLevel(3, 3);
            level1.AddPlayer(2, 0);
            level1.AddGoal(2, 2);
            level1.AddBlock(2, 1);
            level2.CreateLevel(5, 6);
            game.LevelList.Add(level1);
            game.LevelList.Add(level2);
            int expectedGameListLength = 2;
            int actualGameListLength = game.LevelList.Count;
            Assert.Equal(expectedGameListLength, actualGameListLength);
        }
    }
}
