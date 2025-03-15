
class Program
{
    static void Main()
    {
        var solution = new Solution();
        int[][] heights = new int[][] {
            new int[] { 1, 2, 2, 3, 5 },
            new int[] { 3, 2, 3, 4, 4 },
            new int[] { 2, 4, 5, 3, 1 },
            new int[] { 6, 7, 1, 4, 5 },
            new int[] { 5, 1, 1, 2, 4 }
        };
        
        var result = solution.PacificAtlantic(heights);
        foreach (var cell in result)
        {
            Console.WriteLine($"[{cell[0]}, {cell[1]}]");
        }
    }
}

public class Solution
{
public IList<IList<int>> PacificAtlantic(int[][] heights) {
        if (heights == null || heights.Length == 0 || heights[0].Length == 0) {
            return new List<IList<int>>();
        }
    
        int rows = heights.Length;
        int cols = heights[0].Length;
        var pacific = new HashSet<(int, int)>();
        var atlantic = new HashSet<(int, int)>();
    
        int[][] directions = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };
        /// <summary>
        /// Checks if the new cell coordinates are within the grid boundaries and if the height of the neighboring cell
        /// is greater than or equal to the current cell's height. If both conditions are met, the DFS method is called
        /// recursively for the neighboring cell.
        /// </summary>
        /// <param name="newRow">The row index of the neighboring cell.</param>
        /// <param name="newCol">The column index of the neighboring cell.</param>
        /// <param name="rows">The total number of rows in the grid.</param>
        /// <param name="cols">The total number of columns in the grid.</param>
        /// <param name="heights">The 2D array representing the heights of the cells.</param>
        /// <param name="row">The row index of the current cell.</param>
        /// <param name="col">The column index of the current cell.</param>
        /// <param name="ocean">The HashSet representing the cells that can reach a specific ocean.</param>
        void DFS(int row, int col, HashSet<(int, int)> ocean) {
            if (ocean.Contains((row, col))) return;
            ocean.Add((row, col));
    
            foreach (var dir in directions) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && heights[newRow][newCol] >= heights[row][col]) {
                    DFS(newRow, newCol, ocean);
                }
            }
        }
    
        for (int i = 0; i < rows; i++) {
            DFS(i, 0, pacific);
            DFS(i, cols - 1, atlantic);
        }
        for (int j = 0; j < cols; j++) {
            DFS(0, j, pacific);
            DFS(rows - 1, j, atlantic);
        }
    
        var result = new List<IList<int>>();
        foreach (var cell in pacific) {
            if (atlantic.Contains(cell)) {
                result.Add(new List<int> { cell.Item1, cell.Item2 });
            }
        }
    
        return result;
    }
}