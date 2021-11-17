using System;
using System.Linq;
using Algorithms.Sorting;
using Xunit;

namespace Tests.Algorithms
{
    public class SortingTests : IDisposable
    {
        private readonly int[] _array = new int[15];
        private readonly int[] _sortedArray = new int[15];

        public SortingTests()
        {
            var rd = new Random();
            for (int i = 0; i < _array.Length; ++i)
            {
                _sortedArray[i] = _array[i] = rd.Next(0, 100);
            }
        }

        public void Dispose() { }
        
        [Fact]
        public void BubbleSortTest()
        {
            BubbleSorter.BubbleSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }

        [Fact]
        public void MergeSortTest()
        {
            MergeSorter.MergeSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }
        
        [Fact]
        public void HeapSortTest()
        {
            HeapSorter.HeapSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }
        
        [Fact]
        public void InsertionSortTest()
        {
            InsertionSorter.InsertionSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }
        
        [Fact]
        public void SelectionSortTest()
        {
            SelectionSorter.SelectionSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }
        
        [Fact]
        public void QuickSortTest()
        {
            QuickSorter.QuickSort(_array);
            Assert.Equal(_sortedArray.OrderBy(item => item), _array);
        }
    }
}