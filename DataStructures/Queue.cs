namespace DataStructures;

public class Queue<T>
{
    private LinkedList<T> _data = new LinkedList<T>();

    public int Count { get { return _data.Count;  } }
        
    public bool IsEmpty { get { return _data.Count == 0; } }
        
    public Queue() { }

    public void Clear()
    {
        _data.Clear();
    }

    public bool Contains(T item)
    {
        return _data.Contains(item);
    }
        
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new Exception("Attempt to dequeue from empty queue.");
        }
            
        T element = _data.Head.Data;
        _data.RemoveFirst();
        return element;
    }

    public void Enqueue(T item)
    {
        _data.AddLast(item);
    }

    public T[] ToArray()
    {
        return _data.ToArray();
    }
}