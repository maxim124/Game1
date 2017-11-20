﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.GameClasses
{
    /// <summary>
    /// Person Without Mistakes
    /// </summary>
    public class PWM
    {
        /// <summary>
        /// Рост PWM, мм
        /// </summary>
        public const double MAN_HEIGHT = 1.8 * 1000;

        /// <summary>
        /// Жир PWM, мм
        /// </summary>
        public const double MAN_WIDTH = 0.3 * 1000;

        /// <summary>
        /// Максимальная высота прыжка, мм
        /// </summary>
        public const double MAX_JUMP = 5 * MAN_HEIGHT;


        /// <summary>
        /// Скорость прыжка, мм/мсек
        /// </summary>
        const double JUMP_SPEED = MAX_JUMP / JUMP_TIME;

        /// <summary>
        /// Максимальная скорость бега, мм/мсек
        /// </summary>
        /// <remarks>Источник: гугл-транслятор</remarks>
        public const double MAX_RUN_SPEED = 8.333333;

        /// <summary>
        /// Минимальная скорость бега, мм/мсек
        /// </summary>
        public const double MIN_RUN_SPEED = 2;

        //const double MIN_SPEED = 1;
        //double AVERAGE_SPEED = MIN_SPEED;

        /// <summary>
        /// Время прыжка, мсек
        /// </summary>
        public const int JUMP_TIME = 1000; //500;

        /// <summary>
        /// Получить скорость бега в зависимости от пройденного расстоянния (уровня игры)
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static double GetRunSpeedByDistance(int distance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Перевод человека в состояние прыжка
        /// </summary>
        public void JumpStart()
        {
            // ERROR: блокировка от повторного прыжка в процессе прыжка
            if (!jumping)
            {
                jumping = true;
                jumpUp = true;
            }
        }

        /// <summary>
        /// Реализация бега человека
        /// </summary>
        /// <param name="pastTime">время в мсек, которое прошло с предыдущей итерации игры</param>
        public void Run(long pastTime)
        {
            if (pastTime < 0)
                throw new ArgumentException();

            if (IsRunning && pastTime > 0)
            {
                // изменение дистанции бега = на сколько изменится расстояние от начальной точки пвм
                double deltax = MIN_RUN_SPEED * pastTime;
                distanceMM += (long)deltax;
            }
        }
         

        /// <summary>
        /// Перевод человека в состояние прыжка
        /// </summary>
        public void JumpReset()
        {
            jumping = false;
            jumpHeight = 0;
        }

        /// <summary>
        /// Реализация прыжка
        /// </summary>
        /// <param name="pastTime">время в мсек, которое прошло с предыдущей итерации игры</param>
        public void Jump(long pastTime)
        {
            // проверка корректности параметра pastTime
            if (pastTime < 0)
                throw new ArgumentException();

            if (jumping && pastTime > 0)
            {
                // изменение высоты прыжка = на сколько изменится высота пвм
                double delta = JUMP_SPEED * pastTime;
                bool checkGround = false;
                if (jumpUp)
                {
                    // если прыжок вверх, проверим чтобы не улетели выше максимума
                    // лишнее = падение вниз
                    if (jumpHeight + delta < MAX_JUMP)
                    {
                        // недолет
                        jumpHeight += (long)delta;
                    }
                    else
                    {
                        // перелет
                        delta -= MAX_JUMP - jumpHeight;
                        jumpHeight = (long)(MAX_JUMP - delta);
                        jumpUp = false;

                        // может быть достигнута земля
                        checkGround = true;
                    }
                }
                else
                {
                    // если падение вниз
                    jumpHeight -= (long)delta;
                   

                    // может быть достигнута земля
                    checkGround = true;
                }

                if (checkGround)
                {
                    // проверяем, что достигли земли
                    if (!jumpUp && jumpHeight <= 0)
                    {
                        jumpHeight = 0;
                        jumpUp = true;
                        jumping = false;
                    }
                }
            }
        }


        /// <summary>
        /// Текущая высота прыжка, мм
        /// </summary>
        public double JumpHeight
        {
            get { return jumpHeight; }
        }

        /// <summary>
        /// Размеры человека
        /// </summary>
        public Size Size
        {
            get
            {
                return new Size(0, MAN_HEIGHT);
            }
        }

        /// <summary>
        /// Индикатор прыжка
        /// </summary>
        bool jumping = false;

        // изначально человек на земле - высота прыжка = 0
        /// <summary>
        /// Текущее положение человека относительно земли = высота прыжка, мм
        /// </summary>
        long jumpHeight = 0;

        // изначально человек на старте - начальная точка = 0
        /// <summary>
        /// Текущее положение человека относительно начальной точки = текущая дистанция, мм
        /// </summary>
        long distanceMM = 0;

        /// <summary>
        /// Индикатор направления прыжка:
        /// true - вверх
        /// false - вниз
        /// </summary>
        bool jumpUp = false;

        /// <summary>
        /// Пройденное человеком расстояние, м
        /// </summary>
        public double Distance
        {
            get { return distanceMM / 1000.0; }
            set { distanceMM = (long)(value * 1000); }
        }
        /// <summary>
        /// Индикатор бега
        /// </summary>
        public bool IsRunning { get; set; }
    }
}