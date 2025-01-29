namespace Composition.CarParts.Wheel;

public class SportWheel : IWheel
{
    public void Rotate()
    {
        WriteLine("Sport wheel rotating");
    }
}