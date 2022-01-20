using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting_Structures_Patterns.Interfaces;

namespace UnitTesting_Structures_Patterns.Structures
{
    /// <summary>
    /// This structure stores data in [KEY:DATA] pairs where KEY - unique integer that is used to indexing values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTable<T> : ICustomCollection<T> where T : IComparable
    {
        HashNode[] hashNodes;
        private int capacity;
        public class HashNode
        {
            public string key;
            public T data;
            public HashNode next;
            public HashNode previous;

            public HashNode()
            {
                data = default;
                key = default;
                next = previous = null;
            }
        }

        public HashTable()
        {
            capacity = 10000;
            hashNodes = new HashNode[capacity];
        }
        public HashTable(int size)
        {
            this.capacity = size;
            hashNodes = new HashNode[size];
        }

        /// <summary>
        /// Get hash by using division method
        /// </summary>
        /// <returns></returns>
        private int GetHash(string key)
        {
            int prime = 7;
            int prime2 = 31;

            for (int i = 0; i < key.Length; i++)
            {
                prime = (prime * prime2) + ((int)key[i] * i);
            }

            return Math.Abs(prime % hashNodes.Length);
        }

        /// <summary>
        /// Get hash by using System.HashCode struct
        /// </summary>
        /// <returns></returns>
        protected int GetHashUsingHashCodeStruct(string key)
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(key);
            return hashCode.ToHashCode();
        }

        private void AddCapacity(int index)
        {
            int capacity = hashNodes.Length;

            var lenght = index.ToString().Length;

            if (index >= lenght)
            {
                if (lenght > capacity.ToString().Length)
                {
                    while (lenght >= capacity.ToString().Length)
                    {
                        capacity = capacity * 100;
                    }
                }
                else
                {
                    while (index >= capacity)
                    {
                        capacity = capacity * 2;
                    }
                }
                Array.Resize(ref hashNodes, capacity);
                this.capacity = capacity;
            }
        }

        public void Add(T data)
        {
            //Add(GenerateKey(), data);
        }

        public void Add(string key, T data)
        {
            int hash = GetHash(key);

            if (hash >= hashNodes.Length)
            {
                AddCapacity(hash);
            }

            HashNode node = hashNodes[hash];

            if (node == null)
            {
                hashNodes[hash] = new HashNode() { data = data, key = key };
                return;
            }

            if (node.key == key)
            {
                CrearteChain(hash, data);
                return;
            }

            //while (node.next != null)
            //{
            //    node = node.next;
            //}

            HashNode nNode = new HashNode() { key = key, data = data, next = null, previous = node };
            node.next = nNode;
        }

        private void CrearteChain(int hash, T data)
        {
            var previous = hashNodes[hash];
            HashNode nNode = new HashNode() { key = previous.key, data = data, next = null, previous = previous };
            hashNodes[hash].next = nNode;
        }

        public IEnumerable<T> GetValue(string key)
        {
            int hash = GetHash(key);

            HashNode node = hashNodes[hash];

            while (node != null)
            {
                if (node.key == key)
                {
                    yield return node.data;
                }
                node = node.next;
            }
        }

        public T Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in hashNodes)
            {
                if (item != null)
                {
                    yield return item.data;

                    var chainItems = item;
                    while (chainItems.next != null)
                    {
                        yield return chainItems.next.data;
                        chainItems = item.next;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
