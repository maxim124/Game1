using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.GameClasses
{
    public class Road
    {
        //Cactus cactus = new Cactus();
        //Cactus cactus1 = new Cactus();
        public Cactus[] GetCactuses(double distance)
        {
            //Cactus[] cactuses = new Cactus[] ;
            //Cactus[] cactuses = new Cactus[2]{ cactus ,cactus1};
            Cactus[] cactuses = new Cactus[] { new Cactus(), new Cactus() };
            return cactuses;
        }

        /// <summary>
        /// Вычисление участков дороги, где могут размещаться кактусы
        /// </summary>
        /// <param name="width">ширина визуальной части, м</param>
        /// <param name="runspeed">скорость человека, мм/мсек</param>
        /// <param name="jumptime">время одного прыжка человека, мсек</param>
        /// <param name="manWidth">ширина человека, мм</param>
        /// <returns></returns>
        public static Segment[] GetCaсtusPlaces(double width, double runspeed, double jumptime, double manWidth)
        {
            // - время одного прыжка человека, сек 
            double jumptimeSeconds = jumptime / 1000;
            // - ширина человека, м
            double manWidthMeters = manWidth / 1000;

            // Расчет:
            // 1. Время, за которое человек пробежит видимый участок дороги
            double runningSeconds = width / runspeed;
            // 2. Cколько раз может прыгнуть
            double jumpCount = runningSeconds / jumptimeSeconds;
            // 3. Количество сегментов:
            // - jumpCount - 1 - целые сегменты одинаковой длины
            // - последний сегмент возможно неполный
            int segmentCount = (int)Math.Ceiling(jumpCount);
            // 4. Длина целого сегмента, м
            double segmentLength = width / jumpCount - manWidthMeters;
            // 5. Формирование сегментов
            Segment[] result = new Segment[segmentCount];
            // - все целые сегменты:
            //  смещение
            double offset = manWidthMeters;
            for (int i = 0; i < result.Length - 1; i++)
            {
                // создание объекта с помощью инициализатора
                result[i] = new Segment { Offset = offset, Length = segmentLength };
                // создание объекта с помощью конструктора
                //expected[i] = new Segment(offset, segmentLength);
                offset += segmentLength + manWidthMeters;
            }
            // - последний сегмент
            result[result.Length - 1] = new Segment { Offset = offset, Length = width - offset };

            // возврат результата
            return result;
        }

        // TODO: метод для вычисления участков дороги для размещения кактусов
        //public 
    }
}
