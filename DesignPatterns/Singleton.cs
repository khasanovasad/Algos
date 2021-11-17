using System;

namespace DesignPatterns
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