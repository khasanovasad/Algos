using System;

namespace Algorithms.LeetCode.Easy;

public sealed partial class Solution
{
    private static bool IsBadVersion(int num)
    {
        const int firstBadVersion = 4;
        return num > firstBadVersion;
    }

    public int FirstBadVersion(int num)
    {
        int left = 0;
        int right = num;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
            {
                right = mid;
                continue;
            }

            left = mid + 1;
        }

        return left;
    }
}