using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    /// <summary>
    /// Dobule ended queue. Insertion and removal can be done from the front and the rear. Doesn't follow FIFO rule.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dequeue<T> : ICustomCollection<T>
    {
        protected T[] arr;
        protected int front;
        protected int rear;
        protected int size;

        public Dequeue(int size)
        {
            arr = new T[size];
            front = -1;
            rear = 0;
            this.size = size;
        }

        public Dequeue(T[] array)
        {
            size = array.Length;
            arr = new T[size];
            foreach (var item in array)
            {
                Add(item);
            }

        }

        public bool IsFull()
        {
            if ((front == 0 && rear == (arr.Length - 1)) || (front == rear + 1))
                return true;
            return false;
        }

        public bool IsEmpty()
        {
            if (front == -1)
            {
                return true;
            }
            return false;
        }


        public void FrontInsert(T value)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (front == 0)
            {
                front = size - 1;
            }
            else
                front--;
            arr[front] = value;

        }

        public void RearInsert(T value)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (rear == size - 1)
            {
                rear = 0;
            }
            else
                rear++;
            arr[rear] = value;
        }

        public void DeleteFront()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            //only one element in deq
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (front == size - 1)
            {
                front = 0;
            }
            else
                front++;

        }

        public void DeleteRear()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (rear == 0)
            {
                rear = size - 1;
            }
            else
                rear--;
        }

        public T GetFrontElement()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            return arr[front];
        }

        public T GetRearElement()
        {
            if (IsEmpty() || rear < 0)
            {
                throw new Exception();
            }
            return arr[rear];
        }

        public Dequeue()
        {

        }

        public void Add(T data)
        {
            FrontInsert(data);
        }

        public T Delete()
        {
            DeleteRear();
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i < rear; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
