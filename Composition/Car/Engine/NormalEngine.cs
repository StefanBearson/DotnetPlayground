namespace Composition.CarParts.Engine;

public class NormalEngine : IEngine
{
    public int MaxSpeed { get; set; } = 180;
    public void Start()
    {
        WriteLine("Normal engine started");
    }
}