using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;

namespace Tests
{
    [TestClass]
    public class Utils_UnitTests
    {
        [TestMethod]
        public void Utils_AreRectanglesIntersected_Test()
        {
            double
                x1, y1, width1, height1,
                x2, y2, width2, height2;

            // Оба прямоугольника совпадают - есть пересечение
            x1 = x2 = 0;
            y1 = y2 = 0;
            width1 = width2 = 100;
            height1 = height2 = 100;

            bool areRectanglesIntersected = Utils.AreRectanglesIntersected(
                x1, y1, width1, height1,
                x2, y2, width2, height2);
            Assert.AreEqual(true, areRectanglesIntersected);
        }

        [TestMethod]
        public void Utils_AreWPFRectanglesIntersected_Test()
        {
            double
                x1, y1, width1, height1,
                x2, y2, width2, height2;

            // Оба прямоугольника совпадают - есть пересечение
            x1 = x2 = 0;
            y1 = y2 = 0;
            width1 = width2 = 100;
            height1 = height2 = 100;

            bool areRectanglesIntersected = Utils.AreWPFRectanglesIntersected(
                x1, y1, width1, height1,
                x2, y2, width2, height2);
            Assert.AreEqual(true, areRectanglesIntersected);
        }
    }
}
