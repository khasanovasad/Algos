using System;
using System.Collections.Generic;

namespace DataStructures
{
    // Probably the worst hash table written ever
    public class Dictionary<TKey, TValue>
    {
        public int Count { get; private set; }
        public int Length { get; private set; } = 2;
        
        private List<KeyValuePair<TKey, TValue>>[] _table;
        private Comparer<TKey> _comparer;

        public Dictionary(Comparer<TKey> customComparer = null)
        {
            _comparer = customComparer ?? Comparer<TKey>.Default;
            _table = new List<KeyValuePair<TKey, TValue>>[Length];
        }

        public object this[TKey key]
        {
            get
            {
                var hash = HashFunction(key);
                var row = _table[hash];

                if (row is null)
                {
                    return null;
                }

                for (int i = 0; i < row.Count; ++i)
                {
                    var cell = row[i];
                    if (cell.Key.Equals(key))
                    {
                        return cell.Value;
                    }
                }

                return null;
            }
        }
        
        public void Add(TKey key, TValue value)
        {
            ++Count;
            
            if (Count > _table.Length)
            {
                IncreaseTable();
            }

            var hash = HashFunction(key);

            if (_table[hash] is null)
            {
                _table[hash] = new List<KeyValuePair<TKey, TValue>>();
            }

            _table[hash].Add(new KeyValuePair<TKey, TValue> { Key = key, Value = value });
        }
        
        public bool ContainsKey(TKey key)
        {
            foreach (var row in _table)
            {
                if (row is null) continue;
                    
                for (int i = 0; i < row.Count; ++i)
                {
                    var cell = row[i];
                    if (cell.Key.Equals(key))
                    {
                        return true;
                    }
                } 
            }

            return false;
        }
        
        public bool ContainsValue(TValue value)
        {
            foreach (var row in _table)
            {
                if (row is null) continue;
                
                for (int i = 0; i < row.Count; ++i)
                {
                    var cell = row[i];
                    if (cell.Value.Equals(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void IncreaseTable()
        {
            Length += _table.Length / 2;
            var newTable = new List<KeyValuePair<TKey, TValue>>[Length];
            foreach (var row in _table)
            {
                if (row is null)
                {
                    continue;
                }

                for (int i = 0; i < row.Count; ++i)
                {
                    var cell = row[i];
                    var newHash = HashFunction(cell.Key);
                    if (newTable[newHash] is null)
                    {
                        newTable[newHash] = new List<KeyValuePair<TKey, TValue>>();
                        newTable[newHash].Add(new KeyValuePair<TKey, TValue>{ Key = cell.Key, Value = cell.Value });
                    }
                }
            }

            _table = newTable;
        }

        private int HashFunction(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Length;
        }
    }

    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}