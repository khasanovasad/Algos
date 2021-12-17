/**
 * GoF DEFINITION:
 * Convert the interface of a class into another interface client’s expect. Adapter lets classes 
 * work together that otherwise could not because of incompatible interfaces.
 * 
 * CONCEPT:
 * From the GoF definition, you can guess that this pattern deals with at least two 
 * incompatible inheritance hierarchies. In a domain-specific system, the clients are 
 * habituated on how to invoke methods in software. Those methods can follow an 
 * inheritance hierarchy. Now assume that you need to upgrade your system and need to 
 * implement a new inheritance hierarchy. When you do that, you do not want to force your 
 * clients to learn the new way to access the software. So, what can you do? The solution is 
 * simple: you write an adapter that accepts client requests and translates these requests 
 * in a form that the methods in the new hierarchy can understand. As a result, clients can 
 * enjoy the updated software without any hassle.
 */

using System;

namespace DesignPatterns.Structural;

public interface IRectangle
{
    public double CalculateArea();
    public string AboutMe();
}
    
public class Rectangle : IRectangle
{
    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double Length { get; set; }
    public double Width { get; set; }
        
    public double CalculateArea()
    {
        return Width * Length;
    }

    public string AboutMe()
    {
        return "Actually, this is a rectangle.";
    }
}
    
public interface ITriangle
{
    public double CalculateAreaOfTriangle();
    public string AboutThisTriangle();
}
    
public class Triangle : ITriangle
{
    public Triangle(double height, double baseLength)
    {
        Height = height;
        BaseLength = baseLength;
    }

    public double Height { get; set; }
    public double BaseLength { get; set; }
        
    public double CalculateAreaOfTriangle()
    {
        return 0.5 * Height * BaseLength;
    }

    public string AboutThisTriangle()
    {
        return "Actually, this is a triangle.";
    }
}

public class RectangleAdapter : IRectangle
{
    private ITriangle _triangle;

    public RectangleAdapter(ITriangle triangle)
    {
        _triangle = triangle;
    }
        
    public double CalculateArea()
    {
        return _triangle.CalculateAreaOfTriangle();
    }

    public string AboutMe()
    {
        return _triangle.AboutThisTriangle();
    }
}