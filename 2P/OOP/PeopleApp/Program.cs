using PA17F.Shared;

Person wachi = new();
WriteLine($"Wachi is : {wachi.ToString()}");

wachi.Name = "Alberto";
wachi.DateOfBirth = new DateTime(2002, 12, 22);
WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}", 
arg0: wachi.Name,
arg1: wachi.DateOfBirth);