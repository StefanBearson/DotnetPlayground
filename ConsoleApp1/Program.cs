namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        
        program.TestFirstStateMaschine();
        program.TestSecondStateMachone();
        program.TestRecursive();

        int[] numbers = new[] { 1, 4, 5, 4, 2, 4, 5};
        Console.WriteLine($"th bigest is : {program.MaxVolume(numbers)}");

        string[] prefixTest = new[] { "leet", "leeeeet", "lee" };

        Console.WriteLine($"this is the longest prefix: {LongestCommonPrefix(prefixTest)}");
    }

    private void TestFirstStateMaschine()
    {
        var chest = new Demo();
        
        Console.WriteLine($"a: {chest}");
        Console.WriteLine(chest.TryTakeLoot());        
        chest.ChangeState(Action.Open, true);
        
        Console.WriteLine($"b: {chest}");
        Console.WriteLine(chest.TryTakeLoot());        

        chest.ChangeState(Action.Close, false);
        Console.WriteLine($"c: {chest}");
        Console.WriteLine(chest.TryTakeLoot());        

        chest.ChangeState(Action.Open, true);
        Console.WriteLine($"d: {chest}");
        Console.WriteLine(chest.TryTakeLoot());     
    }

    private void TestSecondStateMachone()
    {
        var test = new SMTest();

        Console.WriteLine($"1: {test._state.State}");
        
        test._state.Fire(Action.Open);
        Console.WriteLine($"2: {test._state.State}");
        
        test.HaveKey = true;
        test._state.Fire(Action.Open);
        Console.WriteLine($"3: {test._state.State}");
        
        var mySingelton1 = MySingelton.Instant;
        Console.WriteLine(mySingelton1.GetGuid());
        
        var mySingelton2 = MySingelton.Instant;
        Console.WriteLine(mySingelton2.GetGuid());

    }

    private void TestRecursive()
    {
        RecursionClass recursionClass = new ();
        int[] numbers = {1, 2, 3, 4, 5, -15};
        Console.WriteLine(recursionClass.RecArrayOfNumbers(numbers));
        Console.WriteLine(recursionClass.SumOfArrayOfNumbers(numbers, 0));
    }

    private int MaxVolume(int[] heights)
    {
        int maxArea = 0;
        int n = heights.Length;

        for (int x = 0; x < n; x++)
        {
            for (int y = x + 1; y < n; y++)
            {
                int length = Math.Min(heights[x], heights[y]);
                int width = y - x;
                int area = length * width;
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;
        string prefix = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            var a = strs[i].IndexOf(prefix, StringComparison.Ordinal);
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (string.IsNullOrEmpty(prefix)) return string.Empty;
            }
        }

        return prefix;
    }
}