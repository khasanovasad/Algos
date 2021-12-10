using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorthms.LeetCode.Easy;

/// Defition of a binary tree
public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;
        
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public sealed partial class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        var pTree = new List<int?>();
        var qTree = new List<int?>();

        Traverse(p, pTree);
        Traverse(q, qTree);

        return pTree.SequenceEqual(qTree);
    }

    private void Traverse(TreeNode node, List<int?> array)
    {
        if (node is null)
        {
            array.Add(null);
            return;
        }

        array.Add(node.Val);
        Traverse(node.Left, array);
        Traverse(node.Right, array);
    }
}