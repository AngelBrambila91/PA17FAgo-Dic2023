partial class Program {
    static void Sectiontitle(string title)
    {
        ConsoleColor backGroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("*");
        WriteLine($"{title}");
        WriteLine("*");
        ForegroundColor = backGroundColor;
    }

    static void Fail(string message)
    {
        ConsoleColor backGroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Fail > {message}");
        ForegroundColor = backGroundColor;
    }

    static void Info(string message)
    {
        ConsoleColor backGroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($"Info > {message}");
        ForegroundColor = backGroundColor;
    }
}