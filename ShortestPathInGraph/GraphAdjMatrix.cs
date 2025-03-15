namespace ShortestPathInGraph;

public class GraphAdjMatrix
{
    private int count;
    private int[,] adjMatrix;

    public GraphAdjMatrix(int cnt)
    {
        count = cnt;
        adjMatrix = new int[cnt, cnt];
    }
    
    public void AddDirectedEdge(int from, int to, int weight = 1)
    {
        adjMatrix[from, to] = weight;
    }
    
    public void AddUndirectedEdge(int from, int to, int weight = 1)
    {
        adjMatrix[from, to] = weight;
        adjMatrix[to, from] = weight;
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Vertices {i} is connected to: ");
            for (int j = 0; j < count; j++)
            {
                if (adjMatrix[i, j] != 0)
                {
                    Console.Write($"{j}(cost: {adjMatrix[i, j]}) ");
                }
                
            }
            Console.WriteLine();
        }
    }

}