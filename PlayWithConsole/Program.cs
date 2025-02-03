namespace PlayWithConsole;

class Program
{
    static void Main()
    {
        // var test = Environment.GetCommandLineArgs();
        FizzBuss();
        int[] myIntArray = new[] { 1, 2, 3, 4, 5 };
        int indexof4 = BinarySearch(myIntArray, 4);
        Console.WriteLine($"Hello, index {indexof4} in the array is {myIntArray[indexof4]}");
    }
    
    /// <summary>
    /// Generates a sequence of numbers from 0 to 29 and prints "Fizz", "Buzz", "FizzBuzz", or the number itself
    /// based on specific conditions.
    /// </summary>
    public static void FizzBuss()
    {
        for (int i = 0; i < 30; i++)
        {
            string result = i switch
            {
                0 => i.ToString(),
                int n when n % 5 == 0 => "FizzBuzz",
                int n when n % 3 == 0 => "Buzz",
                int n when n % 2 == 0 => "Fizz",
                _ => i.ToString()
            };
            Console.WriteLine(result);
        }

        var a = new List<int>();
        
        a.AddRange(1,2,3,4,5);

        foreach (int number in a)
        {
            Console.WriteLine($"This is the number: {number}");
        }
    }

    /// <summary>
    /// Performs a binary search on a sorted array to find the target value.
    /// </summary>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="target">The value to search for.</param>
    /// <returns>
    /// The index of the target value in the array if found; otherwise, -1.
    /// </returns>
    public static int BinarySearch(int[] array, int target)
    {
        
        int left = 0;
        int right = array.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target) return mid;
            if (array[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}
public class Person
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public static class PersonExtensions
{
    public static int GetAge(this Person person)
    {
        return DateTime.Today.Year - person.DateOfBirth.Year;
    }
}



