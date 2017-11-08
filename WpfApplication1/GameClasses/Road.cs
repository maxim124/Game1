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
        /// <returns></returns>
        public static Segment[] GetCaсtusPlaces(double width, int runspeed, double jumptime)
        {
            // сколько раз можно упаковать человека в длине 
            int PwmTimesOnWidth = (int)(width / PWM.MAN_WIDTH); // 100

            // считаем время, за которое человек пробежит видимый участок дороги = секунды
            double timeforwidth = width / runspeed;
            // зная время прыжка, считаем сколько раз он может прыгнуть
            int jumptimes = (int)(timeforwidth / jumptime); // ??? - секунды / мсек  // 20
            //jumptimes++;

            Segment[] pos = new Segment[PwmTimesOnWidth - jumptimes]; // 80
        }

        // TODO: метод для вычисления участков дороги для размещения кактусов
        //public 
    }
}
