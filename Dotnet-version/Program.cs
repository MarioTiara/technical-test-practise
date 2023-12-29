using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;

internal class Program
{
    private static void Main(string[] args)
    {    
        Console.WriteLine(JsonSerializer.Serialize(FindAnagrams.findAnagrams("cbaebabacd", "abc")));
    }

    
}