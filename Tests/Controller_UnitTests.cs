using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;
using System.Threading;
using System.Windows.Controls;

namespace Tests
{
    [TestClass]
    public class Controller_UnitTests
    {
        [TestMethod]
        public void Controller_NextStep_Test()
        {
            //Game game = new Game();
            //Controller controller = new Controller(game, (Canvas)null);

            //// игра не запущена - ничего не должно происходить, т.к. игра не запущена
            //controller.NextStep(100);
            //controller.NextStep(100);

            //// запуск игры 
            //controller.StartGame();

            //// игра запущена - что-то должно происходить
            //controller.NextStep(100);
            //controller.NextStep(100);
        }

        [TestMethod]
        public void Controller_Jump_Test()
        {
            Game game = new Game();
            Controller controller = new Controller(game, null);

            // запуск игры 
            controller.StartGame();

            // игра запущена - что-то должно происходить
            controller.NextStep(100);

            // начало прыжка
            controller.StartJump();
            double height = controller.GetJumpHeight();
            Assert.AreEqual(0, height);

            // промежуточные состояния прыжка

            // задержка = 1/2 времени полета вверх
            //controller.NextStep();

            ////controller.NextStep();

            ////controller.NextStep();

            ////controller.NextStep();

            ////controller.NextStep();

            ////controller.NextStep();

            //height = controller.GetJumpHeight();
            //Assert.AreEqual(Game.MAX_JUMP / 2, height);

            controller.NextStep(10 * PWM.JUMP_TIME);
            height = controller.GetJumpHeight();
            Assert.AreEqual(0, height);

            //controller.NextStep(Game.JUMP_TIME / 2);
            //height = controller.GetJumpHeight();
            //Assert.AreEqual(Game.MAX_JUMP / 2, height);

            //controller.NextStep(Game.JUMP_TIME);
            //height = controller.GetJumpHeight();
            //Assert.AreEqual(Game.MAX_JUMP, height);

            //Thread.Sleep(Game.JUMP_TIME);
            //controller.NextStep();
            //height = controller.GetJumpHeight();
            //Assert.AreEqual(Game.MAX_JUMP, height);

            //controller.NextStep();
            //controller.NextStep();
            //controller.NextStep();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Controller_JumpException_Test()
        {
            Game game = new Game();
            Controller controller = new Controller(game, null);

            // запуск игры 
            controller.StartGame();
            // начало прыжка
            controller.StartJump();

            // игра запущена - что-то должно происходить
            controller.NextStep(-100);

            double height = controller.GetJumpHeight();
            Assert.AreEqual(0, height);
        }
    }
}
