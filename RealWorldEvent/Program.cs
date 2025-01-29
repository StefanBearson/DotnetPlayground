namespace RealWorldEvent;

public delegate void TemperatureChangerHandler(string message);
public delegate void OhShitHandler(string message);


public class TemperatureMonitor
{
    public event TemperatureChangerHandler OnTemperatureChanged;
    public event OhShitHandler OnOhShitHappen;
    private int _temperature;

    public int Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            if (_temperature > 25)
            {
                RaiseTemperatureChangeEvent("Its starting to be hot! ");
            }

            if (_temperature > 50)
            {
                OnOhShitHappen?.Invoke("Ohhh Not good! ");
            }
        }
    }

    protected virtual void RaiseTemperatureChangeEvent(string message)
    {
        OnTemperatureChanged?.Invoke(message);
    }
}

public class TemperatureAlert
{
    public void OnTemperatureChanged(string message)
    {
        Console.WriteLine(message);
    }
}

public class MailAlerts
{
    public static void OnTemperatureChanged(string message)
    {
        Console.WriteLine("A alert message is mailed!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureMonitor monitor = new();
        TemperatureAlert alert = new();

        monitor.OnOhShitHappen += alert.OnTemperatureChanged;
        monitor.OnTemperatureChanged += alert.OnTemperatureChanged;
        monitor.OnTemperatureChanged += MailAlerts.OnTemperatureChanged;

        while (true)
        {
            Console.WriteLine("Enter temperatur:");
            monitor.Temperature = int.Parse(Console.ReadLine() ?? string.Empty);
        }
    }
}