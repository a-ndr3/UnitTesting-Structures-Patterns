using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    /// <summary>
    /// It is a special type of self-balancing search tree in which each node can contain more than one key and can have
    /// more than two children. aka Generalized form of BST.  aka M-way search tree with some rules for creation.
    /// STILL DOESNT WORK PROPERLY
    /// </summary>
    public class BTree<T> : ICustomCollection<T> where T : IComparable<T>
    {
        private BNode root;
        private int Tt;

        public class BNode
        {
            public bool isLeaf;
            public int amountOfChildrenInEachNode;
            public T[] key;
            public BNode[] child;

            public BNode(int t)
            {
                key = new T[2 * t - 1];
                child = new BNode[2 / t];
            }

            public BNode(T data)
            {

            }

            public BNode()
            {

            }

            public int Find(T k)
            {
                for (int i = 0; i < this.amountOfChildrenInEachNode; i++)
                {
                    if (this.key[i].Equals(k))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public BTree(int t)
        {
            Tt = t;
            root = new BNode(Tt);
            root.amountOfChildrenInEachNode = 0;
            root.isLeaf = true;
        }

        private BNode Search(BNode x, T key)
        {
            int i = 0;
            if (x == null)
            {
                return x;
            }
            for (i = 0; i < x.amountOfChildrenInEachNode; i++)
            {
                if (key.CompareTo(x.key[i]) == -1)
                {
                    break;
                }
                if (key.CompareTo(x.key[i]) == 0)
                {
                    return x;
                }
            }
            if (x.isLeaf)
            {
                return null;
            }
            else
            {
                return Search(x.child[i], key);
            }
        }

        private void SplitTheNode(BNode x, BNode y, int pos)
        {
            BNode node = new BNode(Tt);
            node.isLeaf = y.isLeaf;
            node.amountOfChildrenInEachNode = Tt - 1;

            for (int i = 0; i < Tt - 1; i++)
            {
                node.key[i] = y.key[i + Tt];
            }

            if (!y.isLeaf)
            {
                for (int i = 0; i < Tt; i++)
                {
                    node.child[i] = y.child[i + Tt];
                }
            }
            y.amountOfChildrenInEachNode = Tt - 1;
            for (int i = x.amountOfChildrenInEachNode; i >= pos + 1; i--)
            {
                x.child[i + 1] = x.child[i];
            }
            x.child[pos + 1] = node;

            for (int i = x.amountOfChildrenInEachNode; i >= pos; i--)
            {
                x.key[i + 1] = x.key[i];
            }
            x.key[pos] = y.key[Tt - 1];
            x.amountOfChildrenInEachNode++;
        }

        public void Insert(T key)
        {
            BNode node = root;
            if (node.amountOfChildrenInEachNode == 2 * Tt - 1)
            {
                BNode fresh = new BNode(Tt);
                root = fresh;
                fresh.isLeaf = false;
                fresh.amountOfChildrenInEachNode = 0;
                fresh.child[0] = node;
                SplitTheNode(fresh, node, 0);
                InsertValue(fresh, key);
            }
            else
            {
                InsertValue(node, key);
            }
        }

        private void InsertValue(BNode x, T key)
        {
            if (x.isLeaf)
            {
                int i = 0;
                for (i = x.amountOfChildrenInEachNode - 1; i >= 0 && key.CompareTo(x.key[i]) == -1; i--)
                {
                    x.key[i + 1] = x.key[i];
                }
                x.key[i + 1] = key;
                x.amountOfChildrenInEachNode++;
            }
            else
            {
                int i = 0;
                for (i = x.amountOfChildrenInEachNode - 1; i >= 0 && key.CompareTo(x.key[i]) == -1; i--)
                {

                }
                i++;
                BNode temp = x.child[i];
                if (temp.amountOfChildrenInEachNode == 2 * Tt - 1)
                {
                    SplitTheNode(x, temp, i);
                    if (key.CompareTo(x.key[i]) == 1)
                    {
                        i++;
                    }
                }
                InsertValue(x.child[i], key);
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
