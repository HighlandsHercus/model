using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokobanModel;
using Xunit;


namespace SokobanModelTests
{
    public class TestLevelHoldsName
    {
        Level level1 = new Level();


        [Fact]
        public void TestLevelDefaultName()
        {
            string expectedLevelName = "Untitled";
            string actualLevelName = level1.LevelName;
            Assert.Equal(expectedLevelName, actualLevelName);
        }


        [Fact]
        public void TestSetLevelName()
        {
            level1.LevelName = "Level1";
            string expectedLevelName = "Level1";
            string actualLevelName = level1.LevelName;
            Assert.Equal(expectedLevelName, actualLevelName);
        }
    }
}
