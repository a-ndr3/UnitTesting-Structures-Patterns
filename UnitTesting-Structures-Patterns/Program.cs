using System;

namespace UnitTesting_Structures_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Structures.BasicStructures.CircularQueue<int> st1 = new Structures.BasicStructures.CircularQueue<int>(5);
            st1.Enqueue(16);
            st1.Enqueue(10);
            st1.Enqueue(5);
            st1.Enqueue(155);
            st1.Enqueue(100);
            foreach (int s in st1)
            {
                Console.WriteLine(s + "   ");
            }
            st1.Dequeue();
            st1.Enqueue(21);
            foreach (int s in st1)
            {
                Console.WriteLine(s);
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
