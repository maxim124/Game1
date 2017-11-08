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
        /// Вычисление участков дороги, на которые может приземлиться человек
        /// </summary>
        /// <param name="width">ширина визуальной части, м</param>
        /// <param name="runspeed">скорость человека, мм/мсек</param>
        /// <returns></returns>
        public static Segment[] GetCaсtusPlaces(double width, int runspeed)
        {

        }

        // TODO: метод для вычисления участков дороги для размещения кактусов
        //public 
    }
}
