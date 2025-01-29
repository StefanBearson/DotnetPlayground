using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Fizz
{
    public class FizzBuzz
    {
        public static string GetFizzBuzz(int number)
        {
            return number switch
            {
                _ when number % 3 == 0 && number % 5 == 0 => "FizzBuzz",
                _ when number % 3 == 0 => "Fizz",
                _ when number % 5 == 0 => "Buzz",
                _ => number.ToString()
            };
        }

        public static string GetFizzBuzzWithIfElse(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }

        public static List<int> GetFizzBuzzList(int number)
        {
            return Enumerable.Range(1, number).ToList();
        }
    }
}