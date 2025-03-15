namespace SaabTestHelper;

class Program
{
    static void Main(string[] args)
    {
        int width = 5;
        int height = 5;
        List<List<int>> grid = new List<List<int>>();
        for (int i = 0; i < height; i++)
        {
            grid.Add(new List<int>(Enumerable.Repeat(0, width)));
        }
    }
}