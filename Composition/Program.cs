using Composition.Car;
using Composition.CarParts.Engine;
using Composition.CarParts.Wheel;

Car volvo = new Car(new SportEngine(), new SportWheel());

volvo.Drive();
volvo.Speed = 300;
volvo.CheckSpeed();
volvo.ChangeWheel(new NormalWheel());
volvo.Drive();
volvo.Speed = 10;
volvo.CheckSpeed();
WriteLine($"The car is moving in a speed of {volvo.Speed}");

var runtest = new RunTest();
runtest.Run();