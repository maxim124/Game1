using System;
using System.Windows;
using System.Windows.Input;
using WpfApplication1.GameClasses;
using System.Diagnostics;
using System.Windows.Media;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //InitCactuses();

        }

        private void InitializeGame()
        {
            // создание объекта игры
            Game game = new Game();

            // создание объекта экрана игры
            GameScreen gameScreen = new GameScreen(this.canvas);
            // и его инициализация
            gameScreen.PersonElementName = "image";

            // создание объекта контроллера
            controller = new Controller(game, gameScreen);
        }

        /// <summary>
        /// Начальная инициализация кактусов
        /// </summary>
        //private void InitCactuses()
        //{
        //    Random random = new Random();
        //    // кучи кактусов на начальном экране - 1..3
        //    for (int i = 0; i < random.Next(1, 3); i++)
        //    {
        //        // добавить группу кактусов
        //        cactusGroups.Add(new CactusGroup());
        //    }
        //}

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // начало игры
                controller.StartGame();

                // запуск счетчика прошедшего времени
                _stopwatch.Start();

                // включить отрисовщик
                rendering = true;
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            }
            else if (e.Key == Key.Space)
            {
                // начало прыжка
                controller.StartJump();
            }

            // TODO: разобраться с очисткой буфера клавиатуры после обработки нажатия клавиши
            e.Handled = true;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            // замер времени, прошедшего с предыдущего вызова обработчика отрисовки
            _stopwatch.Stop();

            // команда контроллеру на выполенние следующего шага игры

            controller.NextStep(_stopwatch.ElapsedMilliseconds);

            _stopwatch.Restart();

            //if (cactus == null)
            //{
            //    cactus = new Rectangle();
            //    //Fill = "Black" 
            //    cactus.Fill = new SolidColorBrush(Colors.Black);
            //    //Height = "70" 
            //    cactus.Height = 70;
            //    //Canvas.Left = "640" 
            //    Canvas.SetLeft(cactus, 0);
            //    //Stroke = "Black" 
            //    //cactus
            //    //Canvas.Top = "293"
            //    Canvas.SetTop(cactus, 0);
            //    //Width = "20
            //    cactus.Width = 20;

            //    canvas.Children.Add(cactus);
            //}
            //else
            //{
            //    // переуставнка координат cactus
            //    double left = Canvas.GetLeft(cactus);
            //    Canvas.SetLeft(cactus, left + 1);
            //}
        }

        //private void InitKaktus()
        //{
        //    //рандомайзер высоты препятствия
        //    Random rnd = new Random();
        //    rect.Height = rnd.Next(50, 110);
        //}

        //private void Jump()
        //{
        //    // создать анимацию
        //    DoubleAnimation da = new DoubleAnimation();
        //    // движение к значению 10
        //    da.To = 10;
        //    // после достижения значения To вернуться к исходному состоянию
        //    da.AutoReverse = true;
        //    // длительность анимации  вверх/вниз 2 сек
        //    da.Duration = TimeSpan.FromSeconds(2);
        //    // замедление анимации после половины
        //    da.DecelerationRatio = 0.5;
        //    // анимация подключается к свойству Top объекта image
        //    image.BeginAnimation(Canvas.TopProperty, da);
        //}

        //private void kaktus()
        //{
        //    // создать анимацию
        //    DoubleAnimation da = new DoubleAnimation();
        //    // движение к значению 10
        //    da.To = 0;
        //    // длительность анимации 
        //    da.Duration = TimeSpan.FromSeconds(3);
        //    // анимация подключается к свойству Left объекта rectangle
        //    rect.BeginAnimation(Canvas.LeftProperty, da);
        //}

        //private void Stop()
        //{
        //    // создать анимацию
        //    DoubleAnimation da = new DoubleAnimation();
        //    // останов анимации
        //    da.BeginTime = null;
        //    // ...
        //    image.BeginAnimation(Canvas.TopProperty, da);
        //}

        //private void Reset()
        //{
        //    DoubleAnimation da = new DoubleAnimation();
        //    // длительность анимации  вниз 0.1 сек
        //    da.Duration = TimeSpan.FromSeconds(0.1);
        //    // возврат значения в исходное состояяние
        //    da.FillBehavior = FillBehavior.Stop;
        //    image.BeginAnimation(Canvas.TopProperty, da);
        //}

        ///// <summary>
        ///// Флаг игры
        ///// </summary>
        //bool started = false;

        ///// <summary>
        ///// Список групп кактусов
        ///// </summary>
        //List<CactusGroup> cactusGroups = new List<CactusGroup>();

        //Rectangle cactus = null;
        ////int cactusCount = 0;

        /// <summary>
        /// Контроллер игры
        /// </summary>
        Controller controller;

        /// <summary>
        /// Индикатор запуска отрисовщика
        /// </summary>
        private bool rendering;
        private Stopwatch _stopwatch;

        private void Window_Closed(object sender, EventArgs e)
        {
            if (rendering)
            {
                // отключить отрисовщик
                CompositionTarget.Rendering -= CompositionTarget_Rendering;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }
    }
}
