using System;
using System.Linq;
using Algorithms.Sorting;
using NUnit.Framework;

namespace Tests.Algorithms;

[TestFixture]
public class SortingTests
{
    private readonly int[] _array = new int[15];
    private readonly int[] _sortedArray = new int[15];

    [SetUp]
    public void SetUp()
    {
        var rd = new Random();
        for (int i = 0; i < _array.Length; ++i)
        {
            _sortedArray[i] = _array[i] = rd.Next(0, 100);
        }
    }

    [Test]
    public void BubbleSortTest()
    {
        BubbleSorter.BubbleSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }

    [Test]
    public void MergeSortTest()
    {
        MergeSorter.MergeSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }
        
    [Test]
    public void HeapSortTest()
    {
        HeapSorter.HeapSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }
        
    [Test]
    public void InsertionSortTest()
    {
        InsertionSorter.InsertionSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }
        
    [Test]
    public void SelectionSortTest()
    {
        SelectionSorter.SelectionSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }
        
    [Test]
    public void QuickSortTest()
    {
        QuickSorter.QuickSort(_array);
        Assert.AreEqual(_sortedArray.OrderBy(item => item), _array);
    }
}