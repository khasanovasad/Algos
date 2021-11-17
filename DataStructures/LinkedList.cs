using System;

namespace DataStructures
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

        public bool IsEmpty { get { return Count == 0; } }
        public int Count { get; private set; }

        public LinkedList()
        {
        }

        private void AddToEmptyList(T item, LinkedListNode<T> newNode)
        {
            Head = newNode;
            Tail = newNode;
            ++Count;
        }

        public void AddFirst(T item)
        {
            var newNode = new LinkedListNode<T>(item);
            if (!IsEmpty)
            {
                Head.Prev = newNode;    
                newNode.Next = Head;
                Head = newNode;
                ++Count;
                return;
            }
            AddToEmptyList(item, newNode);
        }

        public void AddLast(T item)
        {
            var newNode = new LinkedListNode<T>(item);
            if (!IsEmpty)
            {
                Tail.Next = newNode;    
                newNode.Prev = Tail;
                Tail = newNode;
                ++Count;
                return;
            }
            AddToEmptyList(item, newNode);
        }

        public void AddBefore(T item, LinkedListNode<T> node)
        {
            var newNode = new LinkedListNode<T>(item);
            if (!IsEmpty)
            {
                node.Prev.Next = newNode;
                newNode.Prev = node.Prev;
                node.Prev = newNode;
                newNode.Next = node;
                ++Count;
                return;
            }
            AddToEmptyList(item, newNode);
        }

        public void AddAfter(T item, LinkedListNode<T> node)
        {
            var newNode = new LinkedListNode<T>(item);
            if (!IsEmpty)
            {
                node.Next.Prev = newNode;
                newNode.Next = node.Next;
                node.Next = newNode;
                newNode.Prev = node;
                ++Count;
                return;
            }
            AddToEmptyList(item, newNode);
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }
        
        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new Exception("Attempt to remove element from empty list.");
            }

            try 
            {
                Head.Next.Prev = null;
                var tmp = Head;
                Head = Head.Next;
                tmp.Next = null;
                tmp = null;
            }
            catch 
            {
                Head = Tail = null;
            }
            --Count;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
            {
                throw new Exception("Attempt to remove element from empty list.");
            }

            try
            {
                Tail.Prev.Next = null;
                var tmp = Tail;
                Tail = Tail.Prev;
                tmp.Prev = null;
                tmp = null;
            }
            catch
            {
                Head = Tail = null;
            }
            --Count;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (IsEmpty)
            {
                throw new Exception("Attempt to remove element from empty list.");
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            node.Prev = null;
            node.Next = null;
            node = null;
            --Count;
        }

        public bool Contains(T item)
        {
            var walker = Head;
            while (walker is not null)
            {
                if (walker.Data.Equals(item))
                {
                    return true;
                }
                walker = walker.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var walker = Head;
            int i = 0;
            while (walker is not null && i < array.Length)
            {
                array[i++] = walker.Data;
                walker = walker.Next;
            }
            return array;
        }
    }

    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }
        public T Data { get; set; }

        public LinkedListNode(T data) 
        {
            Data = data;
        }

        public LinkedListNode()
        {
        }
    }
}