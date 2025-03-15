namespace ShortestPathInGraph;

partial class Program
{
    static void Main(string[] args)
    {
        // GraphAdjMatrix graph = new GraphAdjMatrix(4);
        // graph.AddUndirectedEdge(0,1,4);
        // graph.AddUndirectedEdge(0,2);
        // graph.AddUndirectedEdge(1,2);
        // graph.AddUndirectedEdge(2,3);
        //
        // graph.Print();

        // Graph g = new Graph(9);
        // g.AddUnDirectedEdge(0,1, 4);
        // g.AddUnDirectedEdge(0,7,8);
        // g.AddUnDirectedEdge(1,2,8);
        // g.AddUnDirectedEdge(1,7,11);
        // g.AddUnDirectedEdge(2,3,7);
        // g.AddUnDirectedEdge(2,8,2);
        // g.AddUnDirectedEdge(2,5,4);
        // g.AddUnDirectedEdge(3,4,9);
        // g.AddUnDirectedEdge(3,5,14);
        // g.AddUnDirectedEdge(4,5,10);
        // g.AddUnDirectedEdge(4,6,2);
        // g.AddUnDirectedEdge(6,7,1);
        // g.AddUnDirectedEdge(6,8,6);
        // g.AddUnDirectedEdge(7,8,7);
        //
        //
        // g.Print();
        // Console.WriteLine(".....................................");
        // g.Dijkstra(0);

        // Example graph (adjacency list with weights)

        int[,] adjacencyMatrix = new int[4, 4]
        {
            {0, 4, 2, 10},
            {0, 0, 1, 5},
            {0, 0, 0, 8},
            {0, 0, 0, 0}
        };
        
        Dijkstra dijkstra = new Dijkstra();
        
        //Raw graph
        Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>()
        {
            { 0, new Dictionary<int, int>() { { 1, 4 }, { 2, 2 }, { 3, 10} } },
            { 1, new Dictionary<int, int>() { { 2, 1 }, { 3, 5 } } },
            { 2, new Dictionary<int, int>() { { 3, 8 } } },
            { 3, new Dictionary<int, int>() }, // Example of a node with no outgoing edges.
            { 4, new Dictionary<int, int>() { { 1, 2 } } } // Example of a disconnected node
        };

        //GraphBuilder graph
        GraphBuilder graphBuilder = new GraphBuilder();
        graphBuilder.AddNode(0); //Add all Vertex
        graphBuilder.AddNode(1);
        graphBuilder.AddNode(2);
        graphBuilder.AddNode(3);
        graphBuilder.AddNode(4);
        graphBuilder.AddDirectedEdge(0, 1, 4); //Add Edges
        graphBuilder.AddDirectedEdge(0, 2, 2);
        graphBuilder.AddDirectedEdge(0, 3, 10);
        graphBuilder.AddDirectedEdge(1, 2, 1);
        graphBuilder.AddDirectedEdge(1, 3, 5);
        graphBuilder.AddDirectedEdge(2, 3, 8);
        graphBuilder.AddDirectedEdge(4, 1, 2);

        GraphBuilder graph2 = new GraphBuilder();
        
        ReturnData returnData = Dijkstra.FindShortestPaths(0, graph);
        Dictionary<int, List<int>> shortestPaths = returnData.paths;
        Dictionary<int, List<int>> costPerPath = returnData.costs;
        List<dataPoint> dataPoints = new List<dataPoint>();
        
        foreach (var kvp in shortestPaths)
        {
            if(kvp.Key != 0)
                dataPoints.Add(new dataPoint(0, kvp.Key, kvp.Value.ToArray(), costPerPath[kvp.Key].Last()));
            Console.WriteLine($"Shortest path to node {kvp.Key}: {string.Join(" -> ", kvp.Value)}");
        }
        
        foreach (var cost in costPerPath)
        {

            if(cost.Value.Count > 0) Console.WriteLine($"Total cost of path to node {cost.Key}: {cost.Value.Last()}");
            Console.WriteLine($"Cost of path to node {cost.Key}: {string.Join(" -> ", cost.Value)}");
        }
        
        // Example usage for a disconnected node:
        ReturnData returnData2 = Dijkstra.FindShortestPaths(4, graph);
        shortestPaths = returnData2.paths;
        
        foreach (var kvp in shortestPaths)
        {
            Console.WriteLine($"Shortest path to node {kvp.Key}: {string.Join(" -> ", kvp.Value)}");
        }
    }
}

internal class dataPoint
{
    public dataPoint(int start, int end, int[] path, int cost)
    {
        Start = start;
        End = end;
        Path = path;
        Cost = cost;
    }
    public int Start { get; set; }
    public int End { get; set; }
    public int[] Path { get; set; } 
    public int Cost { get; set; }
}
