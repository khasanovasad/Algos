using System;

namespace Algorithms.Misc;

/// Problem represented in Section 15.1 of CLRS book
public class CutRod
{
    public static int DivideAndConquer(int[] prices, int n)
    {
        if (n == 0)
        {
            return 0;
        }

        var result = Int32.MinValue;
        for (int i = 1; i <= n; ++i)
        {
            var previousResult = DivideAndConquer(prices, n - i);
            result = Math.Max(result, prices[i] + previousResult);
        }

        return result;
    }

    public static int DynamicProgrammingTopDown(int[] prices, int n)
    {
        var results = new int[n + 1];
        for (int i = 0; i <= n; ++i)
        {
            results[i] = Int32.MinValue;
        }

        return DynamicProgrammingTopDownInternal(prices, n, results);
    }

    private static int DynamicProgrammingTopDownInternal(int[] prices, int n, int[] results)
    {
        if (results[n] >= 0)
        {
            return results[n];
        }
            
        int result;
        if (n == 0)
        {
            result = 0;
        }
        else
        {
            result = Int32.MinValue;
            for (int i = 1; i <= n; ++i)
            {
                var previousResult = DynamicProgrammingTopDownInternal(prices, n - i, results);
                result = Math.Max(result, prices[i] + previousResult);
            }
        }
        results[n] = result;
        return result;
    }

    public static int DynamicProgrammingBottomUp(int[] prices, int n)
    {
        var results = new int[n + 1];
        results[0] = 0;
        for (int j = 1; j <= n; ++j)
        {
            int result = Int32.MinValue;
            for (int i = 1; i <= j; ++i)
            {
                result = Math.Max(result, prices[i] + results[j - i]);
            }
            results[j] = result;
        }
        return results[n];
    }
}