namespace Algorithms.LeetCode.Easy;

public sealed partial class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int idx = 0;
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != 0)
            {
                (nums[idx], nums[i]) = (nums[i], nums[idx]);
                ++idx;
            }
        }
    }
}