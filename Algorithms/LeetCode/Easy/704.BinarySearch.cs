namespace Algorithms.LeetCode.Easy;

public sealed partial class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int count = 0;  
        int right = nums.Length;
        int mid = (left + right) / 2;
            
        if (nums[0] == target) 
        {
            return 0;
        }
            
        while (target != nums[mid] && nums.Length / 2 >= count)
        {
            if (target > nums[mid]) 
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
            mid = (left + right) / 2;
            ++count;
        }
            
        if (count > nums.Length / 2)
        {
            return -1;
        }
        else
        {
            return mid;
        }
    }
}