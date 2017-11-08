using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;

namespace Tests
{
    [TestClass]
    public class PWM_UnitTests
    {
        [TestMethod]
        public void Running_Test()
        {
            PWM pwm = new PWM();
            pwm.IsRunning = true;
            long runTime = 100;
            pwm.Run(runTime);
            Assert.AreEqual(0.2, pwm.Distance);
        }

        [TestMethod]
        public void PWM_GetRunSpeedByDistance_Test()
        {
        }
    }
}
