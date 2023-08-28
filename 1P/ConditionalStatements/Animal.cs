public class Animal
{
    public string? Name;
    public DateTime Born;
    public int Legs;
    public bool IsDomestic;
    public int Age;
    Animal[] animals = new Animal?[]
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
            Name = "Pato",
            Born = new (year: 2012, month: 8, day: 2),
            Legs = 3,
            IsDomestic = true,
            Age = 12
        }

    };
}

public class Cat : Animal
{
    public bool isPoisonous;
}

public class Pig : Animal
{
}

public class Dog : Animal
{
}