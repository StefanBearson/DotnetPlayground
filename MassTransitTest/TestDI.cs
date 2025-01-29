
using Microsoft.Extensions.Options;

namespace MassTransitTest;

public class TestDI(IOptions<DiSettings> settings) : ITestDI
{
    private int _counter = 1;
    public void Print()
    {
        Console.WriteLine($"TestDI {_counter} {settings.Value.Name}");
        _counter++;
    }
}