using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame.DedGameClasses
{
    /// <summary>
    /// Главный персонаж
    /// </summary>
    class D_E_D
    {
        /// <summary>
        /// Отрисовка
        /// </summary>
        public void Draw(Graphics graphics, Color canvasColor)
        {
            if (y != yOld)
            {

                Rectangle rectangle = new Rectangle(X, yOld, Width, Height);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, rectangle);
                //Clear(graphics, canvasColor, rectangle);



                rectangle.Y = y;
                //graphics.FillRectangle(Brushes.Black, rectangle);
                graphics.DrawImage(image, rectangle);

                yOld = y;
            }
        }

        private static void Clear(Graphics graphics, Color canvasColor, Rectangle rectangle)
        {
            //graphics.Clear(canvasColor);
            graphics.FillRectangle(new SolidBrush(canvasColor), rectangle);
        }

        public void Tick()
        {
            if (jump != null)
            {
                // если мы в прыжке:

                if (jump == true)
                {
                    // движение вверх
                    yOld = y;
                    y -= JUMP_DELTA;

                    // если достигли потолка, начинаем движение вниз
                    if (y <= 0)
                        jump = false;
                }
                else
                {
                    // движение вниз
                    yOld = y;
                    y += JUMP_DELTA;

                    // если достигли исходного положения, прыжок закончен
                    if (y >= Y_START)
                        jump = null;
                }
            }
        }

        public void Jump()
        {
            if (!IsJumping)
                jump = true;
        }

        public bool IsJumping
        {
            get { return jump != null; }
        }

        /// <summary>
        /// Индикатор прыжка:
        /// == null - нет прыжка
        /// == true - движение вверх
        /// == false - движение вниз
        /// </summary>
        bool? jump = null;

        const int X = 60;
        const int JUMP_DELTA = 5;
        const int Y_START = 100;
        int y = Y_START;
        int yOld = -1;
        const int Width = 30;
        const int Height = 60;

        public static Bitmap GetHighPerformanceBitmap(Image original)
        {
            Bitmap bitmap;

            bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppPArgb);
            bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(original, new Rectangle(new Point(0, 0), bitmap.Size), new Rectangle(new Point(0, 0), bitmap.Size), GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        /// <summary>
        /// Картинка
        /// </summary>
        Image image = GetHighPerformanceBitmap0(Image.FromFile("C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Game1\\SuperGame\\gam1.jpg"));
    }
}
