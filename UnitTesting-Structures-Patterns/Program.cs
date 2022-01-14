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
            var bst = new BST<int>();

            bst.Add(1);
            bst.Add(7);
            bst.Add(32);
            bst.Add(3);
            bst.Add(66);
            bst.Add(5);

            bst.TraversePreOrder(bst.root);
            bst.TraverseInOrder(bst.root);
            bst.TraversePostOrder(bst.root);

            bst.Remove(234);

            bst.TraverseInOrder(bst.root);
            bst.Remove(5);

            bst.TraverseInOrder(bst.root);

        }
    }
}
