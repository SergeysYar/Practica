using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Обработка_двумерного_массива;

namespace TestsForArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Исходные данные для теста.
            int[,] myArr = new int[3, 4] { {  0, 3, -1,  5 },
                                       {  6, 7,  0,  12 },
                                       { -2, 4,  9, -13 }
                                     };
            string exp = "2";
            string act = NullCounter.TextResult(myArr);

            Assert.AreEqual(exp, act, "Ожидаемый столбец");   

        }
    }
}
