using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;
using System.Windows;

namespace Tests
{
    [TestClass]
    public class DedCounting_UnitTests
    {
        [TestMethod]
        public void DedCounting_GamePointToScreen_Test()
        {
            Size gameSize = new Size(100, 100);
            Size screenSize = new Size(200, 200);
            DedCounting DC = new DedCounting(gameSize, screenSize);

            Point gamePoint, expected, actual;

            // высота прыжка = 0, координата Y экрана = MAX
            gamePoint = new Point(0, 0);
            Assert.AreEqual(new Point(0, 200), DC.GamePointToScreen(gamePoint));

            // высота прыжка = 1 / 4, координата Y экрана = ?
            gamePoint = new Point(0, gameSize.Height / 4);
            expected = DC.GamePointToScreen(gamePoint);
            actual = new Point(0, screenSize.Height - screenSize.Height / 4);
            Assert.AreEqual(actual, expected);

            gamePoint = new Point(gameSize.Width / 2, gameSize.Height / 2);
            expected = DC.GamePointToScreen(gamePoint);
            actual = new Point(screenSize.Width / 2, screenSize.Height - screenSize.Height / 2);
            Assert.AreEqual(actual, expected);

            gamePoint = new Point(0, gameSize.Height);
            expected = DC.GamePointToScreen(gamePoint);
            actual = new Point(0, screenSize.Height - screenSize.Height);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DedCounting_GameRectToScreen_Test()
        {
            Size gameSize = new Size(100, 100);
            Size screenSize = new Size(100, 100);
            DedCounting DC = new DedCounting(gameSize, screenSize);
            Rect gameRect = new Rect(new Point(0, 0), new Size(10, 20));
            Rect screenRect = new Rect(new Point(0, 80), new Size(10, 20));
            Assert.AreEqual(screenRect, DC.GameRectToScreen(gameRect));
        }
    }
}
