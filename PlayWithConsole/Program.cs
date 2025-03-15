
enum Direction
{
    Right = 0,
    Down = 3,
    Left = 2,
    Up = 1
}   

class Program
{
    public static void Main(string[] args)
    {
        //initialize grid
        int height = 13, width = 13;
        List<List<bool>> grid = new List<List<bool>>();;
        for(int i = 0; i < height; i++)
        {
            grid.Add(new List<bool>(Enumerable.Repeat(false, width)));
        }
        
        //set start position
        int positionx = 0;
        int positiony = 0;
        grid[positionx][positiony] = true;
        
        //draw the path
        moveToPosotion((int)Direction.Up, 1);
        moveToPosotion((int)Direction.Right, width - 2);
        moveToPosotion((int)Direction.Up, height - 3);
        moveToPosotion((int)Direction.Left, width - 3);
        
        moveToPosotion((int)Direction.Down, 7);
        moveToPosotion((int)Direction.Right, 7);
        moveToPosotion((int)Direction.Up, 4);
        moveToPosotion((int)Direction.Left, 4);
        moveToPosotion((int)Direction.Down, 2);
        
        //print the grid
        Print();
        
        void moveToPosotion(int direction, int moves)
        {
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };
            
            for (int i = 0; i < moves; i++)
            {
                positionx += dx[direction];
                positiony += dy[direction];
                grid[positionx][positiony] = true;
            }
        }

        void Print()
        {
            grid.Reverse();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(grid[i][j] ? "X " : ". ");
                }
                Console.WriteLine();
            }
        }
    }
}

