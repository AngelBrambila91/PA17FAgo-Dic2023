namespace PA17F.Shared;

public class Person
{
    public delegate int DelegateWithMatchingSignature (string s);
    // members
    // constant, read -onlys, events
    /* Constant : Once declared and 
    assigned, cannot be changed even
    in runtime

    Read-Only : Similar to a constant
    but you can change the value on runtime
    using constructor

    Event: Reference to another method

    Methods: Functions, Execute statements
    Constructor : Executed when the NEW , allocates memory
    
    Property : 
    member -> int number = 0;
    public void setNumber (int number ) { this.number = number; }
    public int get Number() { return this.number; }
    string Name { get; set;} getter and setters

    Indexers: []
    Operators : + - => * / &
    */
    
    // members
    public string? Name;
    public DateTime DateOfBirth;
    // Delegates
    public int MethodIWantToCall(string input)
    {
        return input.Length;
    }

    // 1st Step, Event Handler
    public delegate void EventHandler (object? sender, EventArgs e);

    // delegate field
    public EventHandler? Shout;
    // Data Field for delegate
    public int AngerLevel;
    public void Poke()
    {
        AngerLevel++;
        if(AngerLevel >= 3)
        {
            // if something is listening
            if(Shout != null)
            {
                // then call the delegate
                Shout(this, EventArgs.Empty);
            }
        }
    }
}
