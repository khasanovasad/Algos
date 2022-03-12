using System;
using Algorithms.Algoexpert.Easy;
using NUnit.Framework;

namespace Algorithms.Tests.Algoexpert;

[TestFixture]
public class NonConstructibleChangeTests
{
    [Test]
    public void Test()
    {
        var input = new int[] { 5, 7, 1, 1, 2, 3, 22 };
        const int expectedResult = 20;

        var sut = new NonConstructibleChange();
        var result = sut.Solution(input);

        Assert.AreEqual(expectedResult, result);
    }
}
