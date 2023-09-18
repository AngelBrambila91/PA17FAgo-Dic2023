namespace PA17F.Shared;

public class Person
{
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
}
