using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode.Easy
{
    public partial class Solution
    {
        public int[] TwoSum(int[] nums, int target)
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
                catch {} // ignore
            }
            
            return new int[] { };
        }
    }
}