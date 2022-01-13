using System;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Structures.BasicStructures;
using UnitTesting_Structures_Patterns.Structures.TreeBased;

namespace UnitTesting_Structures_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new MyHeap();

            heap.Add(1);
            heap.Add(2);
            heap.Add(6);
            heap.Add(8);
            heap.Add(7);
            heap.Add(8);
            heap.Add(9);

            heap.Poll();
            foreach(var n in heap)
            {
                Console.WriteLine(n);
            }
        }
    }
}
