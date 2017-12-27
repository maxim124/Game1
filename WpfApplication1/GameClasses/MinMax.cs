using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.GameClasses
{
    public class MinMax
    {
        public MinMax()
        {
        }

        public MinMax(int min, int max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Минимум
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Максимум
        /// </summary>
        public int Max { get; set; }

    }
}
