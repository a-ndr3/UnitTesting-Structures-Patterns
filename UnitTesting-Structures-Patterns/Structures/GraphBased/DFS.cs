namespace UnitTesting_Structures_Patterns.Structures.GraphBased
{
    /// <summary>
    /// Depth first search algorithm which is recursive algorithm for searching all the verticles of a graph or tree data structure.
    /// </summary>
    public class DFS
    {
        AdjacencyList list;
        private bool[] visited;
        private int size = 10;

        public DFS(int vert)
        {
            list = new AdjacencyList(vert);
            visited = new bool[vert];
        }

        public DFS()
        {
            list = new AdjacencyList();
            visited = new bool[size];
        }

        void AddCapacityToArray(ref bool[] arr)
        {
            System.Array.Resize(ref arr, arr.Length*2);
        }

        public void AddEdge(int src, int dest)
        {
            list.AddEdge(src, dest);
        }

        public void DfsAlg(int vert)
        {
            while (visited.Length <= vert)
            {
                AddCapacityToArray(ref visited);
            }

            visited[vert] = true;

            var adj = 0;

            var iter = list.lists[vert].GetEnumerator();

            while (iter.MoveNext())
            {
                adj = iter.Current;

                if (!visited[adj])
                {
                    DfsAlg(adj);
                }
            }
        }
    }
}
