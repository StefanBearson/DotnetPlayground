namespace ConsoleProblemSolver;

public class Program
{
    static void Main(string[] args)
    {

        int[,] adjacencyMatrix = new int[4, 4]
        {
            {0, 4, 2, 10},
            {0, 0, 1, 5},
            {0, 0, 0, 8},
            {0, 0, 0, 0}
        };
        
        Dijkstra dijkstra = new Dijkstra();

        GraphBuilder graphBuilder = new GraphBuilder();
        graphBuilder.MatrixImporter(adjacencyMatrix);
        
        ReturnData returnData = Dijkstra.FindShortestPaths(0, graphBuilder.graph);
        List<DataPoint> dataPoints = new List<DataPoint>();
        
        foreach (var kvp in returnData.Paths)
        {
            if (kvp.Key != 0)
            {
                // (startNode, endNode, path, cost)
                dataPoints.Add(new DataPoint(0, kvp.Key, kvp.Value.ToArray(), returnData.Costs[kvp.Key].Last()));
                Console.WriteLine($"Shortest path to node {kvp.Key}: {string.Join(" -> ", kvp.Value)}");
            }
        }
        
        foreach (var cost in returnData.Costs)
        {

            if (cost.Value.Count > 0)
            {
                Console.WriteLine($"Total cost of path to node {cost.Key}: {cost.Value.Last()}");
            }
            Console.WriteLine($"Cost of path to node {cost.Key}: {string.Join(" -> ", cost.Value)}");
        }
    }
}

public record ReturnData(Dictionary<int, List<int>> Paths, Dictionary<int, List<int>> Costs);