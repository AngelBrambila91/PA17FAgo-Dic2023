// if (expression)
// {

// }
// else if (expression)
// {

// }

string password = "SatouroGoujo";
if (password.Length < 12)
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

Animal?[] animals = new Animal?[]
{
        new Pig {
            Name = "Oreo",
            Born = new (year: 2012, month: 8, day: 2),
            Legs = 4,
            IsDomestic = true,
            Age = 12
        },
        new Cat {
            Name = "Juno",
            Born = new (year: 2010, month: 4, day: 23),
            Legs = 4,
            IsDomestic = true,
            Age = 12
        },

        new Dog {
            Name = "Platon",
            Born = new (year: 2012, month: 8, day: 2),
            Legs = 3,
            IsDomestic = true,
            Age = 12
        }

};
// pattern match switch
foreach (var animal in animals)
{
    string message = String.Empty;
    switch (animal)
    {
        case Cat fourLegCat when fourLegCat.Legs == 4:
        message = $"The name of the cat is {fourLegCat.Name}";
        break;
        
        case Pig chanchito when !chanchito.IsDomestic:
        message = $"You have a beautiful companion mate, say hi to {chanchito.Name}";
        break;

        case Dog platon when platon.Age == 11:
        message = $"Oldie but goldie, good old {platon.Name}";
        break;
        
        default:
        message = "That type of animal does not exists.";
        break;
    }

    // simplified switch | minimalist switch
    message = animal switch
    {
        // => Lambda
        Cat threeLegCat when threeLegCat.Legs == 3 => 
        $"The name of the three leg cat is {threeLegCat.Name}",
        Cat poisonousCat when poisonousCat.isPoisonous =>
        "STAY AWAY from that michi mate"
    };
}