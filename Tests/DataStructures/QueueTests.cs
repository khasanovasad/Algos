using System;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructures
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Queue_Enqueue_Adds_Elements_To_The_Queue()
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
        public void Queue_Dequeue_Removes_Elements_From_The_Queue()
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
        public void Queue_Contains_Returns_The_Correct_Value_Accordingly()
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