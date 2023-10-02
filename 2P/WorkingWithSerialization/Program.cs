using System.Xml.Serialization; // XmlSerializer
using PA17F.Shared;
using static System.Environment;
using static System.IO.Path;

List<Person> people = new()
{
    new(30000M)
    {
        Name = "Isaac",
        LastName = "Chavez",
        DateOfBirth = new (year: 2005, month: 03, day: 2)
    },
    new(40000M)
    {
        Name = "Carolina",
        LastName = "Prian",
        DateOfBirth = new(year: 2006, month: 05, day: 14)
    },
    new(20000M)
    {
        Name = "Samantha",
        LastName = "Valadez",
        DateOfBirth = new(year: 2005, month:02, day:20)
    },
    new(8000M)
    {
        Name = "Juan",
        LastName = "Torres",
        DateOfBirth = new(year: 2001, month:04, day:25),
        Children = new()
        {
            new(0M)
            {
                Name = "Juanito",
                LastName = "Cholico",
                DateOfBirth = new(year: 2023, month: 10, day:1)
            },
            new(0M)
            {
                Name = "Tamara",
                LastName = "Cholico",
                DateOfBirth = new(year: 2021, month: 09, day:02)
            }
        }
    }
};

#region Serialize
// The XML serialzer NEEDS to know what 
// type of data is going to be serialized
XmlSerializer xs = new(type: people.GetType());
// create a file
string path = Combine(CurrentDirectory, "people.xml");
// Implicit Declaration
// 3 birds 1 stone : 
// 1: Take care of open on stream declaration
// 2: When } gets hit , Close file is called
// 3: Create file on declaration on Create(path)
using (FileStream stream = File.Create(path))
{
    // serialize the object
    xs.Serialize(stream, people);
}
WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
WriteLine();
// READ
WriteLine(File.ReadAllText(path));
#endregion

#region Deserialize
WriteLine("Deseriliaze people List");
// Open file
using (FileStream xmlLoad = File.Open(path,FileMode.Open))
{
    // Deserialize
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if(loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine($"{p.Name} has {p.Children?.Count ?? 0} children.");
        }
    }
}
#endregion