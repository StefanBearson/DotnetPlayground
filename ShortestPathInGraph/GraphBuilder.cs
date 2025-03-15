namespace ShortestPathInGraph;

partial class Program
{
    public class GraphBuilder
    {
        public Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();
        
        public void AddNode(int node)
        {
            graph[node] = new Dictionary<int, int>();
            
        }
        
        public void AddDirectedEdge(int from, int to, int weight)
        {
            if (!graph.ContainsKey(from))
            {
                graph[from] = new Dictionary<int, int>();
            }
            graph[from][to] = weight;
        }
        
        public void AddUnDirectedEdge(int from, int to, int weight)
        {
            AddDirectedEdge(from, to, weight);
            AddDirectedEdge(to, from, weight);
        }
        
        public void MatrixImporter(int[,] matrix)
        {
            Dictionary<int, Dictionary<int, int>> tempgraph = new Dictionary<int, Dictionary<int, int>>();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                tempgraph[i] = new Dictionary<int, int>();
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        tempgraph[i][j] = matrix[i, j];
                    }
                }
            }

            graph = tempgraph;
        }
    }
}