using System.Globalization;


partial class Program
{
    private static void ConfigureConsole(string culture = "en-US",
    bool useComputerCulture = false)
    {
        // To enable Unicode characters like Euro symbol in the console.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        Console.WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.
       DisplayName}");
    }
    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"*** {title} ***");
        Console.ForegroundColor = previousColor;
    }
}
