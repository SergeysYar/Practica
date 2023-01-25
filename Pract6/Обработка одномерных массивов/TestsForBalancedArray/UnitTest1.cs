using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Обработка_одномерных_массивов;

namespace TestsForBalancedArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EvenIndexTest()
        {
            int[] a = new[] { 1, 2, 3, 4, 5 };
            int[] exp = new[] {2, 1, 2, 3, 4, 5 };
            int[] act = MyArray.BalancedArray(a);
            Assert.AreEqual(exp[0], act[0]);
        }
        [TestMethod]
        public void EvenArrayTest()
        {
            int[] a = new[] { 1, 2, 3, 4, 5 };
            int[] exp = new[] { 2, 1, 2, 3, 4, 5 };
            int[] act = MyArray.BalancedArray(a);
            for (int i = 0; i < exp.Length; i++)
            {
                Assert.AreEqual(exp[i], act[i]);
            }
        }
        [TestMethod]
        public void OddIndexTest()
        {
            int[] a = new[] { 2,4,6 };
            int[] exp = new[] { 1,1,1,2, 4, 6 };
            int[] act = MyArray.BalancedArray(a);
            Assert.AreEqual(exp[0], act[0]);
        }
        [TestMethod]
        public void OddArrayTest()
        {
            int[] a = new[] { 2, 4, 6 };
            int[] exp = new[] { 1, 1, 1, 2, 4, 6 };
            int[] act = MyArray.BalancedArray(a);
            for (int i = 0; i < exp.Length; i++)
            {
                Assert.AreEqual(exp[i], act[i]);
            }
        }
        [TestMethod]
        public void ArrayTest()
        {
            int[] a = new[] { 2, 1 };
            int[] exp = new[] { 2, 1};
            int[] act = MyArray.BalancedArray(a);
            for (int i = 0; i < exp.Length; i++)
            {
                Assert.AreEqual(exp[i], act[i]);
            }
        }
    }
}
