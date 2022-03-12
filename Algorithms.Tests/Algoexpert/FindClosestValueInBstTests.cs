using System;
using Algorithms.Algoexpert.Easy;
using NUnit.Framework;

namespace Algorithms.Tests.Algoexpert;

[TestFixture]
public class FindClosestValueInBstTest
{
    [Test]
    public void Test()
    {
		const int expectedValue = 13;

		var root = new FindClosestValueInBst.BST(10);
		root.Left = new FindClosestValueInBst.BST(5);
		root.Left.Left = new FindClosestValueInBst.BST(2);
		root.Left.Left.Left = new FindClosestValueInBst.BST(1);
		root.Left.Right = new FindClosestValueInBst.BST(5);
		root.Right = new FindClosestValueInBst.BST(15);
		root.Right.Left = new FindClosestValueInBst.BST(13);
		root.Right.Left.Right = new FindClosestValueInBst.BST(14);
		root.Right.Right = new FindClosestValueInBst.BST(22);

		var sut = new FindClosestValueInBst();

		var actual1 = sut.IterativeSolution(root, 12);
		var actual2 = sut.RecursiveSolution(root, 12);

		Assert.AreEqual(expectedValue, actual1);
		Assert.AreEqual(expectedValue, actual2);
	}
}
