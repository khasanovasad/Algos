/**
 * GoF DEFINITON:
 * Attach additional responsibilities to an object dynamically. Decorators provide a flexible 
 * alternative to subclassing for extending functionality.
 *
 * CONCEPT:
 * From the GoF definition, it is evident that this pattern uses an alternative to subclassing 
 * (i.e., inheritance). If inheritance is not allowed, how do you proceed? Yes, you guessed it 
 * right. It prescribes you to use composition instead of inheritance.
 * By following the SOLID principle, this pattern promotes the concept where your 
 * class is closed for modification but open for extension. Using this pattern, you can add
 * special functionality to a specific object without altering the underlying class.
 * A decorator is just like a wrapper (or topping) that surrounds the original object 
 * and adds additional functionality to it. This is why the Decorator pattern is also called a 
 * Wrapper pattern. This pattern is most effective when you add decorators dynamically. 
 * Since decorators are often added dynamically, it’s perfectly fine if you do not want them 
 * in a later phase of development, because the original object may still work.
 */

namespace DesignPatterns.Structural;

public abstract class AbstractHouse
{
    public int AdditionalValue { get; set; }
    public abstract string MakeHouse();
}

public class ConcreteHouse : AbstractHouse
{
    public ConcreteHouse() { }

    public override string MakeHouse()
    {
        return "House is constructed. It's price is: $10,000";
    }
}

public abstract class AbstractHouseDecorator : AbstractHouse
{
    protected AbstractHouse House;

    public AbstractHouseDecorator(AbstractHouse house)
    {
        House = house;
    }

    public override string MakeHouse()
    {
        return House.MakeHouse();
    }
}

public class FloorDecorator : AbstractHouseDecorator
{
    public FloorDecorator(AbstractHouse house) : base(house)
    {
        this.AdditionalValue = 2500;
    }

    public override string MakeHouse()
    {
        var result = this.House.MakeHouse();
        result = String.Concat(result, "\n", AddFloor());
        return result;
    }

    public string AddFloor()
    {
        return $" -- Added one more floor. Pay additional {this.AdditionalValue}";
    }
}
    
public class PaintDecorator : AbstractHouseDecorator
{
    public PaintDecorator(AbstractHouse house) : base(house)
    {
        this.AdditionalValue = 1000;
    }

    public override string MakeHouse()
    {
        var result = this.House.MakeHouse();
        result = String.Concat(result, "\n", AddFloor());
        return result;
    }

    public string AddFloor()
    {
        return $"    --- Repainted the house. Pay additional {this.AdditionalValue}";
    }
}