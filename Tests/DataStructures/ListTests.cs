using System;
using Xunit;
using DataStructures;
using Collections = System.Collections.Generic;

namespace Tests.DataStructures
{
    public class ListTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var list = new List<int>(0, Collections.Comparer<int>.Default);
            list.TrimExcess();
            Assert.Equal(4, list.Capacity);
            Assert.Equal(0, list.Count);
        }
        
        [Fact]
        public void AddTest()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, list.ToArray());
        }

        [Fact]
        public void InsertTest()
        {
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Insert(0,1);
            list.Insert(2,3);
            list.Insert(4,5);
            
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, list.ToArray());
        }

        [Fact]
        public void ElementAtTest()
        {
            var list = new List<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(5));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Equal(3, list.ElementAt(2));
        }

        [Fact]
        public void ContainsTest()
        {
            var list = new List<int>();
            
            Assert.False(list.Contains(69));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Assert.True(list.Contains(3));
        }

        [Fact]
        public void RemoveTest()
        {
            var list = new List<int>();

            Assert.False(list.Remove(69));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(3);
            
            Assert.Equal(4, list.Count);
            Assert.Equal(new int[] { 1, 2, 4, 5 }, list.ToArray());
        }

        [Fact]
        public void IndexOfTest()
        {
            var list = new List<int>();
            
            Assert.Equal(-1, list.IndexOf(69));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Assert.Equal(0, list.IndexOf(1));
            Assert.Equal(-1, list.IndexOf(69));
            Assert.Equal(4, list.IndexOf(5));
        }

        [Fact]
        public void ClearTest()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Clear();
            
            Assert.Equal(Array.Empty<int>(), list.ToArray());
            Assert.Equal(0, list.Count);
            Assert.Equal(4, list.Capacity);
        }

        [Fact]
        public void TrimExcessTest()
        {
            var list = new List<int>();
            
            list.TrimExcess();
            Assert.NotEqual(list.Count, list.Capacity);
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.TrimExcess();
            
            Assert.Equal(list.Count, list.Capacity);
        }
    }
}