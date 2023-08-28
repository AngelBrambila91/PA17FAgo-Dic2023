using static System.Console;
// Margins
// {index [,alignment] [:formatString]}
string pearText = "Pear";
int pearCount = 12345;
string pricklyPearText = "Prickly Pear";
int pricklyPearCount = 450000;

// HEADERS
WriteLine(
format: "{0, -12} {1, 7}",
arg0: "Name",
arg1: "Count");

// 1st Row
WriteLine(
    format:"{0,-12} {1,7:N0}",
    arg0: pearText,
    arg1: pearCount
);

// 2nd Row
WriteLine(
    format:"{0,-12} {1,7:N0}",
    arg0: pricklyPearText,
    arg1: pricklyPearCount
);

Write("Type your first name and press ENTER : ");
string firstName = ReadLine();
Write("Type your age and press ENTER : ");
string age = ReadLine();
WriteLine($"Hello {firstName} you look good for {age}");