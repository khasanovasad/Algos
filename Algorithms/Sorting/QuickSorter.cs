using System;

namespace Algorithms.Sorting
{
    public static class QuickSorter
    {
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            int tmp;
            for (int j = low; j <= high - 1; ++j)
            {
                if (array[j] < pivot)
                {
                    var swapTmp = array[++i];
                    array[i] = array[j];
                    array[j] = swapTmp;
                } 
            }
            
            tmp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = tmp;

            return i + 1;
        }
        
        private static void QuickSortInternal(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                QuickSortInternal(array, low, pi - 1);
                QuickSortInternal(array, pi + 1, high);
            } 
        }
        
        public static void QuickSort(int[] array)
        {
            QuickSortInternal(array, 0, array.Length - 1);
        }
    }
}