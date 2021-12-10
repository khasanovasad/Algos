using System;
using NUnit.Framework;
using DesignPatterns.Structural;

namespace Tests.DesignPatterns.Structural;

[TestFixture]
public class FacadeTests
{
    [Test]
    public void Facade_Operation_Carries_Out_All_Subsystem_Operations()
    {
        const string expectedResult = "Operation1 is completed.\nOperation2 is completed.\nOperation3 is completed.\n";

        var system = new SystemFacade();
        var result = system.Operation();
        TestContext.WriteLine(result);

        Assert.AreEqual(expectedResult, result);
    }
}