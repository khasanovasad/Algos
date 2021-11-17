using System;

namespace Algorithms.Sorting
{
    public static class MergeSorter
    {
        private static void Merge(int[] array, int low, int middle, int high)
        {
            int n1 = middle - low + 1;
            int n2 = high - middle;
            var left = new int[n1];
            var right = new int[n2];

            int i, j;
            for (i = 0; i < n1; ++i)
            {
                left[i] = array[low + i];
            }
            for (j = 0; j < n2; ++j)
            {
                right[j] = array[middle + 1 + j];
            }

            i = j = 0; 
            int k = low;

            while (i < n1 && j < n2)
            {
                if (left[i] < right[j])
                {
                    array[k++] = left[i++];
                }
                else
                {
                    array[k++] = right[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = left[i++];
            }

            while (j < n2)
            {
                array[k++] = right[j++];
            }
        }

        private static void MergeSortInternal(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (high + low) / 2;
                MergeSortInternal(array, low, middle);
                MergeSortInternal(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }
        
        public static void MergeSort(int[] array)
        {
            MergeSortInternal(array, 0, array.Length - 1);
        }
    }
}