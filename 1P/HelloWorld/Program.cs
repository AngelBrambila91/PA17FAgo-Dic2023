using static System.Console;

#region Native Types
//native types
int number = 1;
float number1 = 1.2F;
double number2 = 2.4;
bool isTrue = false;
decimal number3 = 3.4M;
char character = 'A';
#endregion


// complex types
string name = "Victor";
DateTime dateOfBirth = DateTime.Now;


// by paramenter or position
WriteLine("The first number is : {0}", arg0: number);
// Interpolation
WriteLine($"The second number is : {number1}");
WriteLine($"Double number + 1.0 : {number2 + 1.0}");
WriteLine($"Decimal number + 1.0 : {number3 + 1.0M}");
WriteLine($"Int has {sizeof(int)} Bytes , The minumimum size of an int is : {int.MinValue} and max is : {int.MaxValue}");
WriteLine($"Double has {sizeof(double)} Bytes , The minumimum size of an int is : {double.MinValue} and max is : {double.MaxValue}");
WriteLine($"Float has {sizeof(float)} Bytes , The minumimum size of an int is : {float.MinValue} and max is : {float.MaxValue}");
WriteLine($"Decimal has {sizeof(decimal)} Bytes , The minumimum size of an int is : {decimal.MinValue} and max is : {decimal.MaxValue}");
WriteLine($"Char has {sizeof(char)} Bytes , The minumimum size of an int is : {char.MinValue} and max is : {char.MaxValue}");

