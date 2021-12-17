/**
 * GoF DEFINITION:`
 * Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher
 * level interface that makes the subsystem easier to use.
 * 
 * CONCEPT:
 * This pattern supports loose coupling. Using this pattern, you can emphasize on the 
 * abstraction and hide the complex details by exposing a simple interface.
 * Consider a simple case. Let’s say that in an application, there are multiple classes, 
 * and each of them consists of multiple methods. A client can make a product using a 
 * combination of methods from these classes, but he needs to remember which classes to 
 * pick and which methods to use with the calling sequence of these constructs. It’s okay, 
 * but it makes the client’s life difficult if there are lots of variations among these products.
 * To overcome this, the Facade pattern is useful. It offers the client a user-friendly 
 * interface because all the inner complexities are hidden. As a result, the client can simply 
 * concentrate on what he needs to. 
 */

namespace DesignPatterns.Structural;

public class Subsystem1
{
    public string Operation1()
    {
        return "Operation1 is completed.";
    }
}

public class Subsystem2
{
    public string Operation2()
    {
        return "Operation2 is completed.";
    }
}

public class Subsystem3
{
    public string Operation3()
    {
        return "Operation3 is completed.";
    }
}

public class SystemFacade
{
    private Subsystem1 _subsystem1;
    private Subsystem2 _subsystem2;
    private Subsystem3 _subsystem3;

    public SystemFacade(Subsystem1 subsystem1 = null, Subsystem2 subsystem2 = null, Subsystem3 subsystem3 = null)
    {
        _subsystem1 = subsystem1 ?? new Subsystem1(); ;
        _subsystem2 = subsystem2 ?? new Subsystem2(); ;
        _subsystem3 = subsystem3 ?? new Subsystem3(); ;
    }

    public string Operation()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("{0}\n", _subsystem1.Operation1());
        stringBuilder.AppendFormat("{0}\n", _subsystem2.Operation2());
        stringBuilder.AppendFormat("{0}\n", _subsystem3.Operation3());
        return stringBuilder.ToString();
    }
}