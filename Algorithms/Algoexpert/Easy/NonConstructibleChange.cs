using System;
using System.Collections.Generic;

namespace Algorithms.Algoexpert.Easy;

public class NonConstructibleChange
{
    /// O(n * log(n)) time | O(1) space
    public int Solution(int[] coins)
    {
        Array.Sort<int>(coins);

        int currentChangeCreated = 0;
        foreach (int coin in coins)
        {
            if (coin > currentChangeCreated + 1)
            {
                return currentChangeCreated + 1;
            }

            currentChangeCreated += coin;
        }

        return currentChangeCreated + 1;
    }
}
