using System;

namespace Algorithms.Misc;

public static class ZeroOneKnapsack
{
    public static double Calculate(int[] values, int[] weights, int capacity)
    {
        if (values is null || weights is null || values.Length != weights.Length || capacity < 0)
        {
            throw new ArgumentException();
        }

        int N = values.Length;
        
        // creating table
        var table = new int[N + 1, capacity + 1];

        for (int i = 1; i <= N; ++i)
        {
            int w = weights[i - 1], v = values[i - 1];
            
            for (int j = 1; j <= capacity; ++j)
            {
                table[i, j] = table[i - 1, j];

                if (j >= w && table[i - 1, j - w] + v > table[i, j])
                {
                    table[i, j] = table[i - 1, j - w] + v;
                }
            }
        }

        return table[N, capacity];
    }
}