using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;

namespace Tests
{
    [TestClass]
    public class Road_UnitTests
    {
        [TestMethod]
        public void Road_GetCactuses_Test()
        {
            Road road = new Road();
            double pwmDistance;
            Cactus[] cactuses;

            //pwmDistance = 25;
            //cactuses = road.GetCactuses(pwmDistance);
            //Assert.AreEqual(true, cactuses.Length > 1 && cactuses.Length < 5);
            //Assert.IsNotNull(cactuses[0]);
            //Assert.AreNotEqual(cactuses[0], cactuses[1]);


            //level = 1;
            //pwmDistance = 125;
            //cactuses = road.GetCactuses(pwmDistance);
            //Assert.AreEqual(true, cactuses.Length > 5 && cactuses.Length <= 7);
        }
    }
}
