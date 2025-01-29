namespace AbstractTesting;

class Program
{
    static void Main(string[] args)
    {
        ConcreteClass a = new();
        
        a.a();
        a.b();
    }
}

class ConcreteClass : AbstractOne
{
    public override void a()
    {
        Console.WriteLine("from a method");
    }

    public override void b()
    {
        base.b();
        Console.WriteLine("from new one");
    }
}

abstract class AbstractOne
{
    public abstract void a();

    public virtual void b()
    {
        Console.WriteLine("old Things");
    }
}