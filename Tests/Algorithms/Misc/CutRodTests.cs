using System;
using Algorithms.Misc;
using NUnit.Framework;

namespace Tests.Algorithms.Misc
{
    public class CutRodTests
    {
        [Test]
        public void DivideAndConquerTest()
        {
            var prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var result = CutRod.DivideAndConquer(prices, 4);

            Assert.AreEqual(result, 20);
        }

        [Test]
        public void DynamicProgramming_TopDown()
        {
            var prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var result = CutRod.DynamicProgrammingTopDown(prices, 4);

            Assert.AreEqual(result, 20);
        }

        [Test]
        public void DynamicProgramming_BottomUp()
        {
            var prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var result = CutRod.DynamicProgrammingBottomUp(prices, 4);

            Assert.AreEqual(result, 20);
        }
    }
}