using DataStructures;
using Xunit;

namespace Tests.DataStructures
{
    public class DictionaryTests
    {
        [Fact]
        public void TestAdd()
        {
            var dict = new Dictionary<int, string>();
            for (int i = 1; i <= 10; ++i)
            {
                dict.Add(i, i.ToString());
            }
            
            Assert.Equal(10, dict.Count);
            Assert.True(dict.ContainsKey(1));
            Assert.False(dict.ContainsKey(15));
            Assert.True(dict.ContainsValue("1"));
            Assert.False(dict.ContainsValue("11"));
        }

        [Fact]
        public void IndexOperatorTest()
        {
            var dict = new Dictionary<int, string>();
            for (int i = 1; i <= 10; ++i)
            {
                dict.Add(i, i.ToString());
            }
            
            Assert.Equal("1", dict[1]);
            Assert.Equal("5", dict[5]);
            Assert.NotEqual("1", dict[10]);
        }
    }
}