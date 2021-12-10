using System;
using System.Collections.Generic;

namespace DataStructures;

public class BinarySearchTree<T>
{
    public class Node<TY>
    {
        public Node<TY> Left { get; set; }
        public Node<TY> Right { get; set; }
        public TY Key { get; set; }

        public Node(TY key = default)
        {
            Key = key;
            Left = Right = null;
        }
    }
        
    private Node<T> _root;
    private Comparer<T> _comparer;

    public BinarySearchTree(Comparer<T> comparer = null) 
    {
        _root = null;
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public bool Insert(T toBeAdded)
    {
        _root = InsertInternal(_root, toBeAdded);
        return _root is not null;
    }

    public bool Delete(T toBeDeleted)
    {
        _root = DeleteInternal(_root, toBeDeleted);
        return _root is not null;

    }
        
    public Node<T> Min()
    {
        return MinInternal(_root);
    }
        
    public Node<T> Max()
    {
        return MaxInternal(_root);
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

    public void PrintTree()
    {
        PrintTreeInternal(_root, 0);
    }

    private Node<T> InsertInternal(Node<T> node, T toBeAdded)
    {
        if (node is null)
        {
            node = new Node<T>(toBeAdded);
            return node;
        }

        if (_comparer.Compare(toBeAdded, node.Key) < 0)
        {
            node.Left = InsertInternal(node.Left, toBeAdded);
        }
        else if (_comparer.Compare(toBeAdded, node.Key) > 0)
        {
            node.Right = InsertInternal(node.Right, toBeAdded);
        }

        return node;
    }

    private Node<T> DeleteInternal(Node<T> node, T toBeDeleted)
    {
        if (node is null)
        {
            return null;
        }

        if (_comparer.Compare(node.Key, toBeDeleted) > 0)
        {
            node.Left = DeleteInternal(node.Left, toBeDeleted);
        }
        else if (_comparer.Compare(node.Key, toBeDeleted) < 0)
        {
            node.Right = DeleteInternal(node.Right, toBeDeleted);
        }
        else
        {
            Node<T> tmp;
            if (node.Left is null)
            {
                tmp = node.Right;
                node = null;
                return tmp;
            }
            else if (node.Right is null)
            {
                tmp = node.Left;
                node = null;
                return tmp;
            }

            tmp = MinInternal(node.Right);
            node.Key = tmp.Key;
            node.Right = DeleteInternal(node.Right, tmp.Key);
        }

        return node;
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
        Console.WriteLine(node.Key);

        PrintTreeInternal(node.Left, space);
    }
}