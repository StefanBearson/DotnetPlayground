using System.Text.RegularExpressions;
using System;

namespace RegEx;

class Program
{
    static void Main(string[] args)
    {
        string input = "Hello this is a test";
        string regExPattern = @"^Hello";

        Regex regex = new (regExPattern);

        Match match = regex.Match(input);

        if (match.Success)
        {
            Console.WriteLine("Success!");
            Console.WriteLine($"{input} matches with ({regExPattern})");
            Console.WriteLine($"Value: {match.Value}");
        }

        if (!match.Success)
        {
            Console.WriteLine("Sorry, no match!");
        }

        MatchCollection matches = regex.Matches(input);
        foreach (Match m in matches)
        {
            Console.WriteLine("Email: " + m.Value);
        }

    }
}