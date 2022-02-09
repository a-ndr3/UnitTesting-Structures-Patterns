using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Creational
{
    /// <summary>
    /// Ver 1
    /// </summary>
    public sealed class Singleton
    {
        private static readonly Singleton inst = new Singleton();

        static Singleton()
        {

        }

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get { return inst; }
        }
    }


    /// <summary>
    /// Ver 2
    /// </summary>
    public sealed class Singleton1
    {
        public static readonly Singleton1 inst = new Singleton1();

        static Singleton1()
        {

        }
    }



    /// <summary>
    /// Ver 3 able to call other static methods without triggering initialization of singleton
    /// </summary>
    public sealed class Singleton3
    {
        private static Singleton3 inst = null;
        private static readonly object locker = new object();

        Singleton3()
        {

        }

        public static Singleton3 Instance
        {
            get
            {
                lock (locker)
                {
                    if (inst == null)
                    {
                        inst = new Singleton3();
                    }
                    return inst;
                }
            }
        }
    }
}
