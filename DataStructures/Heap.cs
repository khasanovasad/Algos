using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Heap<T>
    {
        private List<T> _data;
        private readonly Comparer<T> _comparer;

        public bool IsMaxHeap { get;  }

        public Heap(bool isMaxHeap = false, Comparer<T> comparer = null)
        {
            IsMaxHeap = isMaxHeap;
            _comparer = comparer ?? Comparer<T>.Default;
            _data = new List<T>(initialCapacity: 4, customComparer: _comparer);
        }

        public void Insert(T newItem)
        {
            _data.Add(newItem);
            BuildHeap();
        }

        public void Remove(T toBeDeleted)
        {
            if (_data.IndexOf(toBeDeleted) != -1 && _data.IndexOf(toBeDeleted) == _data.Count - 1)
            {
                _data.Remove(toBeDeleted);
            }
            else if (_data.IndexOf(toBeDeleted) != -1 && _data.IndexOf(toBeDeleted) != _data.Count - 1)
            {
                var tmp = _data[^1];
                _data[^1] = _data[_data.IndexOf(toBeDeleted)];
                _data[_data.IndexOf(toBeDeleted)] = tmp;
                _data.Remove(_data.Last());
            }
            BuildHeap();
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public T Peek()
        {
            return _data.First();
        }

        public T Extract()
        {
            var minMax = _data.First();
            _data.Remove(_data.First());
            return minMax;
        }

        public void Print()
        {
            foreach (var item in _data.ToArray())
            {
                Console.WriteLine($"{item} ");                
            }
            Console.WriteLine();
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }
        
        private void MaxHeapify(int size, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            int largest = i;

            if (left < size && _comparer.Compare(_data[largest], _data[left]) < 0)
            {
                largest = left;
            }

            if (right < size && _comparer.Compare(_data[largest], _data[right]) < 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                var tmp = _data[i];
                _data[i] = _data[largest];
                _data[largest] = tmp;
                MaxHeapify(size, largest);
            }
        }

        private void MinHeapify(int size, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            int largest = i;
            
            if (left < size && _comparer.Compare(_data[largest], _data[left]) > 0)
            {
                largest = left;
            }

            if (right < size && _comparer.Compare(_data[largest], _data[right]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                var tmp = _data[i];
                _data[i] = _data[largest];
                _data[largest] = tmp;
                MaxHeapify(size, largest);
            }
        }

        private void BuildHeap()
        {
            for (int i = (_data.Count - 1) / 2; i >= 0; --i)
            {
                if (IsMaxHeap) MaxHeapify(_data.Count, i);
                else MinHeapify(_data.Count, i);
            }
        }
    }
}