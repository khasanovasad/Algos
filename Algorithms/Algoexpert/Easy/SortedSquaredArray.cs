using System;

namespace Algorithms.Algoexpert.Easy;

public class SortedSquaredArray
{
    /// O(n * log(n)) time | O(n) space
    public int[] Solution1(int[] array)
    {
        var result = new int[array.Length];

        for (int i = 0; i < result.Length; ++i)
        {
            result[i] = (int)Math.Pow(array[i], 2);
        }

        Array.Sort<int>(result);
        return result;
    }

    /// O(n) time | O(n) space
    public int[] Solution2(int[] array)
    {
        var result = new int[array.Length];
        int start = 0;
        int end = array.Length - 1;

        for (int i = result.Length - 1; i >= 0; --i)
        {
            if (Math.Abs(array[start]) > Math.Abs(array[end]))
            {
                result[i] = (int)Math.Pow(array[start], 2);
                ++start;
                continue;
            }

            result[i] = (int)Math.Pow(array[end], 2);
            --end;
        }

        return result;
    }
}
