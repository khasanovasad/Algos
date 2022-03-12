using System;
using DesignPatterns.Structural;
using NUnit.Framework;

namespace DesignPatterns.Tests.Structural;

public class DecoratorTests
{
    [Test]
    public void Decorator_Check_Additional_Dynamic_Features()
    {
        const string expectedOutput =
            "House is constructed. It's price is: $10,000\nHouse is constructed. It's price is: $10,000\n -- Added one more floor. Pay additional 2500\nHouse is constructed. It's price is: $10,000\n -- Added one more floor. Pay additional 2500\n    --- Repainted the house. Pay additional 1000";
            
            
        AbstractHouse house = new ConcreteHouse();
        string result = house.MakeHouse();

        house = new FloorDecorator(house);
        result = String.Concat(result, "\n", house.MakeHouse());

        house = new PaintDecorator(house);
        result = String.Concat(result, "\n", house.MakeHouse());
        // TestContext.WriteLine(result);

        Assert.AreEqual(expectedOutput, result);
    }
}