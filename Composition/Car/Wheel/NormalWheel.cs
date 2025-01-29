namespace Composition.CarParts.Wheel;

public class NormalWheel : IWheel
{
    public void Rotate()
    {
        WriteLine("Normal wheel rotating");
    }
}