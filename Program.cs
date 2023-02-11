using CSharpToTSConverter;
var response = "abc";

while(response.ToLower() != "quit" && !string.IsNullOrEmpty(response))
{
    Console.WriteLine("Enter path to read or type quit to exit");
    response = Console.ReadLine();
    if (response.ToLower() != "quit" && !string.IsNullOrEmpty(response)) 
    {
        Console.WriteLine("Enter interface name (leave empty if don't want to change): ");
        var name = Console.ReadLine();
        Console.WriteLine(Converter.ReadClass(response, name));
    }
}

Console.WriteLine("Program ended");
Console.ReadLine();