using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;
using System.Collections;

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

        [TestMethod]
        public void Road_GetCaсtusPlaces_Test()
        {
            // Исходные даные для теста:
            // - ширина визуальной части, м
            double width = 101;
            // - скорость человека, мм/мсек
            // int runspeed = PWM.MIN_RUN_SPEED; - нужно сделать public
            int runspeed = 2;
            // - время одного прыжка человека, мсек 
            double jumptime = PWM.JUMP_TIME;

            // Дополнительные данные:
            // - ширина человека, мм
            double manWidth = PWM.MAN_WIDTH;

            // Расчет:
            // 1. Время, за которое человек пробежит видимый участок дороги
            double runningSeconds = width / runspeed;
            // 2. Cколько раз может прыгнуть
            double jumpCount = runningSeconds / (jumptime / 1000);
            // 3. Количество сегментов:
            // - jumpCount - 1 - целые сегменты одинаковой длины
            // - последний сегмент возможно неполный
            int segmentCount = (int)Math.Ceiling(jumpCount);
            // 4. Длина целого сегмента, м
            double segmentLength = width / jumpCount - manWidth / 1000;
            // 5. Формирование сегментов
            Segment[] expected = new Segment[segmentCount];
            // - все целые сегменты
            double offset = manWidth / 1000;
            for (int i = 0; i < expected.Length - 1; i++)
            {
                expected[i] = new Segment { Offset = offset, Length = segmentLength };
                offset += segmentLength + manWidth / 1000;
            }
            // - последний сегмент
            expected[expected.Length - 1] = new Segment { Offset = offset, Length = width - offset };

            Segment[] actual = Road.GetCaсtusPlaces(width, runspeed, jumptime);

            CollectionAssert.AreEqual(expected, actual, new SegmentComparer());
        }

        class SegmentComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Segment xSegment = x as Segment;
                Segment ySegment = y as Segment;
                int compare = xSegment.Offset.CompareTo(ySegment.Offset);
                if (compare == 0)
                    compare = xSegment.Length.CompareTo(ySegment.Length);
                return compare;
            }
        }
    }
}
