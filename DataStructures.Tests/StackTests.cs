using System;
using DataStructures;
using NUnit.Framework;

namespace DataStructures.Tests;

[TestFixture]
public class StackTests
{
    [Test]
    public void Stack_Push_Should_Add_Element_To_The_Stack()
    {
        var stack = new Stack<int>();
        stack.Push(0);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        Assert.AreEqual(5, stack.Count);
        Assert.False(stack.IsEmpty);
        Assert.AreEqual(new int[] { 0, 1, 2, 3, 4 }, stack.ToArray());
    }

    [Test]
    public void Stack_Pop_Should_Remove_Element_From_The_Top_Of_The_Stack()
    {
        var stack = new Stack<int>();
        stack.Push(0);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        Assert.AreEqual(5, stack.Count);
            
        stack.Pop();
        Assert.AreEqual(4, stack.Count);

        stack.Pop();
        stack.Pop();
        stack.Pop();
        stack.Pop();
        Assert.AreEqual(new int[] { }, stack.ToArray());
        Assert.Throws<Exception>(() => stack.Pop());
    }

    [Test]
    public void Stack_Contains_Should_Return_The_Correct_Value_Accordingly()
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