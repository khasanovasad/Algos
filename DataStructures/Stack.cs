namespace DataStructures;

public class Stack<T>
{
    private LinkedList<T> _data = new LinkedList<T>();

    public int Count { get { return _data.Count; } }
    public bool IsEmpty { get { return Count == 0; } }

    public Stack() { }

    public void Push(T item)
    {
        _data.AddLast(item);
    }

    public T Pop()
    {
        if (IsEmpty)
        {
            throw new Exception("Attempt to pop from empty stack.");
        }

        T data = _data.Tail.Data;
        _data.RemoveLast();
        return data;
    }

    public void Clear()
    {
        _data.Clear();
    }

    public bool Contains(T item)
    {
        return _data.Contains(item);
    }

    public T[] ToArray()
    {
        return _data.ToArray();
    }
}