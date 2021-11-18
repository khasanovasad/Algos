using DesignPatterns;
using NUnit.Framework;

namespace Tests.DesignPatterns
{
    public class SingletonTests
    {
        [Test]
        public void Test()
        {
            var instance1 = Singleton.Instance;
            var instance2 = Singleton.Instance;

            Assert.NotNull(instance1);
            Assert.NotNull(instance2);
            Assert.AreSame(instance1, instance2);
        }
    }
}
