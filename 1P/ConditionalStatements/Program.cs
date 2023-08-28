// if (expression)
// {

// }
// else if (expression)
// {

// }

string password = "SatouroGoujo";
if(password .Length < 12)
{
    WriteLine("Your password is too short. Use at least 12");
}
else
{
    WriteLine("Your password is strong");
}

object o = "3";
int j = 4;
if (o is int i/*out reference*/)
{
    WriteLine($"{i} * {j} = {i * j}");
}
else
{
    WriteLine("o is not integer, cannot multiply");
}

// Random number with switch
int number = Random.Shared.Next(1, 7);
WriteLine($"Memory random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break;
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3:
    case 4:
        WriteLine("Three or Four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
}
WriteLine("After end of switch");
A_label:
WriteLine("After A_label");

