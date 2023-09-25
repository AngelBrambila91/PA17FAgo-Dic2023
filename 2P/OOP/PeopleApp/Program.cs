using PA17F.Shared;
using static PA17F.Shared.Person;

partial class Program
{
    private static void Main(string[] args)
    {
        Person wachi = new();
        WriteLine($"Wachi is : {wachi.ToString()}");

        wachi.Name = "Alberto";
        wachi.DateOfBirth = new DateTime(2002, 12, 22);
        WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
        arg0: wachi.Name,
        arg1: wachi.DateOfBirth);

        // Generic Types
        // List , Hash , Dictionary, <T>, <TKey, TValue>
        // HashTable -> 1. Cannot duplicate keys, 2. All keys must be the same type
        Dictionary<int, string> lookUpIntString = new Dictionary<int, string>();
        lookUpIntString.Add(1, "Alpha");
        lookUpIntString.Add(2, "Delta");
        lookUpIntString.Add(3, "Gamma");
        lookUpIntString.Add(4, "Tetha");

        // Getting values from dictionary
        foreach (var key in lookUpIntString.Keys)
        {
            WriteLine($"Key : {key} has value of : {lookUpIntString[key]}");
        }
        // CallMethod()
        // public string CallMethod (int id)
        // Old way to call a Method
        Person Jordi = new();
        int answer = Jordi.MethodIWantToCall("Alfred");
        WriteLine(answer);

        // Using delegate to call a method
        // Creating an instance of the delegate
        DelegateWithMatchingSignature d = new(Jordi.MethodIWantToCall);
        int answer2 = d("Isaac");
        WriteLine(answer2);

        //Evet assign
        Jordi.Shout = Jordi_Shout;
        // triggers
        Jordi.Poke();
        Jordi.Poke();
        Jordi.Poke();
        Jordi.Poke();
    }
}