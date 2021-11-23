/**
 * GoF DEFINITION:
 * Specify the kinds of objects to create using a prototypical instance, and create new 
 * objects by copying this prototype.
 *
 * CONCEPT:
 * The Prototype pattern provides an alternative method for instantiating new objects 
 * by copying or cloning an instance of an existing object. You can avoid the expense of 
 * creating a new instance using this concept. If you look at the intent of the pattern (the 
 * GoF definition), you see that the core idea of this pattern is to create an object that is 
 * based on another object. This existing object acts as a template for the new object.
 * When you write code for this pattern, in general, you see there is an abstract class or 
 * interface that plays the role of an abstract prototype. This abstract prototype contains a 
 * cloning method that is implemented by concrete prototypes. A client can create a new 
 * object by asking a prototype to clone itself.
 */

using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational
{
    public class SourceFile
    {
        public int LinesOfCode => Content.Count;

        public List<string> Content { get; set; }

        public SourceFile()
        {
            Content = new List<string>();
        }

        // Shallow Copy.
        // Deep Copy can also be implemented.
        public SourceFile Clone()
        {
            return this.MemberwiseClone() as SourceFile;
        }
    }
}