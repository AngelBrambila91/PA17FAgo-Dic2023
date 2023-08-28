// string[] args
WriteLine($"There are {args.Length} arguments.");

foreach (var argument in args)
{
    WriteLine(argument);
}

#region Infer Types
// PROS : Best type to transfer data
// CONS : Don't inherit all the methods and/or properties
object number = "13";
WriteLine(number.GetType());
string name = "Nebai";

// PROS : Inherit methods and properties
// CONS : Allocates memory on CPU and do not use Garbage Collector
dynamic decimalNumber = 45.8;
WriteLine(decimalNumber.GetType());

// PROS : Inherit methods and properties
// PROS : Frees memory from RAM
var array = new int [1,2,3,4];
WriteLine(array.GetType());
#endregion


if(args.Length < 3)
{
    WriteLine("You must specify two colors and cursor size e.g ");
    WriteLine("dotnet run red yellow 50");
    return; // stop running;
}
// ambit scope
// 1st Color
ForegroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[0],
    ignoreCase: true
);

// 2nd Color
BackgroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[1],
    ignoreCase: true
);
try
{
CursorSize = int.Parse(args[2]);
}
catch (System.PlatformNotSupportedException)
{
    WriteLine("The current platform does not support the change in cursor size");
}