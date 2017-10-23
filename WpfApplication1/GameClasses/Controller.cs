using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1.GameClasses
{
    /// <summary>
    /// Контроллер
    /// </summary>
    /// <remarks>
    /// Контроллер знает об игре и платформой исполнения
    /// На основе этого оптимизирует работу
    /// </remarks>
    public class Controller
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="game"></param>
        public Controller(Game game, GameScreen gameScreen) 
        {
            // TODO: посмотреть необходимость использования класса GameScreen

            this.game = game;
            this.gameScreen = gameScreen;

            // подключение обработчика события к игре
            this.game.CheckContinue += Game_CheckContinue;

            this.game.Reset();

            Size gameSize = new Size(game.Width, game.Height); // от game
            this.сounting = new DedCounting(gameSize, gameScreen.Size);
        }

        /// <summary>
        /// Обработчик события игры - проверить возможность продолжения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_CheckContinue(object sender, CancelEventArgs e)
        {
            // TODO: проверить состояние человека; если прыжок закончен, установить jumpStarted = false
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получить высоту прыжка
        /// </summary>
        /// <returns>
        /// TODO: пересмотреть необходимость метода
        /// </returns>
        public double GetJumpHeight()
        {
            return game.PWM.JumpHeight;
        }

        /// <summary>
        /// Начало прыжка
        /// </summary>
        public void StartJump()
        {
            if (!jumpStarted)
            {
                jumpStarted = true;
                game.PWM.JumpStart();
            }
        }

        /// <summary>
        /// Перевод игры в следующее состояние состояние
        /// </summary>
        /// <param name="pastTime">время в мсек, которое прошло с предыдущего шага</param>
        public void NextStep(long pastTime)
        {
            this.game.NextStep(pastTime);

            // отрисовать изменения игры:
            // - отрисовать человека
            DrawPWM();

            // TODO: проверить состояние человека; если прыжок закончен, установить jumpStarted = false
        }

        private void DrawPWM()
        {
            // положение человека по вертикали
            // double jumpHeight = game.PWM.JumpHeight;
            var jumpHeight = game.PWM.JumpHeight;
            Point gamePersonPoint = new Point(0, jumpHeight);
            // размеры человека в игре
            Size gamePersonSize = game.PWM.Size;
            Rect gamePersonRect = new Rect(gamePersonPoint, gamePersonSize);

            // пересчитать естественные координаты человека в координаты графического экрана
            //Point screenPersonPoint = сounting.GamePointToScreen(gamePersonPoint);
            Rect screenPersonRect = сounting.GameRectToScreen(gamePersonRect);

            // отрисовать человека на экране
            gameScreen.SetPersonCoordinates(screenPersonRect.TopLeft);
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        public void StartGame()
        {
            game.Start();
        }


        /// <summary>
        /// Игра
        /// </summary>
        Game game;

        DedCounting сounting;
        private GameScreen gameScreen;
        private bool jumpStarted;
    }
}
