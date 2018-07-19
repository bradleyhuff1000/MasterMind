using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMind;

namespace GameLogicTest
{
    [TestClass]
    public class CompareTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] a = new byte[] { 1, 2, 3, 4 };
            byte[] b = new byte[] { 1, 2, 3, 4 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 4);
            Assert.AreEqual(result.IncorrectPositions, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            byte[] a = new byte[] { 4, 3, 2, 1 };
            byte[] b = new byte[] { 1, 2, 3, 4 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 0);
            Assert.AreEqual(result.IncorrectPositions, 4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            byte[] a = new byte[] { 6, 6, 4, 4 };
            byte[] b = new byte[] { 4, 6, 4, 6 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 2);
            Assert.AreEqual(result.IncorrectPositions, 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            byte[] a = new byte[] { 5, 0, 0, 5 };
            byte[] b = new byte[] { 0, 5, 5, 0 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 0);
            Assert.AreEqual(result.IncorrectPositions, 4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            byte[] a = new byte[] { 1, 1, 5, 5 };
            byte[] b = new byte[] { 3, 4, 2, 6 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 0);
            Assert.AreEqual(result.IncorrectPositions, 0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            byte[] a = new byte[] { 2, 1, 2, 2 };
            byte[] b = new byte[] { 2, 2, 2, 6 };

            CompareResult result = GameLogic.Compare(a, b);
            Assert.AreEqual(result.CorrectPositions, 2);
            Assert.AreEqual(result.IncorrectPositions, 1);
        }
    }
}
