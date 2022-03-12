using System;
using System.Collections.Generic;

namespace Algorithms.Algoexpert.Easy;

public class TwoSum
{
    /// O(n^2) time | O(1) space
    public int[] Solution1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            for (int j = i + 1; j < nums.Length; ++j)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        return new int[] { };
    }

    /// O (nlogn) time | O(1) space
    public int[] Solution2(int[] nums, int target)
    {
        Array.Sort<int>(nums);

        int left = 0;
        int right = nums.Length - 1;
        while (left != right)
        {
            int currentSum = nums[left] + nums[right];

            if (currentSum == target)
            {
                return new int[] { left, right };
            }
            else if (currentSum < target)
            {
                ++left;
            }
            else if (currentSum > target)
            {
                --right;
            }
        }

        return new int[] { };
    }

    /// O (n) time | O(n) space
    public int[] TwoSum3(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (map.ContainsKey(nums[i]))
            {
                return new int[] { map[nums[i]], i };
            }

            try
            {
                map.Add(target - nums[i], i);
            }
            catch { } // ignore
        }

        return new int[] { };
    }
}
