using System;
using DataStructures;
using Xunit;

namespace Tests.DataStructures
{
    public class QueueTests
    {
        [Fact]
        public void TestEnqueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.Equal(5, queue.Count);
            Assert.False(queue.IsEmpty);
            Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, queue.ToArray());
        }
        
        [Fact]
        public void TestDequeue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.Equal(5, queue.Count);
            
            queue.Dequeue();
            Assert.Equal(4, queue.Count);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.Equal(new int[] { }, queue.ToArray());
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Fact]
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