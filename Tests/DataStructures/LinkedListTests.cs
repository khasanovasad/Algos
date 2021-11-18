using System;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructures
{
    public class LinkedListTests
    {
        [Test]
        public void TestAddFirst()
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 10; ++i)
            {
                list.AddFirst(i);
            }

            Assert.AreEqual(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, list.ToArray());
        }

        [Test]
        public void TestAddLast()
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 10; ++i)
            {
                list.AddLast(i);
            }

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, list.ToArray());
        }

        [Test]
        public void TestAddBefore()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(5);

            var walker = list.Head;
            while (walker is not null)
            {
                if (walker.Data == 4)
                {
                    list.AddBefore(3, walker);
                }
                walker = walker.Next;
            }

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5 }, list.ToArray());
        }

        [Test]
        public void TestAddAfter()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(5);

            var walker = list.Head;
            while (walker is not null)
            {
                if (walker.Data == 2)
                {
                    list.AddAfter(3, walker);
                }
                walker = walker.Next;
            }

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5 }, list.ToArray());
        }

        [Test]
        public void TestClear()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5 }, list.ToArray());

            list.Clear();
            Assert.AreEqual(new int[] {}, list.ToArray());
        }

        [Test]
        public void TestRemoveFirst()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.RemoveFirst();
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, list.ToArray());

            list.Clear();
            Assert.Throws<Exception>(() => list.RemoveFirst());
        }

        [Test]
        public void TestRemoveLast()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.RemoveLast();
            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4 }, list.ToArray());

            list.Clear();
            Assert.Throws<Exception>(() => list.RemoveLast());
        }

        [Test]
        public void TestRemove()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(69);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            var walker = list.Tail;
            while (walker?.Data != 69) { walker = walker.Prev; }
            list.Remove(walker);

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5 }, list.ToArray());

            list.Clear();
            Assert.Throws<Exception>(() => list.Remove(walker));
        }

        [Test]
        public void TestContains()
        {
            var list = new LinkedList<int>();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            Assert.True(list.Contains(0));
            Assert.False(list.Contains(55));
        }
    }
}