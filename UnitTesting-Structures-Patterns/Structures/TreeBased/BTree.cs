using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    /// <summary>
    /// It is a special type of self-balancing search tree in which each node can contain more than one key and can have
    /// more than two children. aka Generalized form of BST.  aka M-way search tree with some rules for creation.
    /// </summary>
    public class BTree<T> : ICustomCollection<T> where T : IComparable<T>
    {
        public class BNode
        {
            public bool isLeaf;


            public BNode()
            {

            }

            public BNode(T data)
            {

            }
        }


        public void Add(T data)
        {
            throw new NotImplementedException();
        }

        public T Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

       
    }
}
