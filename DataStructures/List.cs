using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class List<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        public bool IsEmpty { get { return Count == 0; } }

        public ref T this[int index] { get => ref _data[index]; }
        
        private T[] _data;
        private Comparer<T> _comparer;
        
        public List(int initialCapacity = 4, Comparer<T> customComparer = null)
        {
            _data = new T[initialCapacity];
            _comparer = customComparer ?? Comparer<T>.Default;
            Capacity = initialCapacity >= 4 ? initialCapacity : 4;
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == Capacity - 1)
            {
                Resize();
            }
            _data[Count] = item;
            ++Count;
        }

        public void Insert(int index, T item)
        {
            if (Count == Capacity - 1)
            {
                Resize();
            }

            for (int i = Count; i > index; --i)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = item;
            ++Count;
        }

        public ref T ElementAt(int index)
        {
            return ref _data[index];
        }

        public ref T Last()
        {
            return ref _data[Count - 1];
        }

        public ref T First()
        {
            return ref _data[0];
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0 && index >= Count || IsEmpty)
            {
                return false;
            }
            
            for (int i = index; i < Count; ++i)
            {
                _data[i] = _data[i + 1];
            }

            --Count;
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (IsEmpty)
            {
                return false;
            }
            T tmp = ElementAt(index);
            return Remove(tmp);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_comparer.Compare(_data[i],item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            Capacity = 4;
            Count = 0;
            _data = new T[Capacity];
        }

        public T[] ToArray()
        {
            var result = new T[Count];
            for (int i = 0; i < Count; ++i)
            {
                result[i] = _data[i];
            }

            return result;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_comparer.Compare(_data[i], item) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        public void TrimExcess()
        {
            if (Count == 0)
            {
               return;
            }
            
            Capacity = Count;
            T[] tmp = new T[Capacity];

            for (int i = 0; i < Count; ++i)
            {
                tmp[i] = _data[i];
            }

            _data = tmp;
        }

        private void Resize()
        {
            var tmp = new T[Capacity + Capacity / 2];

            for (int i = 0; i < Count; ++i)
            {
                tmp[i] = _data[i];
            }

            _data = tmp;
            Capacity += Capacity / 2;
        }
    }
}
