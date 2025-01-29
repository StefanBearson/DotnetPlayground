namespace Composition.CarParts.Engine;

public class SportEngine : IEngine
{
    public int MaxSpeed { get; set; } = 250;
    public void Start()
    {
        WriteLine("Sport engine started");
    }
}