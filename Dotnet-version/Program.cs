using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;

internal class Program
{
    private static void Main(string[] args)
    {    
        var input=new int[]{2,0,2,1,1,0};
        SortColor.SortColors(input);
        Console.WriteLine(JsonSerializer.Serialize(input));

    }
}