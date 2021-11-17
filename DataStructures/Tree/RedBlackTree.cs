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

        public void Delete(T toBeDeleted)
        {
            DeleteInternal(_root, toBeDeleted);
        }

        private void DeleteInternal(Node<T> node, T toBeDeleted)
        {
            throw new NotImplementedException();
        }

        private void DeletionFixup(Node<T> node)
        {
            throw new NotImplementedException();
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