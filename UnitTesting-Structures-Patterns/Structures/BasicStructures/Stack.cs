using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    /// <summary>
    /// Linear data structure (LIFO)
    /// </summary>
    public class Stack<T> : IEnumerable<T>, ICustomCollection<T>
    {
        T[] arr;
        int top; //top element
        int capacity;
        public Stack(int size)
        {
            arr = new T[size];
            capacity = size;
            top = -1;
        }


        public void Push(T element)
        {
            if (IsFull())
            {
                throw new OverflowException();
            }
            arr[++top] = element;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            return arr[top--];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == (capacity - 1);
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            return arr[top];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= top; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T data)
        {
            Push(data);
        }

        public T Delete()
        {
            return Pop();
        }
    }
}
