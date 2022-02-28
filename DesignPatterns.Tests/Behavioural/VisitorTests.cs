using System.Text;
using NUnit.Framework;
using DesignPatterns.Behavioural;

namespace Tests.DesignPatterns.Behavioural;

[TestFixture]
public class VisitorTests
{
    [Test]
    public void Visitor_Should_When()
    {
        const string expectedResult = "Visited the dot shape.\tVisited the circle shape.\tVisited the rectangle shape.\tVisited the triangle shape.\t";
        
        var strBuilder = new StringBuilder();
        IVisitor visitor = new XMLExportVisitor();
        var shapes = new IShape[]
        {
            new Dot(),
            new Circle(),
            new Rectangle(),
            new Triangle(),
        };

        foreach (var shape in shapes)
        {
            strBuilder.Append(shape.Accept(visitor)).Append('\t');
        }

        var result = strBuilder.ToString();
        
        Assert.AreEqual(expectedResult, result);
    }
}