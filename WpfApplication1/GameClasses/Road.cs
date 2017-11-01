using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.GameClasses
{
    public class Road
    {
        Cactus cactus = new Cactus();
        //Cactus cactus1 = new Cactus();
        public Cactus[] GetCactuses(int level, double distance)
        {
            //Cactus[] cactuses = new Cactus[] ;
            //Cactus[] cactuses = new Cactus[2]{ cactus ,cactus1};
            Cactus[] cactuses = new Cactus[] { new Cactus(), new Cactus() };
            return cactuses;
        }
    }
}
