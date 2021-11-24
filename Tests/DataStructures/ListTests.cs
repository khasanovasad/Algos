using System;
using DataStructures;
using NUnit.Framework;
using Collections = System.Collections.Generic;

namespace Tests.DataStructures
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void List_Ctor()
        {
            var list = new List<int>(0, Collections.Comparer<int>.Default);
            list.TrimExcess();
            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(0, list.Count);
        }
        
        [Test]
        public void List_Add_Should_Append_The_List()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, list.ToArray());
        }

        [Test]
        public void List_Insert_Should_Insert_Element_At_Desired_Position()
        {
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Insert(0,1);
            list.Insert(2,3);
            list.Insert(4,5);
            
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 }, list.ToArray());
        }

        [Test]
        public void List_ElementAt_Should_Return_The_Desired_Value()
        {
            var list = new List<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(5));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.AreEqual(3, list.ElementAt(2));
        }

        [Test]
        public void List_Contains_Return_True_If_Value_Exists_In_The_List()
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

        [Test]
        public void List_Remove_Should_Delete_An_Element_From_The_List()
        {
            var list = new List<int>();

            Assert.False(list.Remove(69));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(3);
            
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(new int[] { 1, 2, 4, 5 }, list.ToArray());
        }

        [Test]
        public void List_IndexOf_Returns_The_Correct_Index_Of_The_Value_In_The_List()
        {
            var list = new List<int>();
            
            Assert.AreEqual(-1, list.IndexOf(69));
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(-1, list.IndexOf(69));
            Assert.AreEqual(4, list.IndexOf(5));
        }

        [Test]
        public void List_Clear_Should_Remove_All_Elements()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Clear();
            
            Assert.AreEqual(Array.Empty<int>(), list.ToArray());
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [Test]
        public void List_TrimExcess_Trims_The_Capacity_To_The_Length()
        {
            var list = new List<int>();
            
            list.TrimExcess();
            Assert.AreNotEqual(list.Count, list.Capacity);
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.TrimExcess();
            
            Assert.AreEqual(list.Count, list.Capacity);
        }
    }
}