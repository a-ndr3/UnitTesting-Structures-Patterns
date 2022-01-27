namespace UnitTesting_Structures_Patterns.Structures.Dynamic_other
{
    /// <summary>
    /// Helps to find the shortest path between all the pairs of verticles in a weighted graph
    /// </summary>
    public class WFIAlgorithm
    {
        public WFIAlgorithm()
        {

        }

        /// <summary>
        /// Matrix has to be square
        /// </summary>
        /// <param name="graph"></param>
        public void GetShortestWays(int[,] graph, int matrSize)
        {
            var matr = graph;

            for (int k = 0; k < matrSize; k++)
            {
                for (int i = 0; i < matrSize; i++)
                {
                    for (int j = 0; j < matrSize; j++)
                    {
                        if (matr[i, k] + matr[k, j] < matr[i, j])
                        {
                            matr[i, j] = matr[i, k] + matr[k, j];
                        }
                    }
                }
            }

        }
    }
}
