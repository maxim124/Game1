using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1.GameClasses;

namespace Tests
{
    [TestClass]
    public class CactusGenerator_UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test1()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(-1, PWM.MIN_RUN_SPEED, PWM.JUMP_TIME, PWM.MAN_WIDTH);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test2()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(0, PWM.MIN_RUN_SPEED, PWM.JUMP_TIME, PWM.MAN_WIDTH);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test3()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(101, -1, PWM.JUMP_TIME, PWM.MAN_WIDTH);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test4()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(101, 0, PWM.JUMP_TIME, PWM.MAN_WIDTH);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test5()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(101, 100, -1, PWM.MAN_WIDTH);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test6()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(101, 100, 1, -1);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test7()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(101, 100, 1, 0);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_ctor_Test8()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(50, 100, 1, 100);
            Assert.IsNull(cactusGenerator);
        }

        [TestMethod]
        public void CactusGenerator_SegmentCount_Test()
        {
            CactusGenerator cactusGenerator = CreateCactusGenerator();
            Assert.AreEqual(51, cactusGenerator.SegmentCount);
        }

        [TestMethod]
        public void CactusGenerator_SegmentCount_Test2()
        {
            CactusGenerator cactusGenerator = new CactusGenerator(150, 100, 1, 10);
            Assert.AreNotEqual(51, cactusGenerator.SegmentCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_GetSegment_Test1()
        {
            CactusGenerator cactusGenerator = CreateCactusGenerator();
            Assert.IsNull(cactusGenerator.GetSegment(-1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_GetSegment_Test2()
        {
            CactusGenerator cactusGenerator = CreateCactusGenerator();
            Assert.IsNull(cactusGenerator.GetSegment(cactusGenerator.SegmentCount));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CactusGenerator_GetSegment_Test3()
        {
            CactusGenerator cactusGenerator = CreateCactusGenerator();
            Assert.IsNull(cactusGenerator.GetSegment(cactusGenerator.SegmentCount + 100));
        }

        [TestMethod]
        public void CactusGenerator_GetSegment_Test4()
        {
            CactusGenerator cactusGenerator = CreateCactusGenerator();
            Segment segment;

            segment = cactusGenerator.GetSegment(0);
            Assert.IsNotNull(segment);
            Assert.AreEqual(0.3, segment.Offset, 0.00000001);
            Assert.AreEqual(1.7, segment.Length, 0.00000001);

            segment = cactusGenerator.GetSegment(1);
            Assert.IsNotNull(segment);
            Assert.AreEqual(2.3, segment.Offset, 0.00000001);
            Assert.AreEqual(1.7, segment.Length, 0.00000001);

            segment = cactusGenerator.GetSegment(2);
            Assert.IsNotNull(segment);
            Assert.AreEqual(4.3, segment.Offset, 0.00000001);
            Assert.AreEqual(1.7, segment.Length, 0.00000001);

            segment = cactusGenerator.GetSegment(50);
            Assert.IsNotNull(segment);
            Assert.AreEqual(100.3, segment.Offset, 0.00000001);
            Assert.AreEqual(0.7, segment.Length, 0.00000001);
        }

        static CactusGenerator CreateCactusGenerator(double width = 101, double runSpeed = PWM.MIN_RUN_SPEED, double jumpTime = PWM.JUMP_TIME / 1000, double manWidth = PWM.MAN_WIDTH / 1000)
        {
            return new CactusGenerator(width, runSpeed, jumpTime, manWidth);
        }
    }
}
