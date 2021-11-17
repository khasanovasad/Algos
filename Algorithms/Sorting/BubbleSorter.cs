using System;
using Utilities;

namespace Algorithms.Sorting
{
    public static class BubbleSorter
    {
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        Utils.Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}