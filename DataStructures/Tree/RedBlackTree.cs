using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    public class RedBlackTree<T>
    {
        public enum NodeColor { Red, Black }
        
        public class Node<TY>
        {
            public Node<TY> Parent { get; set; }
            public Node<TY> Left { get; set; }
            public Node<TY> Right { get; set; }
            public TY Key { get; set; }
            public NodeColor Color { get; set; }

            public Node(TY key = default)
            {
                Key = key;
                Parent = Left = Right = null;
                Color = NodeColor.Red;
            }
        }
        
        private Node<T> _root;
        private readonly Comparer<T> _comparer;

        public RedBlackTree(Comparer<T> comparer = null)
        {
            _root = null;
            _comparer = comparer ?? Comparer<T>.Default;
        }
        
        public Node<T> Min()
        {
            return MinInternal(_root);
        }
        
        public Node<T> Max()
        {
            return MaxInternal(_root);
        }
        
        private Node<T> MinInternal(Node<T> node)
        {
            Node<T> currentNode = node;

            while (currentNode.Left is not null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
            
        }
        
        private Node<T> MaxInternal(Node<T> node)
        {
            Node<T> currentNode = node;

            while (currentNode.Right is not null)
            {
                currentNode = currentNode.Right;
            }

            return currentNode;
        }

        public Node<T> Search(T key)
        {
            Node<T> currentNode = _root;
            
            while (currentNode is not null && _comparer.Compare(key, currentNode.Key) != 0)
            {
                if (_comparer.Compare(key, currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (_comparer.Compare(key, currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                }
            }

            return currentNode;
        }

        public void Insert(T toBeAdded)
        {
            var newNode = new Node<T>(toBeAdded);

            if (_root is null)
            {
                newNode.Color = NodeColor.Black;
                _root = newNode;
                return;
            }

            Node<T> currentNode = _root;
            Node<T> potentialParent = null;
            while (currentNode is not null)
            {
                potentialParent = currentNode;
                if (_comparer.Compare(newNode.Key, currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (_comparer.Compare(newNode.Key, currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                }
            }

            newNode.Parent = potentialParent;

            if (_comparer.Compare(newNode.Key, newNode.Parent.Key) < 0)
            {
                newNode.Parent.Left = newNode;
            }
            else if (_comparer.Compare(newNode.Key, newNode.Parent.Key) > 0)
            {
                newNode.Parent.Right = newNode;
            }

            InsertionFixup(newNode);
        }
        
        private void InsertionFixup(Node<T> node)
        {
            while (node != _root && node.Parent.Color == NodeColor.Red)
            {
                Node<T> parent = node.Parent;
                Node<T> grandParent = node.Parent.Parent;
                Node<T> uncle = null;

                if (grandParent.Left is null || grandParent.Right is null)
                {
                    uncle = new Node<T>() { Color = NodeColor.Black } ;
                }
                else
                {
                    uncle = grandParent.Left == parent ? grandParent.Right : grandParent.Left;
                }
                
                if (uncle.Color == NodeColor.Red)
                {
                    parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    grandParent.Color = NodeColor.Red;
                    node = grandParent;
                }
                else if (uncle.Color == NodeColor.Black)
                {
                    if (parent == grandParent.Left)
                    {
                        if (node == parent.Right)
                        {
                            LeftRotation(parent);
                            parent = node;
                        }
                        
                        RightRotation(grandParent);
                        grandParent.Color = NodeColor.Red;
                        parent.Color = NodeColor.Black;
                    }
                    else if (parent == grandParent.Right)
                    {
                        if (node == parent.Left)
                        {
                            RightRotation(parent);
                            parent = node;
                        }
                        
                        LeftRotation(grandParent);
                        grandParent.Color = NodeColor.Red;
                        parent.Color = NodeColor.Black;
                    }
                }

                _root.Color = NodeColor.Black;
            }
        }

        public bool Delete(T toBeDeleted)
        {
            if (_root is null)
            {
                return false; 
            }

            Node<T> currentNode = _root;

            while (currentNode is not null)
            {
                if (_comparer.Compare(toBeDeleted, currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (_comparer.Compare(toBeDeleted, currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    if (currentNode.Left is not null)
                    {
                        // Find the largest node in the left subtree
                        Node<T> subtreeNode = currentNode.Left;
                        while (subtreeNode.Right is not null)
                        {
                            subtreeNode = subtreeNode.Right;
                        }

                        // swapping
                        T tmp = currentNode.Key;
                        currentNode.Key = subtreeNode.Key;
                        subtreeNode.Key = tmp;

                        DeleteNodeAndFixup(subtreeNode, false);

                        // invalidation
                        subtreeNode.Left = null;
                        subtreeNode.Right = null;
                        subtreeNode.Parent = null;

                        Node<T> copyCurrentNode = new Node<T>(currentNode.Key)
                        {
                            Left = currentNode.Left,
                            Right = currentNode.Right,
                            Parent = currentNode.Parent,
                            Color = currentNode.Color,
                        };

                        if (copyCurrentNode.Left is not null) { copyCurrentNode.Left.Parent = copyCurrentNode; }
                        if (copyCurrentNode.Right is not null) { copyCurrentNode.Right.Parent = copyCurrentNode; }

                        if (copyCurrentNode.Parent is not null)
                        {
                            if (copyCurrentNode.Parent.Left == currentNode) { copyCurrentNode.Parent.Left = copyCurrentNode; }
                            else { copyCurrentNode.Parent.Right = copyCurrentNode; }
                        }
                        else { _root = copyCurrentNode; }

                        // invalidation
                        currentNode.Left = null;
                        currentNode.Right = null;
                        currentNode.Parent = null;
                    }
                    else if (currentNode.Right is not null)
                    {
                        // Find the largest node in the left subtree
                        Node<T> subtreeNode = currentNode.Right;
                        while (subtreeNode.Left is not null)
                        {
                            subtreeNode = subtreeNode.Right;
                        }

                        // swapping
                        T tmp = currentNode.Key;
                        currentNode.Key = subtreeNode.Key;
                        subtreeNode.Key = tmp;

                        DeleteNodeAndFixup(subtreeNode, false);

                        // invalidation
                        subtreeNode.Left = null;
                        subtreeNode.Right = null;
                        subtreeNode.Parent = null;

                        Node<T> copyCurrentNode = new Node<T>(currentNode.Key)
                        {
                            Left = currentNode.Left,
                            Right = currentNode.Right,
                            Parent = currentNode.Parent,
                            Color = currentNode.Color,
                        };

                        if (copyCurrentNode.Left is not null) { copyCurrentNode.Left.Parent = copyCurrentNode; }
                        if (copyCurrentNode.Right is not null) { copyCurrentNode.Right.Parent = copyCurrentNode; }

                        if (copyCurrentNode.Parent is not null)
                        {
                            if (copyCurrentNode.Parent.Left == currentNode) { copyCurrentNode.Parent.Left = copyCurrentNode; }
                            else { copyCurrentNode.Parent.Right = copyCurrentNode; }
                        }
                        else { _root = copyCurrentNode; }

                        // invalidation
                        currentNode.Left = null;
                        currentNode.Right = null;
                        currentNode.Parent = null;
                    }
                    else
                    {
                        currentNode.Color = NodeColor.Red;
                        DeleteNodeAndFixup(currentNode, true);

                        // invalidation
                        currentNode.Left = null;
                        currentNode.Right = null;
                        currentNode.Parent = null;
                    }

                    return true;
                }
            }
            return false;
        }

        private void DeleteNodeAndFixup(Node<T> toBeDeleted, bool isToBeDeletedNull)
        {
            Node<T> child = null;
            bool isChildNull = false;

            if (toBeDeleted == _root)
            {
                _root = null;
                return;
            }

            if (!isToBeDeletedNull)
            {
                if (toBeDeleted.Left is not null)
                {
                    isChildNull = false;
                    child = toBeDeleted.Left;

                    if (toBeDeleted.Parent.Left == toBeDeleted)
                    {
                        toBeDeleted.Parent.Left = child;
                    }
                    else if (toBeDeleted.Parent.Right == toBeDeleted)
                    {
                        toBeDeleted.Parent.Right = child;
                    }

                    child.Parent = toBeDeleted.Parent;

                    // CASE 1: If one of the nodes is red, the replaced child is marked black
                    // and no more balancing is needed.
                    if (child.Color == NodeColor.Red || toBeDeleted.Color == NodeColor.Red)
                    {
                        child.Color = NodeColor.Black;
                        return;
                    }
                }
                else if (toBeDeleted.Right is not null)
                {
                    isChildNull = false;
                    child = toBeDeleted.Right;

                    if (toBeDeleted.Parent.Left == toBeDeleted)
                    {
                        toBeDeleted.Parent.Left = child;
                    }
                    else if (toBeDeleted.Parent.Right == toBeDeleted)
                    {
                        toBeDeleted.Parent.Right = child;
                    }

                    child.Parent = toBeDeleted.Parent;

                    // CASE 1: If one of the nodes is red, the replaced child is marked black
                    // and no more balancing is needed.
                    if (child.Color == NodeColor.Red || toBeDeleted.Color == NodeColor.Red)
                    {
                        child.Color = NodeColor.Black;
                        return;
                    }
                }
                else // toBeDeleted has no children
                {
                    // CASE 1: If one of the nodes is red, the replaced child is marked black
                    // and no more balancing is needed.
                    if (toBeDeleted.Color == NodeColor.Red)
                    {
                        if (toBeDeleted.Parent.Left == toBeDeleted)
                        {
                            toBeDeleted.Parent.Left = null;
                        }
                        else if (toBeDeleted.Parent.Right == toBeDeleted)
                        {
                            toBeDeleted.Parent.Right = null;
                        }

                        toBeDeleted.Parent = null;
                        return;
                    }

                    isChildNull = true;
                    child = toBeDeleted;
                    child.Color = NodeColor.Black;
                }
            }
            else
            {
                isChildNull = true;
                child = toBeDeleted;
                child.Color = NodeColor.Black;
            }

            // CASE 2: If we are here then both (child & toBeDeleted) are black.
            // In this case the child is considered as "double black".
            Node<T> currentNode = child;
            bool isCurrentNodeDoubleBlack = true;

            while (isCurrentNodeDoubleBlack && currentNode != _root)
            {
                Node<T> sibling = null;
                bool isSiblingLeftChild = false;

                if (currentNode.Parent.Left == currentNode)
                {
                    sibling = currentNode.Parent.Right;
                    isSiblingLeftChild = false;
                }
                else if (currentNode.Parent.Right == currentNode)
                {
                    sibling = currentNode.Parent.Left;
                    isSiblingLeftChild = true;
                }

                // if sibling is null, then it is black
                // and both of its children is black
                if (sibling is null)
                {
                    if (currentNode.Parent.Color == NodeColor.Red)
                    {
                        currentNode.Parent.Color = NodeColor.Black;
                        isCurrentNodeDoubleBlack = false;
                    }
                    else if (currentNode.Parent.Color == NodeColor.Black)
                    {
                        currentNode = currentNode.Parent;
                    }
                }
                else if (sibling.Color == NodeColor.Black)
                {
                    bool isLeftChildRed = false;
                    bool isRightChildRed = false;
                    if (sibling.Left is not null && sibling.Left.Color == NodeColor.Red)
                    {
                        isLeftChildRed = true;
                    }
                    if (sibling.Right is not null && sibling.Right.Color == NodeColor.Red)
                    {
                        isRightChildRed = true;
                    }

                    // CASE 2.1: If sibling is black and at least one of the
                    // sibling's children is red, we need to perform rotations.
                    if (isLeftChildRed || isRightChildRed)
                    {
                        if (isSiblingLeftChild)
                        {
                            if (isRightChildRed && !isLeftChildRed) // Left Right Case
                            {
                                LeftRotation(sibling);
                                RightRotation(currentNode.Parent);
                            }
                            else if (isLeftChildRed && !isRightChildRed) // Left Left Case
                            {
                                RightRotation(currentNode.Parent);
                            }
                        }
                        else
                        {
                            if (isLeftChildRed && !isRightChildRed) // Right Left Case
                            {
                                RightRotation(sibling);
                                LeftRotation(currentNode.Parent);
                            }
                            else if (isRightChildRed && !isLeftChildRed) // Right Right Case
                            {
                                LeftRotation(currentNode.Parent);
                            }
                        }

                        // After rotation, everything is okay.
                        isCurrentNodeDoubleBlack = false;
                    }
                    // CASE 2.2: Both children are black
                    else
                    {
                        sibling.Color = NodeColor.Red;

                        // if parent is red, we recolor it and end the balancing
                        // because red + double black = single black
                        if (currentNode.Parent.Color == NodeColor.Red)
                        {
                            currentNode.Parent.Color = NodeColor.Black;
                            isCurrentNodeDoubleBlack = false;
                        }
                        // if parent is black it is not double black (black + black = double black)
                        else if (currentNode.Parent.Color == NodeColor.Black)
                        {
                            currentNode = currentNode.Parent;
                        }

                        // here we stop using child anymore so
                        // if it was null node we need to remove it
                        if (isChildNull)
                        {
                            if (child.Parent.Left == child)
                            {
                                child.Parent.Left = null;
                            }
                            else if (child.Parent.Right == child)
                            {
                                child.Parent.Right = null;
                            }

                            // invalidation
                            child.Left = null;
                            child.Right = null;
                            child.Parent = null;

                            isChildNull = false;
                        }
                    }
                }
                else if (sibling.Color == NodeColor.Red)
                {
                    // recolor sibling & parent
                    sibling.Color = NodeColor.Black;
                    currentNode.Parent.Color = NodeColor.Red;

                    if (isSiblingLeftChild) // Left Left case
                    {
                        RightRotation(currentNode.Parent);
                    }
                    else // Right Right case
                    {
                        LeftRotation(currentNode.Parent);
                    }
                }
            }

            // removing child node if it was considered a null node
            if (isChildNull)
            {
                if (child.Parent.Left == child)
                {
                    child.Parent.Left = null;
                }
                else if (child.Parent.Right == child)
                {
                    child.Parent.Right = null;
                }

                // invalidation
                child.Left = null;
                child.Right = null;
                child.Parent = null;

                isChildNull = false;
            }
        }

        private void LeftRotation(Node<T> node)
        {
            Node<T> sibling = node.Right;
            node.Right = sibling.Left;

            if (sibling.Left is not null)
            {
                sibling.Left.Parent = node;
            }

            sibling.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = sibling;
            }
            else
            {
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = sibling;
                }
                else if (node == node.Parent.Right)
                {
                    node.Parent.Right = sibling;
                }
            }

            sibling.Left = node;
            node.Parent = sibling;
        }
        
        private void RightRotation(Node<T> node)
        {
            Node<T> sibling = node.Left;
            node.Left = sibling.Right;

            if (sibling.Right is not null)
            {
                sibling.Right.Parent = node;
            }

            sibling.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = sibling;
            }
            else
            {
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = sibling;
                }
                else if (node == node.Parent.Right)
                {
                    node.Parent.Right = sibling;
                }
            }

            sibling.Right = node;
            node.Parent = sibling;
        }
        
        public void PrintTree()
        {
            PrintTreeInternal(_root, 0);
        }
        
        private void PrintTreeInternal(Node<T> node, int space)
        {
            if (node is null)
            {
                return;
            }

            space += 20;

            PrintTreeInternal(node.Right, space);

            Console.WriteLine();
            for (int i = 20; i < space; ++i)
            {
                Console.Write(" ");
            }

            if (node.Color == NodeColor.Black)
            {
                Console.WriteLine($"B:{node.Key}");
            }
            else if (node.Color == NodeColor.Red)
            {
                Console.WriteLine($"R:{node.Key}");
            }

            PrintTreeInternal(node.Left, space);
        }
        
        public void Inorder(Action<T> toBeOperated)
        {
            InorderInternal(_root, toBeOperated);
        }

        public void Preorder(Action<T> toBeOperated)
        {
            PreorderInternal(_root, toBeOperated);
        }

        public void Postorder(Action<T> toBeOperated)
        {
            PostorderInternal(_root, toBeOperated);
        }
        
        private void InorderInternal(Node<T> node, Action<T> toBeOperated)
        {
            if (node is null)
            {
                return;
            }

            InorderInternal(node.Left, toBeOperated);
            toBeOperated(node.Key);
            InorderInternal(node.Right, toBeOperated);
        }

        private void PreorderInternal(Node<T> node, Action<T> toBeOperated)
        {
            if (node is null)
            {
                return;
            }

            toBeOperated(node.Key);
            PreorderInternal(node.Left, toBeOperated);
            PreorderInternal(node.Right, toBeOperated);
        }

        private void PostorderInternal(Node<T> node, Action<T> toBeOperated)
        {
            if (node is null)
            {
                return;
            }

            PreorderInternal(node.Left, toBeOperated);
            PreorderInternal(node.Right, toBeOperated);
            toBeOperated(node.Key);
        }
    }
}