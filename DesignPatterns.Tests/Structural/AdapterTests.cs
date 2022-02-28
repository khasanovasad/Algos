using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DesignPatterns.Structural;

namespace Tests.DesignPatterns.Structural;

[TestFixture]
public class AdapterTests
{
    [Test]
    public void Adapter_Should_Fit_Triangles_In_Place_Of_Rectangles_When_Needed()
    {
        const int maxNumberOfRectangles = 5;
        const double areaToCover = 100000;
        const double hundredKMs = 100;

        var rectangles = new List<IRectangle>();
        double totalAreCovered = 0;
        int currentNumberOfRectangles = 0;

        while (totalAreCovered != areaToCover)
        {
            if (currentNumberOfRectangles < maxNumberOfRectangles)
            {
                var rectangle = new Rectangle(length: hundredKMs, width: hundredKMs);
                rectangles.Add(rectangle);
                    
                totalAreCovered += rectangle.CalculateArea();
                ++currentNumberOfRectangles;
            }
            else
            {
                var triangle = new Triangle(baseLength: hundredKMs, height: hundredKMs);
                IRectangle rectangleAdapter = new RectangleAdapter(triangle);
                rectangles.Add(rectangleAdapter);
                    
                totalAreCovered += rectangleAdapter.CalculateArea();
            }
        }

        // var stringBuilder = new StringBuilder();
        // foreach (var rectangle in rectangles)
        // {
        //     stringBuilder.AppendFormat("{0}\n", rectangle.AboutMe());
        // }
        // TestContext.WriteLine(stringBuilder.ToString());
            
        Assert.AreEqual(areaToCover, totalAreCovered);
    }
}