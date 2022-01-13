using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    public class Node<T> : IEnumerable<T> where T:IComparable
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

        }

        public CompleteBinaryTree(List<T> list)
        {
            root = new Node<T>(list);
        }

        //public bool Compare<T>(T x, T y)
        //{
        //    return EqualityComparer<T>.Default.Equals(x, y);
        //}

        //public Node<T> DeleteNode(Node<T> currentNode, T data)
        //{
        //    if (this.root != null)
        //    {
        //        if (Compare(currentNode.data,data))
        //        {
        //            if (currentNode.left == null && currentNode.right == null)
        //            {
        //                return null;
        //            }

        //            if (currentNode.left == null)
        //            {
        //                return currentNode.right;
        //            }

        //            if (currentNode.right == null)
        //            {
        //                return currentNode.left;
        //            }
        //        }
        //    }
        //}

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



//List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
//CompleteBinaryTree<int> tree = new CompleteBinaryTree<int>();
////CompleteBinaryTree<int> tree = new CompleteBinaryTree<int>(list);

//tree.root = new Node<int>(1);
//tree.root.left = new Node<int>(2);
////tree.root.right = new Node<int>(3);
////tree.root.left.left = new Node<int>(4);
////tree.root.left.right = new Node<int>(6);
////tree.root.right.right = new Node<int>(5);
////tree.root.right.left = new Node<int>(7);

//var num = tree.CountNumNodes(tree.root);
//var check = tree.CheckIfCompleteBinaryTree(tree.root, 0, num);

//foreach (var n in tree)
//{
//    Console.WriteLine(n);
//}