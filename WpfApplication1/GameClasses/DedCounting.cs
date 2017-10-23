using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.GameClasses
{
    public class DedCounting
    {
        public DedCounting(Size gameSize, Size screenSize)
        {
            this.screenSize = screenSize;
            scaleY = gameSize.Height / screenSize.Height;
            scaleX = gameSize.Width / screenSize.Width;
        }

        /// <summary>
        /// пересчет координат точки из игры на экран
        /// </summary>
        /// <param name="gamePoint">точка игры</param>
        /// <returns>точка экрана</returns>
        public Point GamePointToScreen(Point gamePoint)
        {
            var Y = this.screenSize.Height - gamePoint.Y / scaleY;
            var X = gamePoint.X / scaleX;
            return new Point(X, Y);
        }

        /// <summary>
        /// Пересчет координат прямоугольника
        /// </summary>
        /// <param name="gameRect">прямоугольник игры</param>
        /// <returns></returns>
        public Rect GameRectToScreen(Rect gameRect)
        {
            return new Rect(GamePointToScreen(gameRect.BottomLeft), GamePointToScreen(gameRect.TopRight));
        }

        Size screenSize;
        double scaleY;
        private double scaleX;
    }
}
