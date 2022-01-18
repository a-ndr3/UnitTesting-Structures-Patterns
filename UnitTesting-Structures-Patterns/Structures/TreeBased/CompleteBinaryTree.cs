using System;
using System.Collections;
using System.Collections.Generic;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    public class Node<T> : IEnumerable<T> where T : IComparable
    {
        public T data;
        public Node<T> left, right;

        public Node(T item)
        {
            data = item;
            left = right = default;
        }

        public Node(List<T> values) : this(values, 0) { }

        Node(List<T> values, int index)
        {
            Load(this, values, index);
        }

        void Load(Node<T> node, List<T> values, int index)
        {
            node.data = values[index];
            if (index * 2 + 1 < values.Count)
            {
                node.left = new Node<T>(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Count)
            {
                node.right = new Node<T>(values, index * 2 + 2);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (left != null)
            {
                foreach (var v in left)
                {
                    yield return v;
                }
            }
            yield return data;

            if (right != null)
            {
                foreach (var v in right)
                {
                    yield return v;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// It's a binary tree in which all levels are completely filled, except the lowest or the lowest filled from the left.
    /// Differs from full binary tree: all the leaf elements lean towards left.
    /// The last leaf element might not have right sibling.
    /// height is logN
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompleteBinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> root;

        public CompleteBinaryTree()
        {
            root = null;
        }

        public CompleteBinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public CompleteBinaryTree(List<T> list)
        {
            root = new Node<T>(list);
        }

        public List<T> GetListOfElements(CompleteBinaryTree<T> tree)
        {
            List<T> list = new List<T>();
            foreach (var item in tree)
            {
                list.Add(item);
            }

            return list;
        }


        public int CountNumNodes(Node<T> root)
        {
            if (root == default)
            {
                return 0;
            }
            return (CountNumNodes(root.left) + CountNumNodes(root.right) + 1);
        }

        public bool CheckIfCompleteBinaryTree(Node<T> root, int index, int numberNodes)
        {
            if (root == default)
            {
                return true;
            }
            if (index >= numberNodes)
                return false;
            return (CheckIfCompleteBinaryTree(root.left, 2 * index + 1, numberNodes) && CheckIfCompleteBinaryTree(root.right, 2 * index + 2, numberNodes));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var n in root)
            {
                yield return n;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


