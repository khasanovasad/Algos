/**
 * GoF DEFINITION:
 * Ensure a class has only one instance, and provide a global point of access to it.
 *
 * CONCEPT:
 * Let’s assume that you have a class called A, and you need to create an object from it. 
 * Normally, what would you do? You could simply use this line of code: A obA=new A();
 * But let’s take a closer look. If you use the new keyword ten more times, you’ll have 
 * ten more objects, right? But in a real-world scenario, unnecessary object creation is a big 
 * concern (particularly when constructor calls are truly expensive), so you need to restrict 
 * it. In a situation like this, the Singleton pattern comes in handy. It restricts the use of new
 * and ensures that you do not have more than one instance of the class.
 * In short, this pattern says that a class should have only one instance. You can create 
 * an instance if it is not available; otherwise, you should use an existing instance to serve 
 * your needs. By following this approach, you can avoid creating unnecessary objects.
 */

using System;

namespace DesignPatterns.Creational
{
    public class Singleton
    {
        private static Singleton _instance = null;

        private Singleton() 
        {
        }

        public static Singleton Instance
        {
            get 
            {
                if (_instance is null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}