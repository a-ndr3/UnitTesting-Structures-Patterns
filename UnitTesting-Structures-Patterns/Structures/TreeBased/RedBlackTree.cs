using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.TreeBased
{
    /// <summary>
    /// Difference between AVL and RB is that in AVL we need to do many rotations to balance it whereas to get RB balanced we need to do max 2 rotations + recoloring.
    /// AVL is strictly height balanced compared to RB.
    /// Nonetheless, RB guaratees logN as well.
    /// Insertion & deletion are faster in RB, searching is faster in AVL.
    /// EXAMPLE CODE
    /// </summary>
    public class RedBlackTree<T> : ICustomCollection<T> where T : IComparable
    {
        RBNode root;
        RBNode TNULL;

        public enum RBcolor : byte
        {
            Red = 1,
            Black = 0
        }

        public class RBNode
        {
            public RBcolor color;
            public T data;
            public RBNode left, right;
            public RBNode parent;

            public RBNode()
            {

            }
        }

        public RedBlackTree()
        {
            TNULL = new RBNode();
            TNULL.color = RBcolor.Black;
            TNULL.left = TNULL.right = null;
            this.root = TNULL;
        }


        private void RotateRight(RBNode x)
        {
            var y = x.left;
            x.left = y.right;

            if (y.right != TNULL)
            {
                y.right.parent = x;
            }

            y.parent = x.parent;
            if (x.parent == null)
            {
                this.root = y;
            }
            else if (x == x.parent.right)
            {
                x.parent.right = y;
            }
            else
            {
                x.parent.left = y;
            }
            y.right = x;
            x.parent = y;
        }


        private void RotateLeft(RBNode x)
        {
            var y = x.right;
            x.right = y.left;

            if (y.left != TNULL)
            {
                y.left.parent = x;
            }
            y.parent = x.parent;

            if (x.parent == null)
            {
                this.root = y;
            }
            else if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }
            y.left = x;
            x.parent = y;
        }


        private void GetTreeBalanced(RBNode node)
        {
            RBNode node1;
            while (node.parent.color == RBcolor.Red)
            {
                if (node.parent == node.parent.parent.right)
                {
                    node1 = node.parent.parent.left;
                    if (node1.color == RBcolor.Red)
                    {
                        node1.color = 0;
                        node.parent.color = 0;
                        node.parent.parent.color = RBcolor.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.left)
                        {
                            node = node.parent;
                            RotateRight(node);
                        }
                        node.parent.color = 0;
                        node.parent.parent.color = RBcolor.Red;
                        RotateLeft(node.parent.parent);
                    }
                }
                else
                {
                    node1 = node.parent.parent.right;

                    if (node1 != null && node1.color == RBcolor.Red)
                    {
                        node1.color = 0;
                        node.parent.color = 0;
                        node.parent.parent.color = RBcolor.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.right)
                        {
                            node = node.parent;
                            RotateLeft(node);
                        }
                        node.parent.color = 0;
                        node.parent.parent.color = RBcolor.Red;
                        RotateRight(node.parent.parent);
                    }
                }
                if (node == root)
                {
                    break;
                }
            }
            root.color = 0;
        }

        public RBNode GetRoot()
        {
            return this.root;
        }

        public void Delete(T value)
        {
            Delete(this.root, value);
        }

        private void Delete(RBNode node, T value)
        {
            RBNode z = TNULL;
            RBNode x, y;

            while (node != TNULL)
            {
                if (node.data.CompareTo(value) == 0)
                {
                    z = node;
                }

                if (node.data.CompareTo(value) == -1 || node.data.CompareTo(value) == 0)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }

            if (z == TNULL)
            {
                return;
            }

            y = z;
            var yOriginalColor = y.color;

            if (z.left == TNULL)
            {
                x = z.right;
                Transpos(z, z.right);
            }
            else if (z.right == TNULL)
            {
                x = z.left;
                Transpos(z, z.left);
            }
            else
            {
                y = GetMinimum(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if (y.parent == z)
                {
                    x.parent = y;
                }
                else
                {
                    Transpos(y, y.right);
                    y.right = z.right;
                    y.right.parent = y;
                }

                Transpos(z, y);
                y.left = z.left;
                y.left.parent = y;
                y.color = z.color;
            }
            if (yOriginalColor == 0)
            {
                GetTreeFixedAfterDelete(x);
            }
        }

        private void GetTreeFixedAfterDelete(RBNode x)
        {
            RBNode s;
            while (x != root && x.color == 0)
            {
                if (x == x.parent.left)
                {
                    s = x.parent.right;
                    if (s.color == RBcolor.Red)
                    {
                        s.color = 0;
                        x.parent.color = RBcolor.Red;
                        RotateLeft(x.parent);
                        s = x.parent.right;
                    }

                    if (s.left.color == 0 && s.right.color == 0)
                    {
                        s.color = RBcolor.Red;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.right.color == 0)
                        {
                            s.left.color = 0;
                            s.color = RBcolor.Red;
                            RotateRight(s);
                            s = x.parent.right;
                        }

                        s.color = x.parent.color;
                        x.parent.color = 0;
                        s.right.color = 0;
                        RotateLeft(x.parent);
                        x = root;
                    }
                }
                else
                {
                    s = x.parent.left;
                    if (s.color == RBcolor.Red)
                    {
                        s.color = 0;
                        x.parent.color = RBcolor.Red;
                        RotateRight(x.parent);
                        s = x.parent.left;
                    }

                    if (s.right.color == 0 && s.right.color == 0)
                    {
                        s.color = RBcolor.Red;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.left.color == 0)
                        {
                            s.right.color = 0;
                            s.color = RBcolor.Red;
                            RotateLeft(s);
                            s = x.parent.left;
                        }

                        s.color = x.parent.color;
                        x.parent.color = 0;
                        s.left.color = 0;
                        RotateRight(x.parent);
                        x = root;
                    }
                }
            }
            x.color = 0;
        }

        private void Transpos(RBNode u, RBNode v)
        {
            if (u.parent == null)
            {
                root = v;
            }
            else if (u == u.parent.left)
            {
                u.parent.left = v;
            }
            else
            {
                u.parent.right = v;
            }
            v.parent = u.parent;
        }

        public RBNode Search(T value)
        {
            return FindValueInTheTree(this.root, value);
        }

        private RBNode FindValueInTheTree(RBNode node, T value)
        {
            if (node == TNULL || value.CompareTo(node.data) == 0)
            {
                return node;
            }

            if (value.CompareTo(node.data) == -1)
            {
                return FindValueInTheTree(node.left, value);
            }
            return FindValueInTheTree(node.right, value);
        }

        public RBNode GetMinimum(RBNode node)
        {
            while (node.left != TNULL)
            {
                node = node.left;
            }
            return node;
        }

        public RBNode GetMaximum(RBNode node)
        {
            while (node.right != TNULL)
            {
                node = node.right;
            }
            return node;
        }

        public RBNode GetSuccessor(RBNode node)
        {
            if (node.right != TNULL)
            {
                return GetMinimum(node.right);
            }
            var node2 = node.parent;
            while (node2 != TNULL && node == node2.right)
            {
                node = node2;
                node2 = node2.parent;
            }
            return node2;
        }

        public RBNode GetPredecessor(RBNode node)
        {
            if (node.left != TNULL)
            {
                return GetMaximum(node.left);
            }
            var node2 = node.parent;
            while (node2 != TNULL && node == node2.left)
            {
                node = node2;
                node2 = node2.parent;
            }
            return node2;
        }

        public void Insert(T data)
        {
            var node = new RBNode();
            node.parent = null;
            node.data = data;
            node.left = node.right = TNULL;
            node.color = RBcolor.Red;

            node.left = node.right = TNULL;

            RBNode y = null;
            var x = this.root;

            while (x != TNULL)
            {
                y = x;
                if (node.data.CompareTo(x.data) == -1)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }

            node.parent = y;
            if (y == null)
            {
                root = node;
            }
            else if (node.data.CompareTo(y.data) == -1)
            {
                y.left = node;
            }
            else
            {
                y.right = node;
            }

            if (node.parent == null)
            {
                node.color = RBcolor.Black;
                return;
            }

            if (node.parent.parent == null)
            {
                return;
            }

            GetTreeBalanced(node);
        }

        public IEnumerable<T> InOrder()
        {
            return TraverseInOrder(this.root);
        }

        private IEnumerable<T> TraversePreOrder(RBNode root)
        {
            if (root != null)
            {
                yield return root.data;
                var a = TraversePreOrder(root.left);
                foreach (var i in a)
                    yield return i;

                var b = TraversePreOrder(root.right);
                foreach (var j in b)
                    yield return j;
            }
        }

        private IEnumerable<T> TraversePostOrder(RBNode root)
        {
            if (root != null)
            {
                var a = TraversePostOrder(root.left);
                foreach (var i in a)
                    yield return i;

                var b = TraversePostOrder(root.right);
                foreach (var j in b)
                    yield return j;

                yield return root.data;
            }
        }

        private IEnumerable<T> TraverseInOrder(RBNode root)
        {
            if (root != null)
            {
                var a = TraverseInOrder(root.left);
                foreach (var i in a)
                    yield return i;

                yield return root.data;

                var b = TraverseInOrder(root.right);
                foreach (var j in b)
                    yield return j;
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
