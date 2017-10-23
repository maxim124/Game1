using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1.GameClasses
{
    public class GameScreen
    {
        public GameScreen(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public Size Size
        {
            get
            {
                return new Size(canvas.ActualWidth, canvas.ActualHeight);
            }
        }

        public string PersonElementName { get; set; }

        private Canvas canvas;

        internal void SetPersonCoordinates(Point screenPersonPoint)
        {
            var screenPWM = canvas.FindName(PersonElementName) as UIElement;
            Canvas.SetTop(screenPWM, screenPersonPoint.Y);
        }
    }
}
