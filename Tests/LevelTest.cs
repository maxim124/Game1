using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;
namespace Tests
{
    [TestClass]
    public class LevelTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLevel_WhenNegativeDistance_ThrowsOutOfRangeException()
        {         
            double Distance = -150;
            int level = Game.GetLevel(Distance);
        }

        [TestMethod]
        public void GetLevel_WhenPositiveDistance_ReturnsLevel()
        {
            double distance = 434;
            int level = Game.GetLevel(distance);
            Assert.AreEqual(4, level);
        }

        [TestMethod]
        public void GetLevel_WhenPositiveDistance_ReturnsLevel2()
        {
            double distance = 1120;
            int level = Game.GetLevel(distance);
            Assert.AreEqual(Game.MAX_GAME_LEVEL, level);
        }
    }
}
