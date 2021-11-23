using System;
using System.Collections.Generic;

namespace DesignPatterns
{
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
}