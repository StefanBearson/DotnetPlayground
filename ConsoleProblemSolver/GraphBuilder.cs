namespace ConsoleProblemSolver;

public class GraphBuilder
{
    public Dictionary<int, Dictionary<int, int>> graph = new();
        
    public void AddNode(int node)
    {
        graph[node] = new();
            
    }
        
    public void AddDirectedEdge(int from, int to, int weight)
    {
        if (!graph.ContainsKey(from))
        {
            graph[from] = new();
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
        Dictionary<int, Dictionary<int, int>> tempgraph = new();

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            Dictionary<int, int> row = new();
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != 0)
                {
                    row[j] = matrix[i, j];
                }
            }
            tempgraph[i] = row;
        }

        graph = tempgraph;
    }
}