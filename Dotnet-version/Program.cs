using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;

internal class Program
{
    private static void Main(string[] args)
    {    
        var input= new List<int>{1,1,2,2,3};

        Console.WriteLine(JsonSerializer.Serialize(TwoSum.twoSum(new int []{2,7,11,15}, 9)));
           
    }

    
}