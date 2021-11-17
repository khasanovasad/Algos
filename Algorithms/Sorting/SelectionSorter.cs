using Utilities;

namespace Algorithms.Sorting
{
    public static class SelectionSorter
    {
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int minIdx = i;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[minIdx] > array[j])
                    {
                        minIdx = j;
                    } 
                }

                Utils.Swap(ref array[i], ref array[minIdx]);
            } 
        }
    }
}