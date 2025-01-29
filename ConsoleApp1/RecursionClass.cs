namespace ConsoleApp1;

class RecursionClass
{
    public int RecArrayOfNumbers(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }
        return numbers[0] + RecArrayOfNumbers(numbers[1..]);
    }

    public int SumOfArrayOfNumbers(int[] numbers, int total)
    {
        if (numbers.Length == 0) return total;

        return SumOfArrayOfNumbers(numbers[1..], total + numbers[0]);
    }
}