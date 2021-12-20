/**
 * GoF DEFINITION:
 * Represent an operation to be performed on the elements of an object structure. Visitor 
 * lets you define a new operation without changing the classes of the elements on which it 
 * operates.
 * 
 * CONCEPT:
 * In this pattern, you separate an algorithm from an object structure. So, you can add 
 * new operations on objects without modifying their existing architecture. This pattern 
 * supports the open/close principle (which says the extension is allowed, but modification 
 * is disallowed for entities such as class, function, and so on).*
 */

using System;

namespace DesignPatterns.Behavioural;

public interface IShape
{
    void Move(int x, int y);
    void Draw();
    string Accept(IVisitor visitor);
}

public class Dot : IShape
{
    public void Move(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Draw()
    {
        throw new NotImplementedException();
    }

    public string Accept(IVisitor visitor)
    {
        return visitor.VisitDot(this);
    }
}

public class Circle : IShape
{
    public void Move(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Draw()
    {
        throw new NotImplementedException();
    }

    public string Accept(IVisitor visitor)
    {
        return visitor.VisitCircle(this);
    }
}

public class Rectangle : IShape
{
    public void Move(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Draw()
    {
        throw new NotImplementedException();
    }

    public string Accept(IVisitor visitor)
    {
        return visitor.VisitRectangle(this);
    }
}

public class Triangle : IShape
{
    public void Move(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Draw()
    {
        throw new NotImplementedException();
    }

    public string Accept(IVisitor visitor)
    {
        return visitor.VisitTriangle(this);
    }
}

public interface IVisitor
{
    string VisitDot(Dot dot);
    string VisitCircle(Circle circle);
    string VisitRectangle(Rectangle rectangle);
    string VisitTriangle(Triangle triangle);
}

public class XMLExportVisitor : IVisitor
{
    public string VisitDot(Dot dot)
    {
        return "Visited the dot shape.";
    }

    public string VisitCircle(Circle circle)
    {
        return "Visited the circle shape.";
    }

    public string VisitRectangle(Rectangle rectangle)
    {
        return "Visited the rectangle shape.";
    }

    public string VisitTriangle(Triangle triangle)
    {
        return "Visited the triangle shape.";
    }
}