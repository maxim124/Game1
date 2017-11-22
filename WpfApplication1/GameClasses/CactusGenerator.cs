using System;

namespace WpfApplication1.GameClasses
{
    /// <summary>
    /// Генератор кактусов
    /// </summary>
    public class CactusGenerator
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="width">ширина визуальной части, м</param>
        /// <param name="runSpeed">скорость человека, м/сек</param>
        /// <param name="jumpTime">время одного прыжка человека, сек</param>
        /// <param name="manWidth">ширина человека, м</param>
        public CactusGenerator(double width, double runSpeed, double jumpTime, double manWidth)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (runSpeed <= 0)
                throw new ArgumentOutOfRangeException("runSpeed");
            if (jumpTime <= 0)
                throw new ArgumentOutOfRangeException("jumpTime");
            if (manWidth <= 0)
                throw new ArgumentOutOfRangeException("manWidth");
            if (manWidth > width)
                throw new ArgumentOutOfRangeException("manWidth,width");

            this.width = width;
            this.runSpeed = runSpeed;
            this.jumpTime = jumpTime;
            this.manWidth = manWidth;
        }

        /// <summary>
        /// Количество сегментов для размещения кактусов
        /// </summary>
        public int SegmentCount
        {
            get
            {
                // - время одного прыжка человека, сек 
                double jumptimeSeconds = jumpTime;
                // - ширина человека, м
                double manWidthMeters = manWidth;

                // Расчет:
                // 1. Время, за которое человек пробежит видимый участок дороги
                double runningSeconds = width / runSpeed;
                // 2. Cколько раз может прыгнуть
                double jumpCount = runningSeconds / jumptimeSeconds;
                // 3. Количество сегментов:
                // - jumpCount - 1 - целые сегменты одинаковой длины
                // - последний сегмент возможно неполный
                int segmentCount = (int)Math.Ceiling(jumpCount);

                return segmentCount;
            }
        }

        /// <summary>
        /// Получить сегмент для размещения кактусов
        /// </summary>
        /// <param name="index">индекс кактуса (порядковый номер с 0)</param>
        /// <returns></returns>
        public Segment GetSegment(int index)
        {
            //for(int i = 0; i <= index;i++)
            //{

            ////public Cactus[] generatedCactus = new Cactus[index];
            //}
            //// return generatedCactus;

            throw new NotImplementedException();
        }

        double width, runSpeed, jumpTime, manWidth;
    }
}
