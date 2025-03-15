
namespace ShortestPathInGraph;

public class Graph
{
    private int count;
    private List<List<Edge>> Adj;

    private class Edge : IComparable<Edge>
    {
        internal int source, target, cost;

        public Edge(int s, int t, int c)
        {
            source = s;
            target = t;
            cost = c;
        }

        public int CompareTo(Edge compareEdge)
        {
            return this.cost - compareEdge.cost;
        }
    }

    public Graph(int cnt)
    {
        count = cnt;
        Adj = new List<List<Edge>>();
        for (int i = 0; i < cnt; i++)
        {
            Adj.Add(new List<Edge>());
        }
    }

    public void AddDirectedEdge(int source, int target, int cost = 1)
    {
        Edge edge = new Edge(source, target, cost);
        Adj[source].Add(edge);
    }

    public void AddUnDirectedEdge(int source, int target, int cost = 1)
    {
        AddDirectedEdge(source, target, cost);
        AddDirectedEdge(target, source, cost);
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            List<Edge> ad = Adj[i];
            Console.Write($"Vertex {i} is connected to : ");
            foreach (Edge edge in ad)
            {
                Console.Write($" {edge.target}(cost: {edge.cost})");
            }

            Console.WriteLine();
        }
    }

    public void Dijkstra(int source)
    {
        int[] previous = new int[count];
        Array.Fill(previous, -1);
        int[] dist = new int[count];
        Array.Fill(dist, int.MaxValue);
        bool[] visited = new bool[count];
        dist[source] = 0;
        previous[source] = source;

        PriorityQueue<Edge, int> pq = new PriorityQueue<Edge, int>();
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node, node.cost);
        int current;

        while (pq.Count != 0)
        {
            node = pq.Peek();
            pq.Dequeue();
            current = node.target;
            visited[current] = true;
            List<Edge> adl = Adj[current];

            foreach (Edge adn in adl)
            {
                int dest = adn.target;
                int alt = adn.cost + dist[current];
                if (dist[dest] > alt && visited[dest] == false)
                {
                    dist[dest] = alt;
                    previous[dest] = current;
                    node = new Edge(current, dest, alt);
                    pq.Enqueue(node, node.cost);
                }
            }
        }

        PrintPath(previous, dist, count, source);
        
    }

    public void GetShortestWayToEndPoint(int[] previous, int[] dist, int count, int source, int end)
    {
        //<goal(end), [every node that leads to goal]>
        Dictionary<int, List<int>> everyEndsPath = new Dictionary<int, List<int>>();
        
        int tempDest;
            
        for (int i = 0; i < count; i++)
        {
            //if (dist[i] == 99999)

            if (i != previous[i])
            {
                tempDest = dist[i];
                //string path = PathUtil(previous, source, i, everyEndsPath, tempDest);
                tempDest = -1;
                if (!everyEndsPath.Keys.Contains(i)) everyEndsPath.Add(i, new List<int>(){i});
                else everyEndsPath[i].Add(i);
            }
            else if (i != previous[i])
            {
                tempDest = dist[i];
                tempDest = -1;
            }
        }
    }
    
    public Dictionary<int, List<int>> PathUtil(int[] previous, int source, int dest,Dictionary<int, List<int>> everyEndsPath, int currentDest )
    {
        String path = "";
        if (dest == source) path += source;
        else
        {
            path += PathUtil(previous, source, previous[dest], everyEndsPath, currentDest);
            path += $"-> {dest}";
            if (!everyEndsPath.Keys.Contains(currentDest)) everyEndsPath.Add(currentDest, new List<int>(){dest});
            else everyEndsPath[currentDest].Add(dest);
            // tempDest = dest;
        }

        return everyEndsPath;
    }
    
    public void PrintPath(int[] previous, int[] dist, int count, int source)
    {
        string output = "Shortest Paths: ";
        //
        for (int i = 0; i < count; i++)
        {
            if (dist[i] == 99999)
                output += $"( {source} -> {i} @ Unreachable! )";
            else if (i != previous[i])
            {

                output += $"({PrintPathUtil(previous, source, i)})";

                output += $"( @ {dist[i]} )";
            }
        }
        
        Console.WriteLine(output);
    }

    public string PrintPathUtil(int[] previous, int source, int dest)
    {
        String path = "";
        if (dest == source) path += source;
        else
        {
            // path += PrintPathUtil(previous, source, previous[dest]);
            // path += $"-> {dest}";
            // if (!veryCool.Keys.Contains(tempDest)) veryCool.Add(tempDest, new List<int>(){dest});
            // else veryCool[tempDest].Add(dest);
            // tempDest = dest;
        }

        return path;
    }
}
