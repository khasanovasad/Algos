using System;
using Algorithms.Misc;
using NUnit.Framework;

namespace Tests.Algorithms.Misc
{
    [TestFixture]
    public class GreedyKnapsackTests
    {
        [Test]
        public void GreedyKnapsackTest()
        {
            const int maxWeight = 50;
            var values = new int[] { 60, 100, 120 };
            var weights = new int[] { 10, 20, 30 };

            var result = GreedyKnapsack.Calculate(values, weights, maxWeight);

            Assert.AreEqual(240, result);
        }
    }
}