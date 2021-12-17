namespace Algorithms.Sorting;

public static class HeapSorter
{
    private static void MaxHeapify(int[] array, int size, int i)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        int largest = i;
            
        if (left < size && array[largest] < array[left])
        {
            largest = left;
        }

        if (right < size && array[largest] < array[right])
        {
            largest = right;
        }

        if (largest != i)
        {
            (array[i], array[largest]) = (array[largest], array[i]);
            MaxHeapify(array, size, largest);
        }
    }

    private static void BuildMaxHeap(int[] array)
    {
        for (int i = (array.Length - 1) / 2; i >= 0; --i)
        {
            MaxHeapify(array, array.Length, i); 
        } 
    }
        
    public static void HeapSort(int[] array)
    {
        BuildMaxHeap(array);
        for (int i = array.Length - 1; i >= 0; --i)
        {
            (array[i], array[0]) = (array[0], array[i]);
            MaxHeapify(array, i, 0);
        }
    }
}