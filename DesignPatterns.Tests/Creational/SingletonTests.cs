using DesignPatterns.Creational;
using NUnit.Framework;

namespace Tests.DesignPatterns.Creational;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void Singleton_Should_Only_Exists_One_Instance()
    {
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;

        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.AreSame(instance1, instance2);
    }
}