namespace ConsoleApp1;

class MySingelton
{
    private string TheGuid = Guid.NewGuid().ToString();
    private static readonly Lazy<MySingelton> _instant = new Lazy<MySingelton>(() => new MySingelton());

    private MySingelton()
    {

    }

    public string GetGuid()
    {
        return TheGuid;
    }
    public static MySingelton Instant => _instant.Value;
}