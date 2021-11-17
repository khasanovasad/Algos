namespace Algorithms.Sorting
{
    public class InsertionSorter
    {
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && key < array[j])
                {
                    array[j + 1] = array[j];
                    --j;
                }

                array[j + 1] = key;
            } 
        }
    }
}