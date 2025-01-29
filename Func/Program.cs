namespace Func;

class Program
{
    public delegate void LogIt(string message);
    public Action<string> LogIt2 = myFunc.PrintMessage;
    static void Main(string[] args)
    {


        var program = new Program();
        program.RunMe();
    }

    public void RunMe()
    {
        LogIt logIt = myFunc.PrintMessage;
        logIt += myFunc.ScreamMessage;
        
        //how to fix this warnings?
        if (Helper.IsMethodInDelegate(logIt, "PrintMessage"))
        {
            logIt -= myFunc.PrintMessage;
        }

        logIt -= myFunc.ScreamMessage;
        
        logIt?.Invoke("Hello My name is Stefan");
        
        LogIt2 += myFunc.ScreamMessage;
        LogIt2.Invoke("Testar om detta funkar");
    }
}

class Helper
{
    public static bool IsMethodInDelegate(Program.LogIt logIt, string methodName)
    {
        if (logIt == null)
        {
            return false;
        }
        
        foreach (var log in logIt.GetInvocationList())
        {
            if (log.Method.Name == methodName)
            {
                return true;
            }
        }

        return false;
    }
}

class myFunc
{
    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    
    public static void ScreamMessage(string message)
    {
        Console.WriteLine(message.ToUpper());
    }
}
