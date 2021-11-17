using System;
using DataStructures;
using Xunit;

namespace Tests.DataStructures
{
    public class StackTests
    {
        [Fact]
        public void TestPush()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Assert.Equal(5, stack.Count);
            Assert.False(stack.IsEmpty);
            Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, stack.ToArray());
        }

        [Fact]
        public void TestPop()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Assert.Equal(5, stack.Count);
            
            stack.Pop();
            Assert.Equal(4, stack.Count);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Assert.Equal(new int[] { }, stack.ToArray());
            Assert.Throws<Exception>(() => stack.Pop());
        }

        [Fact]
        public void TestContains()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Assert.True(stack.Contains(0));
            Assert.False(stack.Contains(55));
        }
    }
}