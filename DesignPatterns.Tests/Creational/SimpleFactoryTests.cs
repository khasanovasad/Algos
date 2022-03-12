using System;
using NUnit.Framework;
using DesignPatterns.Creational;

namespace DesignPatterns.Tests.Creational;

[TestFixture]
public class SimpleFactoryTests
{
    [Test]
    public void SimpleFactory_CreateButton_Should_Create_AndroidButton()
    {
        const string buttonType = "android";
        var simpleFactory = new SimpleFactory();

        var button = simpleFactory.CreateButton(buttonType);
        var result = button.Click();

        Assert.AreEqual("Android button is clicked.", result);
    }

    [Test]
    public void SimpleFactory_CreateButton_Should_Create_iOSButton()
    {
        const string buttonType = "ios";
        var simpleFactory = new SimpleFactory();

        var button = simpleFactory.CreateButton(buttonType);
        var result = button.Click();

        Assert.AreEqual("iOS button is clicked.", result);
    }
}