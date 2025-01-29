namespace Composition.CarParts.Engine;

public interface IEngine
{
    int MaxSpeed { get; set; }
    void Start();
}