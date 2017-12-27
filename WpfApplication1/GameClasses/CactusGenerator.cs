using System;
using System.Collections.Generic;

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

            // Мышление:
            // 1.
            //int minCactus = Fмин(ширинаСегмента, ширинаКактуса, уровеньИгры);
            //int maxCactus = Fмакс(ширинаСегмента, ширинаКактуса, уровеньИгры);
            // 2.
            // ширинаКактуса = константа
            // 3. Эквивалент п.1 - вместо 2-х строк одна
            // (minCactus, maxCactus) = Fмин_макс(ширинаСегмента, ширинаКактуса, уровеньИгры);
            // 4.
            // Ширина человека не важна, т.к. сегменты уже разделены нужными зазорами
            // Реализация:
            double segment_length = usedSegments[0].Length;
            MinMax minMax = min_max(segment_length, Cactus.WIDTH, gameLevel);

            // 4. В зависимости от уровня игры определить какой высоты кактусы ... ????

            throw new NotImplementedException();
        }

        private MinMax min_max(double segment_length, double cactus_length, int gameLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usedSegmentCount"></param>
        /// <returns>упорядоченный массив уникальных сегментов</returns>
        public Segment[] GetUsedSegments(int usedSegmentCount)
        {
            // проверить usedSegmentCount
            if (!(0 <= usedSegmentCount && usedSegmentCount < SegmentCount))
                throw new ArgumentOutOfRangeException("usedSegmentCount");

            // создать упорядоченный список для формирования уникальных индексов сегментов
            List<int> segmentIndecies = new List<int>();
            // создать генератор случайных чисел
            Random rnd = new Random();
            // заполнить список по требуемому количеству сегментов
            while (segmentIndecies.Count < usedSegmentCount)
            {
                // получить случайный индекс
                int index = rnd.Next(0, SegmentCount);
                // проверить наличие полученного индекса в списке
                int insertIndex = segmentIndecies.IndexOf(index);
                // если не нашли, добавляем
                if (insertIndex < 0)
                    segmentIndecies.Add(index);
            }
            // отсортировать список индексов
            segmentIndecies.Sort();

            // сформировать результат
            Segment[] getusedsegments = new Segment[usedSegmentCount];
            for (int i = 0; i < usedSegmentCount; i++)
            {
                getusedsegments[i] = GetSegment(segmentIndecies[i]);
            }

            return getusedsegments;
        }

        public int GetUsedSegmentCount(int gameLevel)
        {
            if (!(Game.MIN_LEVEL <= gameLevel && gameLevel <= Game.MAX_LEVEL))
                throw new ArgumentOutOfRangeException("gameLevel");

            // 1. Определить количество уровней
            int levelCount = Game.MAX_LEVEL - Game.MIN_LEVEL + 1;
            // 2. +1
            levelCount++;
            // 3. Определить кол-во сегментов на 1 уровне
            int segmentsByLevel = SegmentCount / levelCount;
            // 4. Умножить на уровень для получения сегментов на текущем уровне
            return segmentsByLevel * gameLevel;
        }

        double width, runSpeed, jumpTime, manWidth;
        double jumpCount;

    }
}
