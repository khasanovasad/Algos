using System;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructures
{
    public class QueueTests
    {
        [Test]
        public void TestEnqueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.AreEqual(5, queue.Count);
            Assert.False(queue.IsEmpty);
            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4 }, queue.ToArray());
        }
        
        [Test]
        public void TestDequeue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.AreEqual(5, queue.Count);
            
            queue.Dequeue();
            Assert.AreEqual(4, queue.Count);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(new int[] { }, queue.ToArray());
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Test]
        public void TestContains()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.True(queue.Contains(0));
            Assert.False(queue.Contains(55));
        }
    }
}