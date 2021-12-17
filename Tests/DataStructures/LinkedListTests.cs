namespace Tests.DataStructures;

[TestFixture]
public class LinkedListTests
{
    [Test]
    public void LinkedList_AddFirst_Should_Add_Element_To_The_Head()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < 10; ++i)
        {
            list.AddFirst(i);
        }

        Assert.AreEqual(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, list.ToArray());
    }

    [Test]
    public void LinkedList_AddLast_Should_Add_Element_To_The_Tail()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < 10; ++i)
        {
            list.AddLast(i);
        }

        Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, list.ToArray());
    }

    [Test]
    public void LinkedList_AddBefore_Should_Add_Element_Before_The_Given_Node()
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
    public void LinkedList_AddAfter_Should_Add_Element_After_The_Given_Node()
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
    public void LinkedList_Clear_Should_Clear_The_LinkedList()
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
    public void LinkedList_RemoveFirst_Should_Remove_The_First_Element()
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
    public void LinkedList_RemoveLast_Should_Remove_The_Last_Element()
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
    public void LinkedList_Remove_Should_Remove_The_Node_With_Certain_Value()
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
    public void LinkedList_Contains_Should_Return_The_Correct_Value()
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