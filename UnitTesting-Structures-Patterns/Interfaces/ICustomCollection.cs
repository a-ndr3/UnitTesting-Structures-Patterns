using System.Collections.Generic;

namespace UnitTesting_Structures_Patterns.Interfaces
{
    public interface ICustomCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Add data to the collection
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data);

        public T Delete();

    }
}
