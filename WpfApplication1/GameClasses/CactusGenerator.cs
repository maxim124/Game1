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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Количество сегментов для размещения кактусов
        /// </summary>
        public int SegmentCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Получить сегмент для размещения кактусов
        /// </summary>
        /// <param name="index">индекс кактуса (порядковый номер с 0)</param>
        /// <returns></returns>
        public Segment GetSegment(int index)
        {
            throw new NotImplementedException();
        }
    }
}
