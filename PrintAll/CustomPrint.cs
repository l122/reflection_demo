namespace PrintAll;

public class CustomPrint
{
    private string name;

    public static string StaticName => "Static property.";

    public string Name => this.name;

    public void Print()
    {
        Console.WriteLine("Printing from Print.");
    }

    public string GetName()
    {
        return this.name;
    }

    public void PrintName()
    {
        Console.WriteLine($"Name set as {this.name}");
    }

    public void Print(string name )
    {
        Console.WriteLine($"Name passed {name}");
    }

    private void PrintPrivate()
    {
        Console.WriteLine("Printing from private.");
    }
}