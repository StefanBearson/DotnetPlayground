var test = "Hello World!";
Console.WriteLine(test);
void ChangeTest(ref string refTest)
{
    refTest = "Hello World! Changed!";
}

ChangeTest(ref test);

Console.WriteLine(test);

void DoOutNow(out string message)
{
    message = "Hello World! Out!";
}

DoOutNow(out string message);

Console.WriteLine(message);