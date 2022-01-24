using System.Collections;
using System.Collections.Generic;

namespace UnitTesting_Structures_Patterns.Structures.GraphBased
{
    public class AdjacencyList : IEnumerable
    {
        private int numOfVerticles;
        public LinkedList<int>[] lists;

        public AdjacencyList(int amountOfVerticles)
        {
            lists = new LinkedList<int>[amountOfVerticles];

            for (int i = 0; i < amountOfVerticles; i++)
            {
                lists[i] = new LinkedList<int>();
            }
        }

        public AdjacencyList()
        {
            lists = new LinkedList<int>[10];
        }

        void AddCapacityToArray(ref LinkedList<int>[] arr)
        {
            System.Array.Resize(ref arr, arr.Length * 2);
        }

        public void AddEdge(int x, int y)
        {
            if (x >= lists.Length)
            {
                AddCapacityToArray(ref lists);
            }

            lists[x].AddLast(y);
            lists[y].AddLast(x);
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in lists)
            {
                var en = item.GetEnumerator();
                while (en.MoveNext())
                {
                    yield return en.Current;
                }
            }
        }
    }
}
