using System.Collections.Generic;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructures;

[TestFixture]
public class HeapTests
{
    private record Contender(string Name, int Rank);

    [Test]
    public void Heap_ToArray_Should_Return_Items_Sorted_With_Custom_Comparer()
    {
        var customComparer = Comparer<Contender>.Create((a, b) => Comparer<int>.Default.Compare(a.Rank, b.Rank));
        var heap = new Heap<Contender>(isMaxHeap: false, comparer: customComparer);

        heap.Insert(new Contender(Name: "Benjamin Franklin", Rank: 2));
        heap.Insert(new Contender(Name: "Charles Darwin", Rank: 4));
        heap.Insert(new Contender(Name: "Leonardo da Vinci", Rank: 3));
        heap.Insert(new Contender(Name: "John von Neumann", Rank: 5));
        heap.Insert(new Contender(Name: "Alan Turing", Rank: 1));
        heap.Insert(new Contender(Name: "Isaac Newton", Rank: 6));
            
        Assert.AreEqual(
            new []
            {
                new Contender(Name: "Alan Turing", Rank: 1),
                new Contender(Name: "Benjamin Franklin", Rank: 2),
                new Contender(Name: "Leonardo da Vinci", Rank: 3),
                new Contender(Name: "John von Neumann", Rank: 5),
                new Contender(Name: "Charles Darwin", Rank: 4),
                new Contender(Name: "Isaac Newton", Rank: 6),
            }, 
            heap.ToArray());
    }
        
    [Test]
    public void Heap_Insert_Should_Create_A_Correct_MaxHeap()
    {
        var heap = new Heap<int>(isMaxHeap: true);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
            
        Assert.AreEqual(new [] { 9, 4, 5, 1, 3, 2 }, heap.ToArray());
    }
        
    [Test]
    public void Heap_Insert_Should_Create_A_Correct_MinHeap()
    {
        var heap = new Heap<int>(isMaxHeap: false);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
            
        Assert.AreEqual(new [] { 1, 2, 3, 9, 4, 5 }, heap.ToArray());
    }
        
    [Test]
    public void Heap_Remove_Should_Remove_Element_Form_MinHeap()
    {
        var heap = new Heap<int>(isMaxHeap: false);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
        heap.Remove(3);
            
        Assert.AreEqual(new [] { 1, 2, 5, 9, 4 }, heap.ToArray());
    }
        
    [Test]
    public void Heap_Remove_Should_Remove_Element_Form_MaxHeap()
    {
        var heap = new Heap<int>(isMaxHeap: true);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
        heap.Remove(5);
            
        Assert.AreEqual(new [] { 9, 4, 2, 1, 3 }, heap.ToArray());
    }

    [Test]
    public void Heap_Peek_Should_Return_The_Top_Element()
    {
        var heap = new Heap<int>(isMaxHeap: true);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
            
        Assert.AreEqual(9, heap.Peek());
        Assert.True(heap.Contains(9));
    }
        
    [Test]
    public void Heap_Extract_Should_Extract_The_Top_Element()
    {
        var heap = new Heap<int>(isMaxHeap: false);
        heap.Insert(3);
        heap.Insert(9);
        heap.Insert(2);
        heap.Insert(1);
        heap.Insert(4);
        heap.Insert(5);
            
        Assert.AreEqual(1, heap.Extract());
        Assert.False(heap.Contains(1));
    }
}