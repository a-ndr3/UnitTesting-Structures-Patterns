using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures.BasicStructures
{
    public class Dequeue<T> : ICustomCollection<T>
    {
        protected T[] arr;


        public Dequeue()
        {

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
