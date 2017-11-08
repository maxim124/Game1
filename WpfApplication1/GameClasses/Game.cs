﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.GameClasses
{
    /// <summary>
    /// Игра
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Установка в начальное состояние
        /// </summary>
        public void Reset()
        {
            pwm.IsRunning = false;
            pwm.JumpReset();
            started = false;
 

            // уровень сложности игры - в минимальный
            level = 0;
            pwm.Distance = 0;
        }

        public static int GetLevel(double distance)
        {
            if (distance < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));

            // дистанция в целых метрах
            int intDistance = (int)distance;
            // целочисленное деление = уровень
            int level = intDistance / 100;
            // выбрать что меньше - рассчитанный уроаень или максимальный
            return Math.Min(level, MAX_GAME_LEVEL);

            //if (distance <= 100)
            //    return 0;
            //if (distance <= 200)
            //    return 1;
            //if (distance <= 300)
            //    return 2;
            //if (distance <= 400)
            //    return 3;
            //if (distance <= 500)
            //    return 4;

            //return MAX_GAME_LEVEL;
        }
       
        public const int MAX_GAME_LEVEL = 5;

        /// <summary>
        /// Перевод игры в следующее состояние
        /// </summary>
        /// <param name="pastTime">время в мсек, которое прошло с предыдущего шага</param>
        public void NextStep(long pastTime)
        {
            if (started)
                DoNextStep(pastTime);
        }

        /// <summary>
        /// Конкретные действия по переводу игры в следующее состояние состояние
        /// </summary>
        /// <param name="pastTime">время в мсек, которое прошло с предыдущего шага</param>
        /// <remarks>
        /// Вызывается гарантированно только при стартанутой игре - см. NextStep(...)
        /// </remarks>
        private void DoNextStep(long pastTime)
        {
            // проверка корректности параметра pastTime
            if (pastTime < 0)
                throw new ArgumentException();

            // TODO: возможно лишний вызов - если пвм не в прыжке
            pwm.Jump(pastTime);
            if (pwm.IsRunning)
                pwm.Run(pastTime);

            // получить кактусы, чтобы отрисовать
            // дорога, дать, кактусы, зависит, от, уровень, и, дистанция
            Cactus[] cactuses = road.GetCactuses(pwm.Distance);
        }
       
        /// <summary>
        /// Начало игры
        /// </summary>
        public void Start()
        {
            started = true;
            pwm.IsRunning = true;
            
        }

        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        /// <remarks>форм-фактор экрана суперпрограммиста</remarks>
        public double Width
        {
            get
            {
                return 16 / 9 * Height;
            }
        }

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public double Height
        {
            get
            {
                // Высота игрового поля = максимальная высота прыжка до ног + высота человека
                return PWM.MAX_JUMP + PWM.MAN_HEIGHT;
            }
        }

        /// <summary>
        /// Событие для проверки возможности продолжения игры
        /// </summary>
        public event EventHandler<CancelEventArgs> CheckContinue;

        /// <summary>
        /// Индикатор старта игры
        /// </summary>
        bool started = false;

        /// <summary>
        /// PWM игры
        /// </summary>
        public PWM PWM
        {
            get { return pwm; }
        }
        PWM pwm = new PWM();

        /// <summary>
        /// Текущий уровень сложности
        /// </summary>
        int level = 0;

        #region Настройки игры

        #endregion Настройки игры

        /// <summary>
        /// Дорога "Дедово Роуд"
        /// </summary>
        Road road = new Road();

    }
}
