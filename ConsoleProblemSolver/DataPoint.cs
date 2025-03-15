namespace ConsoleProblemSolver;

class DataPoint
{
    public DataPoint(int start, int end, int[] path, int cost)
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