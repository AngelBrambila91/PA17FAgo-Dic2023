// Operators
int a = 3;
int b = 4;
WriteLine($"a is {a} and b is {b}");

decimal c = 11;
decimal d = 3;
WriteLine($"c + d = {c + d}");
WriteLine($"c - d = {c - d}");
WriteLine($"c * d = {c * d}");
WriteLine($"c / d = {c / d}");
WriteLine($"c % d = {c % d}");

// Assignment operators
WriteLine("Assignment Operators");
int e = 6;
WriteLine($"e += 3 = {e += 3}");
WriteLine($"e -= 3; = {e -= 3}");
WriteLine($"e *= 3; = {e *= 3}");
WriteLine($"e /= 3; = {e /= 3}");

// Boolean Operators
bool f = true;
bool g = false;

WriteLine($"AND |f      |g");
WriteLine($"f   | {f & f,-5} | {f & g, -5}");
WriteLine($"g   | {g & f,-5} | {g & g, -5}");
WriteLine();

WriteLine($"OR |f      |g");
WriteLine($"f   | {f | f,-5} | {f | g, -5}");
WriteLine($"g   | {g | f,-5} | {g | g, -5}");
WriteLine();

WriteLine($"XOR |f      |g");
WriteLine($"f   | {f ^ f,-5} | {f ^ g, -5}");
WriteLine($"g   | {g ^ f,-5} | {g ^ g, -5}");
WriteLine();


// Conditional Operators
static bool DoStuff()
{
    WriteLine("I am working ... wink wink");
    return true;
}
WriteLine();
WriteLine($"f & Do Stuff() = {f & DoStuff()}");
WriteLine($"g & Do Stuff() = {g & DoStuff()}");

WriteLine();
WriteLine($"f & Do Stuff() = {f && DoStuff()}");
WriteLine($"g & Do Stuff() = {g && DoStuff()}");

// Miscellaneous
int age = 50;
char firstDigit = age.ToString()[0];
// = is the assignment operator
// . is the member access operator
// [] is the index access operator
// () is the invocation operator