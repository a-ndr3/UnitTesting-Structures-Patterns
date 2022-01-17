using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    /// <summary>
    /// Extensions for my linked list
    /// </summary>
    static class LinkedListExtensions
    {
        public static IEnumerable<T> GetData<T>(this LinkedList<T>.Node node) where T : IComparable
        {
            yield return node.value;

            if (node.next != null)
            {
                foreach (var item in GetData(node.next))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<int> GetData(this LinkedList<int>.Node node)
        {
            yield return node.value;

            if (node.next != null)
            {
                foreach (var item in GetData(node.next))
                {
                    yield return item;
                }
            }
        }
        public static int[] ToArray(this LinkedList<int> list)
        {
            int size = 100;
            int[] tempArr = new int[size];

            int i = 0;
            foreach (var a in GetData(list.root))
            {
                tempArr[i] = a;

                if (i + 1 >= size)
                {
                    Array.Resize(ref tempArr, size * 2);
                }
                i++;
            }
            return tempArr;
        }
    }
    /// <summary>
    /// Linear data structure that includes a series of connected nodes. Each node contains data and the ref to the next node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : ICustomCollection<T> where T : IComparable
    {
        public Node root;
        public class Node
        {
            public T value;
            public Node next;

            public Node(T value)
            {
                this.value = value;
                next = null;
            }
        }

        public LinkedList()
        {
            this.root = null;
        }
        public LinkedList(T value)
        {
            Add(root, value);
        }

        public LinkedList(T[] arr)
        {
            ArrayToLinkedList(arr);
        }

        private Node Add(Node previous, T value)
        {
            if (previous == null)
            {
                this.root = new Node(value);
            }
            else if (previous.next == null)
            {
                var node = new Node(value);
                previous.next = node;
                return node;
            }

            return new Node(default);
        }

        public void ArrayToLinkedList(T[] arr)
        {
            Node[] nodeArr = new Node[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (nodeArr[i] == null)
                    nodeArr[i] = new Node(arr[i]);
                else if (nodeArr[i].value.Equals(default(T)))
                {
                    nodeArr[i].value = arr[i];
                }
                if ((i + 1) <= nodeArr.Length && (nodeArr.ElementAtOrDefault(i + 1) == null))
                {
                    if ((i + 1) != nodeArr.Length)
                    {
                        nodeArr[i + 1] = new Node(default);
                        nodeArr[i].next = nodeArr[i + 1];
                    }
                }
            }

            this.root = nodeArr[0];
        }


        public void AddToTheStart(T value)
        {
            var oldroot = this.root;
            this.root = new Node(value);
            this.root.next = oldroot;
        }

        public void AddToTheEnd(T value)
        {
            Node ptr = this.root;
            while (ptr.next != null)
            {
                ptr = ptr.next;
            }
            ptr.next = new Node(value);
        }

        public void AddToTheMiddle(T value)
        {
            Node ptr1 = this.root;
            Node ptr2 = this.root;
            Node previous = this.root;

            while (ptr1.next != null)
            {
                ptr1 = ptr1.next;

                if (ptr1.next != null)
                {
                    ptr1 = ptr1.next;
                    previous = ptr2;
                    ptr2 = ptr2.next;
                }
            }

            var newNode = new Node(value);
            previous.next = newNode;
            newNode.next = ptr2;
        }


        private void SwapValuesBetweenNodes(Node ptr1, Node ptr2)
        {
            var temp = ptr1.value;
            ptr1.value = ptr2.value;
            ptr2.value = temp;
        }


        /// <summary>
        /// Sort the list
        /// </summary>
        public void Sort()
        {
            Node currentPtr = this.root;
            Node bubblePtr = null;

            while (currentPtr != null)
            {
                bubblePtr = currentPtr.next;

                while (bubblePtr != null)
                {
                    if (currentPtr.value.CompareTo(bubblePtr.value) == 1)
                    {
                        SwapValuesBetweenNodes(currentPtr, bubblePtr);
                    }
                    bubblePtr = bubblePtr.next;
                }
                currentPtr = currentPtr.next;
            }
        }

        /// <summary>
        /// Search for the specific element in the list
        /// </summary>
        /// <returns></returns>
        public bool Search(T value)
        {
            Node ptr = this.root;
            while (ptr.next != null)
            {
                if (ptr.value.Equals(value)) return true;
                else ptr = ptr.next;
            }
            return false;
        }

        /// <summary>
        /// Get middle element with a single iteration
        /// </summary>
        /// <returns></returns>
        public T GetMiddleElementOfList()
        {
            Node ptr1 = this.root;
            Node ptr2 = this.root;

            while (ptr1.next != null)
            {
                ptr1 = ptr1.next;

                if (ptr1.next != null)
                {
                    ptr1 = ptr1.next;
                    ptr2 = ptr2.next;
                }
            }

            return ptr2.value;
        }

        public void Delete(T item)
        {
            Delete(this.root, null, item);
        }
        private T Delete(Node root, Node previous, T item)
        {

            if (root.value.Equals(item))
            {
                previous.next = root.next;
                return root.value;
            }
            else
            {
                Delete(root.next, root, item);
            }

            return default(T);
        }

        /// <summary>
        /// Works in the same way as AddToTheEnd
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            AddToTheEnd(data);
        }

        public void DeleteFirst()
        {
            var newroot = this.root.next;
            this.root = newroot;
        }

        /// <summary>
        /// Delete last element from the end
        /// </summary>
        /// <returns></returns>
        public T Delete()
        {
            Node ptr = this.root;
            Node previous = this.root;

            while (ptr.next != null)
            {
                previous = ptr;
                ptr = ptr.next;
            }
            previous.next = null;
            return ptr.value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in LinkedListExtensions.GetData<T>(root))
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class DoubleLinkedList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        public Node root;
        public class Node
        {
            public T value;
            public Node next;
            public Node previous;

            public Node(T value)
            {
                this.value = value;
                next = null;
                previous = null;
            }
        }

        public DoubleLinkedList()
        {
            this.root = null;
        }
        public DoubleLinkedList(T value)
        {
            Add(value);
        }

        public void AddToTheStart(T value)
        {
            var oldroot = this.root;
            this.root = new Node(value);
            this.root.next = oldroot;
            oldroot.previous = this.root;
        }

        /// <summary>
        /// Add element to double linked list (in the "end")
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (this.root == null)
            {
                this.root = new Node(data);
            }
            else
            {
                Node ptr = this.root;
                Node prev = this.root;
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                    prev = ptr;
                }
                ptr.next = new Node(data);
                ptr.next.previous = prev;
            }
        }

        /// <summary>
        /// Delete specific element by value
        /// </summary>
        /// <param name="element"></param>
        public bool Delete(T element)
        {
            Node ptr = this.root;
            Node prev = this.root;

            while (ptr.value.CompareTo(element) != 0)
            {
                prev = ptr;
                if (ptr.next == null)
                {
                    return false;
                }
                ptr = ptr.next;
            }
            prev.next = ptr.next;
            ptr.next.previous = prev;

            return true;
        }
        /// <summary>
        /// Delete last from the end element
        /// </summary>
        /// <returns></returns>
        public T Delete()
        {
            Node ptr = this.root;
            Node prev = this.root;

            while (ptr.next != null)
            {
                prev = ptr;
                ptr = ptr.next;
            }
            prev.next = null;
            return ptr.value;
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

    public class CircularLinkedList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        public Node root;
        public class Node
        {
            public T value;
            public Node next;
            public Node previous;
            public Node ptrTofirst;

            public Node(T value)
            {
                this.value = value;
                next = null;
                previous = null;
                ptrTofirst = null;
            }
        }

        public CircularLinkedList()
        {
            this.root = null;
        }
        public CircularLinkedList(T value)
        {
            Add(value);
        }

        public void AddToTheStart(T value)
        {
            var oldroot = this.root;
            this.root = new Node(value);
            this.root.next = oldroot;
            oldroot.previous = this.root;

            Node ptr = this.root;

            while (ptr.next != null)
            {
                ptr = ptr.next;
            }
            ptr.ptrTofirst = this.root;

        }

        private bool IsLast(Node node)
        {
            if (node.next == null)
                return true;
            return false;
        }


        /// <summary>
        /// Add element to double linked list (in the "end")
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (this.root == null)
            {
                this.root = new Node(data);
            }
            else
            {
                Node ptr = this.root;
                Node prev = this.root;
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                    prev = ptr;
                }
                ptr.ptrTofirst = null;
                ptr.next = new Node(data);
                ptr.next.ptrTofirst = this.root;
                ptr.next.previous = prev;
            }
        }

        /// <summary>
        /// Delete specific element by value
        /// </summary>
        /// <param name="element"></param>
        public bool Delete(T element)
        {
            Node ptr = this.root;
            Node prev = this.root;

            while (ptr.value.CompareTo(element) != 0)
            {
                prev = ptr;
                if (ptr.next == null)
                {
                    return false;
                }
                ptr = ptr.next;
            }
            prev.next = ptr.next;
            ptr.next.previous = prev;

            if (!IsLast(ptr))
            {
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }
                ptr.ptrTofirst = this.root;
            }
            else
            {
                ptr.ptrTofirst = this.root;
            }

            return true;
        }
        /// <summary>
        /// Delete last from the end element
        /// </summary>
        /// <returns></returns>
        public T Delete()
        {
            Node ptr = this.root;
            Node prev = this.root;

            while (ptr.next != null)
            {
                prev = ptr;
                ptr = ptr.next;
            }
            prev.next = null;

            if (IsLast(prev))
            {
                prev.ptrTofirst = this.root;
            }

            return ptr.value;
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
