namespace AboutMyEnvironment;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(Environment.CurrentDirectory);
        Console.WriteLine(Environment.OSVersion.VersionString);
        Console.WriteLine("Namespace: {0}", typeof(Program).Namespace);

        bool p = true;
        bool q = false;
        Console.WriteLine($"AND | p | q ");
        Console.WriteLine($"p | {p & p,-5} | {p & q,-5} ");

        int age = 50;
        Console.WriteLine($"The {nameof(age)} variable uses {sizeof(int)} bytes of memory.");
    }
}
