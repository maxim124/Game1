using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.GameClasses
{
    public static class Utils
    {
        /// <summary>
        /// Проверка - пересекаются ли прямоугольники
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="width1"></param>
        /// <param name="height1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width2"></param>
        /// <param name="height2"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://rsdn.org/forum/etude/802156.flat
        /// Прямоугольник:
        /// (X11, Y11)--------(X12, Y12)
        /// |                   |   - height
        /// (X14, Y14)--------(X13, Y13)
        ///             width
        /// Пусть вершины первого прям-ка имеют координаты (X11, Y11), (X12, Y12), (X13, Y13), (X14, Y14).
        /// Пусть вершины второго прям-ка имеют координаты(X21, Y21), (X22, Y22), (X23, Y23), (X24, Y24).
        /// Xmin = min(X11, X12, X13, X14);
        /// Xmax = max(X11, X12, X13, X14);
        /// Ymin = min(Y11, Y12, Y13, Y14);
        /// Ymax = max(Y11, Y12, Y13, Y14);
        ///
        /// А теперь проверяем, если хотя бы одна из вершин(X2i, Y2i) удовлетворяет условию: (X2i > Xmin) && (X2i<Xmax) && (Y2i > Ymin) && (Y2i<Ymax), то прямоугольники пересекаются.
        /// </remarks>
        public static bool AreRectanglesIntersected(
            double x1, double y1, double width1, double height1,
            double x2, double y2, double width2, double height2)
        {
            // прямоугольник 1:
            // левый верхний угол
            double X11 = x1;
            double Y11 = y1;
            // правый верхний угол
            double X12 = x1 + width1;
            double Y12 = Y11;
            // правый нижний угол
            double X13 = X12; 
            double Y13 = Y12 + height1;
            // левый нижний угол
            double X14 = X11 ;
            double Y14 = Y13;

            // прямоугольник 2:
            // левый верхний угол
            double X21 = x2;
            double Y21 = y2;
            // правый верхний угол
            double X22 = x2 + width2;
            double Y22 = Y21;
            // правый нижний угол
            double X23 = X22;
            double Y23 = Y22 + height2;
            // левый нижний угол
            double X24 = X21;
            double Y24 = Y23;

            double Xmin = (new double [] { X11, X12, X13, X14 }).Min();
            double Xmax = (new double [] { X11, X12, X13, X14 }).Max();
            double Ymin = (new double[] { Y11, Y12, Y13, Y14 }).Min();
            double Ymax = (new double[] { Y11, Y12, Y13, Y14 }).Max();

            /// А теперь проверяем, если хотя бы одна из вершин(X2i, Y2i) удовлетворяет условию: (X2i > Xmin) && (X2i<Xmax) && (Y2i > Ymin) && (Y2i<Ymax), то прямоугольники пересекаются.
            return
                (X21 > Xmin && X21 < Xmax && Y21 > Ymin && Y21 < Ymax) ||
                (X22 > Xmin && X22 < Xmax && Y22 > Ymin && Y22 < Ymax) ||
                (X23 > Xmin && X23 < Xmax && Y23 > Ymin && Y23 < Ymax) ||
                (X24 > Xmin && X24 < Xmax && Y24 > Ymin && Y24 < Ymax);
        }

        /// <summary>
        /// Проверка - пересекаются ли прямоугольники
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="width1"></param>
        /// <param name="height1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width2"></param>
        /// <param name="height2"></param>
        /// <returns></returns>
        public static bool AreWPFRectanglesIntersected(
            double x1, double y1, double width1, double height1,
            double x2, double y2, double width2, double height2)
        {
            return (new Rect(x1, y1, width1, height1)).IntersectsWith(new Rect(x2, y2, width2, height2));
        }
    }
}
