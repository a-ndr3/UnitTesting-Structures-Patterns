using System;
using System.Collections;

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
    public class Heap<T> where T : IComparable
    {

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

