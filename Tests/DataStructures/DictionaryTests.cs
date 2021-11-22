using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructures
{
    public class DictionaryTests
    {
        [Test]
        public void Dictionary_Add_Should_Add_Item_To_The_HashTable()
        {
            var dict = new Dictionary<int, string>();
            for (int i = 1; i <= 10; ++i)
            {
                dict.Add(i, i.ToString());
            }
            
            Assert.AreEqual(10, dict.Count);
            Assert.True(dict.ContainsKey(1));
            Assert.False(dict.ContainsKey(15));
            Assert.True(dict.ContainsValue("1"));
            Assert.False(dict.ContainsValue("11"));
        }

        [Test]
        public void Dictionary_IndexOperator_Should_Return_Desired_Value_According_To_The_Key()
        {
            var dict = new Dictionary<int, string>();
            for (int i = 1; i <= 10; ++i)
            {
                dict.Add(i, i.ToString());
            }
            
            Assert.AreEqual("1", dict[1]);
            Assert.AreEqual("5", dict[5]);
            Assert.AreNotEqual("1", dict[10]);
        }
    }
}