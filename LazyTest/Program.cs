// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
RunMe();
void RunMe()
{
    Console.WriteLine($"Start 1: {DateTime.Now}");
    Lazy<string> theString = new Lazy<string>(DoOnce);
    Console.WriteLine($"End 1: {DateTime.Now}");
    Console.WriteLine($"Start 2: {DateTime.Now}");
    DoWork(theString.Value);
    Console.WriteLine($"End 2: {DateTime.Now}");
}


string DoOnce()
{
    Thread.Sleep(2000);
    return "World!";
}

void DoWork(string message)
{
    Thread.Sleep(2000);
    Console.WriteLine($"Hello {message}");
}