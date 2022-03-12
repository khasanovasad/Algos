using System;

namespace Algorithms.Algoexpert.Easy;

public class FindClosestValueInBst
{
    /// Average: O(log(n)) time | O(1) space - where n is the number of nodes in the BST
    /// Worst: O(n) time | O(1) space - where n is the number of nodes in the BST
    public int IterativeSolution(BST tree, int target)
    {
        BST currentNode = tree;
        int closest = tree.Value;
        
        while (currentNode != null)
        {
            if (Math.Abs(target - currentNode.Value) < Math.Abs(target - closest))
            {
                closest = currentNode.Value;
            }

            if (currentNode.Value < target)
            {
                currentNode = currentNode.Right;
                continue;
            }

            currentNode = currentNode.Left;
        }

        return closest;
    }

    /// Average: O(log(n)) time | O(1) space - where n is the number of nodes in the BST
    /// Worst: O(n) time | O(1) space - where n is the number of nodes in the BST
    public int RecursiveSolution(BST tree, int target)
    {
        return RecursiveSolution(tree, target, tree.Value);

        int RecursiveSolution(BST tree, int target, int closest)
        {
            if (Math.Abs(target - tree.Value) < Math.Abs(target - closest))
            {
                closest = tree.Value;
            }

            if (target < tree.Value && tree.Left != null)
            {
                return RecursiveSolution(tree.Left, target, closest);
            }
            else if (target > tree.Value && tree.Right != null)
            {
                return RecursiveSolution(tree.Right, target, closest);
            }
            else
            {
                return closest;
            }
        }
    }

    public class BST
    {
        public int Value { get; set; }
        public BST Left { get; set; }
        public BST Right { get; set; }

        public BST(int value)
        {
            Value = value;
        }
    }
}
