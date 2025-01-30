using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();

void RunData()
{
    Test test = new(40);
    test.fizzBuzz();
    
}

public class Test
{
    private int Age { get; set; }

    public Test(int age)
    {
        Age = age;
    }

    public int GetAge()
    {
        return Age;
    }

    public void SetAge(int age)
    {
        Age = age;
    }

    public override string ToString()
    {
        return $"The age is {Age}";
    }

    public void fizzBuzz()
    {
        for (int i = 0; i < 30; i++)
        {
            if (i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
                break;
            }

            if (i % 3 == 0)
            {
                Console.WriteLine("Buzz");
                break;
            }

            if (i % 2 == 0)
            {
                Console.WriteLine("Fizz");
                break;
            }

            Console.WriteLine(i);
        }
    }
}

public static class MyExtensions
{
    public static string MyAgeAsString(this Test test)
    {
        return test.GetAge().ToString();
    }
}