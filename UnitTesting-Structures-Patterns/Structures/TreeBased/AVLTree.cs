using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    /// <summary>
    /// AVL Tree is a self-balancing binary search tree in which each node maintains extra information which is a balance factor with a value from the range [-1;0;1].
    /// Balance factor of a node is the difference between the height of the left subtree and the right subtree of the node.
    /// Balance factor = (Height of left subtree - Height of right subtree) or the opposite.
    /// </summary>
    public class AVLTree<T> : ICustomCollection<T> where T : IComparable
    {
        public AVLNode root;
        public class AVLNode
        {
            public T key;
            public AVLNode left, right;
            public int depth;


            public AVLNode()
            {
                key = default;
                left = right = default;
                depth = 0;
            }

            public AVLNode(T value)
            {
                key = value;
                left = right = default;
                depth = 1;
            }
        }

        public int GetMax(int a, int b)
        {
            return (a > b) ? a : b;
        }

        private int GetDepth(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.depth;
        }

        private AVLNode RotateRight(AVLNode y)
        {
            var x = y.left;
            var node = x.right;

            //rotation
            x.right = y;
            y.left = node;

            //upd heights

            x.depth = GetMax(GetDepth(x.left), GetDepth(x.right)) + 1;
            y.depth = GetMax(GetDepth(y.left), GetDepth(y.right)) + 1;

            return x;
        }


        private AVLNode RotateLeft(AVLNode x)
        {
            var y = x.right;
            var node = y.left;

            //rotation
            y.left = x;
            x.right = node;

            //upd heights

            x.depth = GetMax(GetDepth(x.left), GetDepth(x.right)) + 1;
            y.depth = GetMax(GetDepth(y.left), GetDepth(y.right)) + 1;

            return y;
        }

        private int GetBalance(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetDepth(node.left) - GetDepth(node.right);
        }

        public AVLTree()
        {
            root = null;
        }

        private AVLNode Insert(AVLNode node, T value)
        {
            if (node == null)
            {
                return new AVLNode(value);
            }
            if (value.CompareTo(node.key) == -1)
            {
                node.left = Insert(node.left, value);
            }
            else if (value.CompareTo(node.key) == 1)
            {
                node.right = Insert(node.right, value);
            }
            else
            {
                return node;
            }

            //update height of ancestor node
            node.depth = GetMax(GetDepth(node.left), GetDepth(node.right)) + 1;

            var balance = GetBalance(node);

            //left left

            if (balance > 1 && value.CompareTo(node.left.key) == -1) return RotateRight(node);

            //left right

            if (balance > 1 && value.CompareTo(node.left.key) == 1)
            {
                node.left = RotateLeft(node.left);
                return RotateRight(node);
            }

            //right right

            if (balance < -1 && value.CompareTo(node.right.key) == 1) return RotateLeft(node);

            //right left

            if (balance < -1 && value.CompareTo(node.right.key) == -1)
            {
                node.right = RotateRight(node.right);
                return RotateLeft(node);
            }

            return node;

        }

        private AVLNode Delete(AVLNode node, T value)
        {
            if (node == null)
            {
                return node;
            }

            if (value.CompareTo(node.key) == -1)
            {
                node.left = Delete(node.left, value);
            }
            else if (value.CompareTo(node.key) == 1)
            {
                node.right = Delete(node.right, value);
            }

            else
            {
                if ((node.left == null) || (node.right == null))
                {
                    AVLNode temp = node.left != null ? node.left : node.right;
                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    var temp = GetMinValueNode(node.right);
                    node.key = temp.key;
                    node.right = Delete(node.right, temp.key);
                }
            }

            if (node == null)
            {
                return node;
            }

            //update height of ancestor node
            node.depth = GetMax(GetDepth(node.left), GetDepth(node.right)) + 1;

            var balance = GetBalance(node);

            //left left
            if (balance > 1 && GetBalance(node.left) >= 0)
                return RotateRight(node);

            //left right
            if (balance > 1 && GetBalance(node.left) < 0)
            {
                node.left = RotateLeft(node.left);
                return RotateRight(node);
            }

            //right right
            if (balance < -1 && GetBalance(node.right) <= 0)
                return RotateLeft(node);

            //right left
            if (balance < -1 && GetBalance(node.right) > 0)
            {
                node.right = RotateRight(node.right);
                return RotateLeft(node);
            }

            return node;

        }

        private AVLNode GetMinValueNode(AVLNode node)
        {
            var current = node;

            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }

        public void Add(T data)
        {
            root = Insert(this.root, data);
        }

        public void Delete(T value)
        {
            root = Delete(this.root, value);
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
