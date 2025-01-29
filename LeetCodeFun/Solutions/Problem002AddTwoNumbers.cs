namespace LeetCodeFun.Solutions;

public class Problem002AddTwoNumbers
{
    public void run(int[] input1, int[] input2)
    {
        int[] result = AddTwoNumbers(input1, input2);
        foreach (var i in result)
        {
            Console.WriteLine(i);
        }
    }
    
    private int[] AddTwoNumbers(int[] input1, int[] input2)
    {
        int[] result = new int[input1.Length];
        for (int i = 0; i < input1.Length; i++)
        {
            int sum = input1[i] + input2[i];

            result[i] = sum > 10 ? sum % 10 : sum;
        }
        return result;
    }
}
