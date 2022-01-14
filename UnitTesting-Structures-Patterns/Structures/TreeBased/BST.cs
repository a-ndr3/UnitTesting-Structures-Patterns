using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    public class BST<T> : ICustomCollection<T> where T : IComparable
    {

        public class Node
        {
            public T key;
            public Node left, right;

            public Node(T data)
            {
                key = data;
                left = right = default;
            }

            internal static Node InsertKey(Node root, T key)
            {
                if (root == null)
                {
                    root = new Node(key);
                    return root;
                }

                if (key.CompareTo(root.key) < 0)
                {
                    root.left = InsertKey(root.left, key);
                }
                else
                {
                    if (key.CompareTo(root.key) > 0)
                        root.right = InsertKey(root.right, key);
                }
                return root;
            }
        }

        public Node root;

        public BST()
        {
            root = null;
        }

        /// <summary>
        /// root - left sub - right sub
        /// </summary>
        public void TraversePreOrder(Node root)
        {

            if (root != null)
            {
                Console.WriteLine(root.key + " ");
                TraversePreOrder(root.left);
                TraversePreOrder(root.right);
            }
        }

        /// <summary>
        /// left sub - right sub - root
        /// </summary>
        public void TraversePostOrder(Node root)
        {
            if (root != null)
            {
                TraversePostOrder(root.left);
                TraversePostOrder(root.right);
                Console.WriteLine(root.key + " ");
            }
        }

        /// <summary>
        /// left sub - root - right sub
        /// </summary>
        public void TraverseInOrder(Node root)
        {
            if (root != null)
            {
                TraverseInOrder(root.left);
                Console.WriteLine(root.key + " ");
                TraverseInOrder(root.right);
            }
        }

        public List<T> TraverseInOrderArray()
        {
            List<T> temp = new List<T>();
            TraverseInOrderArray(this.root, temp);
            return temp;
        }

        private void TraverseInOrderArray(Node root, List<T> temp)
        {

            if (root != null)
            {
                TraverseInOrderArray(root.left, temp);
                temp.Add(root.key);
                TraverseInOrderArray(root.right, temp);

            }
        }

        public IEnumerable<T> TraverseInOrderArrayEnum()
        {
            return TraverseInOrderArrayEnum(this.root);
        }

        private IEnumerable<T> TraverseInOrderArrayEnum(Node root)
        {
            if (root != null)
            {
                var a = TraverseInOrderArrayEnum(root.left);
                foreach (var i in a)
                    yield return i;

                yield return root.key;

                var b = TraverseInOrderArrayEnum(root.right);
                foreach (var j in b)
                    yield return j;
            }
        }

        public int GetTreeDepth()
        {
            return GetTreeDepth(root);
        }
        private int GetTreeDepth(Node root)
        {
            return root == null ? 0 : Math.Max(GetTreeDepth(root.left), GetTreeDepth(root.right)) + 1;
        }

        public Node Find(T value)
        {
            return this.Find(value, this.root);
        }

        private Node Find(T value, Node parent)
        {
            if (root != null)
            {
                if (value.CompareTo(root.key) == 0) return root;
                if (value.CompareTo(root.key) < 0) return Find(value, root.left);
                else
                {
                    return Find(value, root.right);
                }

            }
            return null;
        }


        public void Insert(T key)
        {
            root = Node.InsertKey(root, key);
        }

        public void Add(T data)
        {
            Insert(data);
        }

        public void Remove(T value)
        {
            this.root = Remove(this.root, value);
        }

        private Node Remove(Node root, T key)
        {
            if (root == null) return root;

            if (key.CompareTo(root.key) < 0)
            {
                root.left = Remove(root.left, key);

            }
            else if (key.CompareTo(root.key) > 0)
            {
                root.right = Remove(root.right, key);
            }
            else //value == root.value thus to delete
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.key = MinValue(root.right);
                root.right = Remove(root.right, root.key);
            }
            return root;
        }

        private T MinValue(Node root)
        {
            T min = root.key;

            while (root.left != null)
            {
                min = root.left.key;
                root = root.left;
            }

            return min;
        }


        public T Delete(T key)
        {
            Remove(key);
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T Delete()
        {
            throw new NotImplementedException();
        }
    }
}
