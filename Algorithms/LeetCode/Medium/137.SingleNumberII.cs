namespace Algorithms.LeetCode.Medium;

public sealed partial class Solution
{
    // O (n)time | O(n) space
    public int SingleNumber(int[] nums)
    {
        var table = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!table.ContainsKey(num))
            {
                table.Add(num, 1);
                continue;
            }

            ++table[num];
        }

        return table.FirstOrDefault(item => item.Value == 1).Key;
    }
}