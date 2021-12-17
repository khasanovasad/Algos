/**
 * GoF DEFINITION:
 * The Simple Factory pattern creates an object without exposing the instantiation logic to 
 * the client.
 * 
 * CONCEPT:
 * In object-oriented programming (OOP), a factory is such an object that can create other 
 * objects. A factory can be invoked in many ways, but most often, it uses a method that 
 * can return objects with varying prototypes. Any subroutine that helps create these new 
 * objects is considered a factory. Most importantly, it helps you abstract the process of 
 * object creation from the consumers of the application.
 */

using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational;

public interface IButton
{
    string Click();
}

public class AndroidButton : IButton
{
    public string Click()
    {
        return "Android button is clicked.";
    }
}

public class iOSButton : IButton
{
    public string Click()
    {
        return "iOS button is clicked.";
    }
}

public class SimpleFactory
{
    public IButton CreateButton(string buttonType)
    {
        IButton intendedButton = null;

        switch (buttonType)
        {
            case "android":
                intendedButton = new AndroidButton();
                break;
            case "ios":
                intendedButton = new iOSButton();
                break;
            default:
                throw new ArgumentException($"Unrecognized button type: {buttonType}.");
        }
        return intendedButton;
    }
}