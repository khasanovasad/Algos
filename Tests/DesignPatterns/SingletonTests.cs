using DesignPatterns;
using Xunit;

namespace Tests.DesignPatterns
{
    public class SingletonTests
    {
        [Fact]
        public void Test()
        {
            var instance1 = Singleton.Instance;
            var instance2 = Singleton.Instance;

            Assert.NotNull(instance1);
            Assert.NotNull(instance2);
            Assert.Same(instance1, instance2);
        }
    }
}
