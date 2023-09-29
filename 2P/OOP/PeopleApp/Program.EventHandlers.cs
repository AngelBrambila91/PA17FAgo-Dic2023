using PA17F.Shared;
partial class Program
{
    // A method to handle the Shout (delegate) event
    static void Jordi_Shout (object? sender, EventArgs e)
    {
        if(sender is null) return;
        Person? p = sender as Person;
        if(p is null) return; 
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }
}