namespace UnitTesting_Structures_Patterns.Structures.GraphBased
{
    /// <summary>
    /// A way to represent a graph as a matrix of booleans. If value == directed path exists
    /// </summary>
    public class AdjacencyMatrix
    {
        public bool[,] matr;
        int numVert;

        public AdjacencyMatrix(int numOfVerticles)
        {
            numVert = numOfVerticles;
            matr = new bool[numOfVerticles, numOfVerticles];
        }

        public void AddEdge(int i, int j)
        {
            matr[i, j] = true;
            matr[j, i] = true;
        }

        public void RemoveEdge(int i, int j)
        {
            matr[i, j] = false;
            matr[j, i] = false;
        }

    }

}

