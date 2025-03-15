namespace ConsoleProblemSolver;

public class Dijkstra
{
    public static ReturnData FindShortestPaths(int startNode,
        Dictionary<int, Dictionary<int, int>> graph)
    {
        // 1. Initialization
        int numNodes = graph.Keys.Max() + 1; // Assuming nodes are 0-indexed
        Dictionary<int, int> distances = new();
        Dictionary<int, int> previousNodes = new();
        HashSet<int> visitedNodes = new();
        PriorityQueue<int, int> priorityQueue = new();
        
        foreach (int node in graph.Keys)
        {
            distances[node] = int.MaxValue; // Initialize all distances to infinity
        }

        distances[startNode] = 0;
        priorityQueue.Enqueue(startNode, 0); // Add the start node to the queue

        // 2. Dijkstra's Algorithm
        while (priorityQueue.Count > 0)
        {
            int currentNode = priorityQueue.Dequeue();

            if (visitedNodes.Contains(currentNode))
            {
                continue; // Skip if already visited
            }

            visitedNodes.Add(currentNode);

            if (!graph.ContainsKey(currentNode)) continue; //handle if node has no outgoing edges

            foreach (var neighbor in graph[currentNode])
            {
                int newDistance = distances[currentNode] + neighbor.Value;

                if (newDistance < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = newDistance;
                    previousNodes[neighbor.Key] = currentNode;
                    priorityQueue.Enqueue(neighbor.Key, newDistance);
                }
            }
        }

        // 3. Construct Paths
        Dictionary<int, List<int>> paths = new();
        Dictionary<int, List<int>> costs = new();
        foreach (int endNode in graph.Keys)
        {
            if (distances[endNode] == int.MaxValue) continue; // No path found

            List<int> path = new();
            List<int> cost = new();
            int currentNode = endNode;
            while (previousNodes.ContainsKey(currentNode))
            {
                path.Add(currentNode);
                cost.Add(distances[currentNode]);
                currentNode = previousNodes[currentNode];
            }
            
            path.Add(startNode); // Add the start node to the path
            path.Reverse(); // Reverse to get the correct order
            cost.Reverse();
            paths[endNode] = path;
            costs[endNode] = cost;
        }
        return new ReturnData(paths, costs);
    }
}