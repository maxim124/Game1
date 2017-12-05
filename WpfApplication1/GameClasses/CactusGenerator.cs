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
            // ???
            this.runSpeed = runSpeed;
            // ???
            this.jumpTime = jumpTime;
            this.manWidth = manWidth;

            // Расчет:
            // 1. Время, за которое человек пробежит видимый участок дороги
            // 2. Cколько раз может прыгнуть
            this.jumpCount = (width / runSpeed) / jumpTime;
            
        }

        /// <summary>
        /// Количество сегментов для размещения кактусов
        /// </summary>
        public int SegmentCount
        {
            get
            {
                // 3. Количество сегментов:
                // - jumpCount - 1 - целые сегменты одинаковой длины
                // - последний сегмент возможно неполный
                return (int)Math.Ceiling(jumpCount);
            }
        }

        /// <summary>
        /// Получить сегмент для размещения кактусов
        /// </summary>
        /// <param name="index">индекс кактуса (порядковый номер с 0)</param>
        /// <returns></returns>
        public Segment GetSegment(int index)
        {
            if (!(0 <= index && index < SegmentCount))
                throw new ArgumentOutOfRangeException("index");

            // 4. Длина целого сегмента, м
            double segmentLength = width / jumpCount - manWidth;
            double offset = index * segmentLength + (index + 1) * manWidth;

            //if (index < SegmentCount - 1)
            //    return new Segment { Offset = offset, Length = segmentLength };
            //else
            //    return new Segment { Offset = offset, Length =  width - offset };

            return new Segment { Offset = offset, Length = index < SegmentCount - 1 ? segmentLength : width - offset };
        }

        /// <summary>
        /// Создает кактусы
        /// </summary>
        /// <returns>созданные кактусы</returns>
        /// <remarks>
        /// Созданные кактусы распределяются по свободным сегментам случайным образом
        /// </remarks>
        public Cactus[] CreateCactuses()
        {
            // Segment segment
            //Cactus cactus = new Cactus();

            int gameLevel = 10;
            // 1. В зависимости от уровня игры определить сколько сегментов будут заняты кактусами
            //      Например, уровень 1 - 10 сегментов, 2 - 15 сегментов, и т.д.
            int usedSegmentCount = GetUsedSegmentCount(gameLevel);
            // 2. Выбрать случайным образом сегменты в соответстви с количесвом п.1
            //      Например, сегменты 12, 17, 23
            Segment[] usedSegments = GetUsedSegments(usedSegmentCount);
            // 3. В зависимости от уровня игры определить сколько минимально/максимально кактусов будет размещаться в сегменте
            //      Например, сегмент 12 - 1, 17 - 2, 23 -1
            // 4. В зависимости от уровня игры определить какой высоты кактусы ... ????

            throw new NotImplementedException();
        }

        public Segment[] GetUsedSegments(int usedSegmentCount)
        {
            throw new NotImplementedException();
        }

        public int GetUsedSegmentCount(int gameLevel)
        {
            throw new NotImplementedException();
        }

        double width, runSpeed, jumpTime, manWidth;
        double jumpCount;
    }
}
