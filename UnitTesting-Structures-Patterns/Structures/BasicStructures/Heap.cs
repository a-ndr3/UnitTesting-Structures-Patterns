using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;
using UnitTesting_Structures_Patterns.Structures.TreeBased;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    /// <summary>
    /// Heap data structure is a complete binary tree that satisfies the heap property(min or max) aka any 
    /// given node is always greater/smaller than its child node and the key root node is the larges/smallest
    /// Values are removed on the basis of priority not because of FIFO rule.
    /// It can be implemented using an array, linked list, heap, binary tree.
    /// This one is based on heap because it's more efficient.
    /// Time for insert: o(1) to logN depend on the height
    /// </summary>
    public class Heap<T> : ICustomCollection<T> where T : IComparable
    {
        public Node root;
        public class Node
        {
            public T data;
            public Node left, right;
            public Node(T data)
            {
                this.data = data;
                left = right = default;
            }
            public Node()
            {
                this.data = default;
                left = right = default;
            }

            /// <summary>
            /// Inserts element into Heap. Requires Heapify after inserting to get a heap.
            /// </summary>
            /// <param name="root"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            internal static Node Insert(Node root, T data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return root;
                }
                if (data.CompareTo(root.data) == 1)
                {
                    root.right = Insert(root.right, data);
                }
                if (data.CompareTo(root.data) == -1)
                {
                    root.left = Insert(root.left, data);
                }
                if (data.CompareTo(root.data) == 0)
                {
                    root.left = Insert(root.left, data);
                }

                return root;
            }

            internal static Node<T> Heapify(Node root)
            {
                var list = new List<T>();

                TraverseInOrderArray(root, list);

                CompleteBinaryTree<T> cbt = new CompleteBinaryTree<T>(list);

                return cbt.root;
            }

            private static void TraverseInOrderArray(Node root, List<T> temp)
            {
                if (root != null)
                {
                    TraverseInOrderArray(root.left, temp);
                    temp.Add(root.data);
                    TraverseInOrderArray(root.right, temp);

                }
            }

        }

        public Heap()
        {
            root = null;
        }

        /// <summary>
        /// Returns the root of the created heap(min)
        /// </summary>
        /// <returns></returns>
        public Node<T> GetHeap()
        {
            return Node.Heapify(this.root);
        }

        public void Add(T data)
        {
            root = Node.Insert(root, data);
        }

        private Node Remove(Node root, T value)
        {
            if (root == null)
            {
                return root;
            }
            if (value.CompareTo(root.data) == 1)
            {
                Remove(root.right, value);
            }
            if (value.CompareTo(root.data) == -1)
            {
                Remove(root.left, value);
            }
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.data = MinValue(root.right);
                root.right = Remove(root.right, root.data);
            }
            return default;
        }

        private T MinValue(Node root)
        {
            var min = root.data;

            while (root.left != null)
            {
                min = root.left.data;
                root = root.left;
            }

            return min;
        }

        public void Delete(T value)
        {
            Remove(this.root, value);
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

    public class MyHeap : IEnumerable
    {
        int size = 0; //size of the heap

        int capacity = 10;  //array capacity
        int[] arr;

        public MyHeap()
        {
            arr = new int[capacity];
        }

        int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < size;
        }
        bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < size;
        }
        bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        int LeftChild(int index)
        {
            return arr[GetLeftChildIndex(index)];
        }
        int RightChild(int index)
        {
            return arr[GetRightChildIndex(index)];
        }
        int Parent(int index)
        {
            return arr[GetParentIndex(index)];
        }

        void Swap(int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        void AddCapacityToArray()
        {
            if (size == capacity)
            {
                capacity = capacity * 2;
                Array.Resize(ref arr, capacity);
            }
        }

        void CheckSize()
        {
            if (size == 0)
            {
                throw new Exception();
            }
        }

        public int GetRoot()
        {
            CheckSize();
            return arr[0];
        }

        /// <summary>
        /// Extract min element
        /// </summary>
        /// <returns></returns>
        public int Poll()
        {
            CheckSize();
            int item = arr[0];
            arr[0] = arr[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        /// <summary>
        /// Heapify method for MinHeap
        /// </summary>
        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (arr[index] < arr[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }

        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="item"></param>
        public void Add(int item)
        {
            AddCapacityToArray();
            arr[size] = item;
            size++;
            HeapifyUp();
        }

        /// <summary>
        /// Heapify method for MinHeap
        /// </summary>
        private void HeapifyUp()
        {
            int index = size - 1;

            while (HasParent(index) && Parent(index) > arr[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

