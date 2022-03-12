using System.Collections.Generic;

namespace Algorithms.Algoexpert.Easy;

public class ValidateSubsequence
{
    /// O(n) time | O(1) space
    public bool Solution(List<int> array, List<int> sequence)
    {
        int seqIdx = 0;
        for (int i = 0; i < array.Count; ++i)
        {
            if (seqIdx == sequence.Count)
            {
                break;
            }

            if (array[i] == sequence[seqIdx])
            {
                ++seqIdx;
            }
        }

        return seqIdx == sequence.Count;
    }
}
