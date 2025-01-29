namespace Events;

public delegate void Notify(string message);

public class EventPublisher
{
    public event Notify OnNotify = null!;
    public event Action<string> OnNotifyWithAction = null!;  
    
    public void RaiseEvent(string message)
    {
        message += ":From Delegate thing";
        OnNotify?.Invoke(message);
    }

    public void RaiseActionEvent(string message)
    {
        message += ":from action thingi";

        OnNotifyWithAction?.Invoke(message.ToUpper());
    }
}

public class EventSubscriber
{
    public void OnEventRaised(string messaage)
    {
        Console.WriteLine($"Hello, {messaage}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EventPublisher publisher = new EventPublisher();
        EventSubscriber subscriber = new EventSubscriber();

        publisher.OnNotify += subscriber.OnEventRaised;
        publisher.OnNotifyWithAction += subscriber.OnEventRaised;
        
        publisher.RaiseActionEvent("this is from action event");
        publisher.RaiseEvent("this is from delegate event");

    }
}