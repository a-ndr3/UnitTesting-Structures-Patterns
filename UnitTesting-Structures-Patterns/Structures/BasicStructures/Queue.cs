using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    /// <summary>
    /// An abstract data structure with FIFO rule
    /// </summary>
    public class Queue<T> : IEnumerable
    {
        protected T[] arr;
        protected int front; //ref to the first element
        protected int rear; //ref to the last element
        protected int capacity;

        public Queue(int size)
        {
            arr = new T[size];
            front = -1;
            rear = -1;
            capacity = size;
        }

        /// <summary>
        /// Add an element to the end
        /// </summary>
        /// <param name="element"></param>
        public virtual void Enqueue(T element)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            if (front == -1) front = 0;
            rear++;
            arr[rear] = element;
        }

        /// <summary>
        /// Get an element from the front
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            var element = arr[front];
            if (front >= rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                front++;
            }
            return element;
        }

        public virtual bool IsEmpty()
        {
            if (front == -1 && rear == -1)
            {
                return true;
            }
            return false;
        }

        public virtual bool IsFull()
        {
            if (front == 0 && rear == capacity - 1)
            {
                return true;
            }
            return false;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            return arr[front];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i <= rear; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class QueueListBased<T> : IEnumerable
    {
        List<T> arr;
        int front; //ref to the first element
        int rear; //ref to the last element
        int defaultCapacity = 10;

        public QueueListBased()
        {
            arr = new List<T>();
            front = -1;
            rear = -1;
        }

        /// <summary>
        /// Add an element to the end
        /// </summary>
        /// <param name="element"></param>
        public void Enqueue(T element)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            if (front == -1) front = 0;
            rear++;
            arr.Add(element);
        }

        /// <summary>
        /// Get an element from the front
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            var element = arr[front];
            if (front >= rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                front++;
            }
            return element;
        }

        public bool IsEmpty()
        {
            if (front == -1 && rear == -1)
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            if (front == 0 && rear == defaultCapacity - 1)
            {
                defaultCapacity += defaultCapacity;
                return false;
            }
            return false;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            return arr[front];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i <= rear; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Same as queue but we can use the free space after making dequeue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularQueue<T> : Queue<T>
    {
        public CircularQueue(int size) : base(size)
        {
            arr = new T[size];
            front = -1;
            rear = -1;
            capacity = size;
        }
        public override bool IsFull()
        {
            if (front == 0 && rear == capacity - 1)
            {
                return true;
            }
            if (front == rear + 1)
            {
                return true;
            }
            return false;
        }

        public override T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            else
            {
                var element = arr[front];
                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % capacity;
                }
                return element;
            }
        }

        public override void Enqueue(T element)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            else
            {
                if (front == -1)
                    front = 0;
                rear = (rear + 1) % capacity;
                arr[rear] = element;
            }
        }
    }
}
