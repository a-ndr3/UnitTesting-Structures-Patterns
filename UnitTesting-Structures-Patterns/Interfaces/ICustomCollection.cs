using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Interfaces
{
    public interface ICustomCollection<T> : IEnumerable<T>
    {
        public void Add(T data);
        public T Delete();

    }
}
