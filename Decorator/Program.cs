using System.Collections.Immutable;

namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
        DecorateTestMeClasses testMeOne = new(new FirstTest());
        DecorateTestMeClasses testMeTwo = new(new SecondTest());
        testMeOne.RunThis("Hello world from test one!");
        testMeTwo.RunThis("Hello world from test two!");
        
        //In a Real world application:
        // var builder = WebApplication.CreaterBuilder(args);
        // builder.Services.AddSingelton<FirstTest>();
        // builder.Services.AddSingelton<ITestMe>(x =>
        //     new DecorateTestMeClasses(x.GetRequiredService<FirstTest>()));

        
        //OR:
        // builder.Services.AddKeyedSingelton<ITestMe, FirstTest>("orignal");
        // builder.Services.AddKeyedSingelton<ITestMe, DecorateTestMeClasses>();
        //
        //Usage:
        //Add this in the constructor params, THIS IS NEEDED IN THE DECORATOR NOW, SO YOU DONT DO EVIL LOOP :)
        //[FromKeyedServices("orginal)]ITestMe testMe
        
        
        
    }
}

interface ITestMe
{
    /// <summary>
    /// Runs the specified message.
    /// </summary>
    /// <param name="message">The message to be run.</param>
    void RunMe(string message);
}

class FirstTest : ITestMe
{
    public void RunMe(string message)
    {
        Console.WriteLine(message);
    }
}

class SecondTest : ITestMe
{
    public void RunMe(string message)
    {
        Console.WriteLine(message.ToUpper());
    }
}

class DecorateTestMeClasses
{
    private readonly ITestMe _testMe;

    public DecorateTestMeClasses(ITestMe testMe)
    {
        _testMe = testMe;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DecorateTestMeClasses"/> class.
    /// </summary>
    /// <param name="testMe">An instance of <see cref="ITestMe"/> to be decorated.</param>
    public void RunThis(string message)
    {
        Console.WriteLine($"The message: {message} will be printed");
        _testMe.RunMe(message);
        
        //Do more things
    }
}