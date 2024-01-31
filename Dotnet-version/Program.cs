using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;
using Technical_Test_Practice.Sorting_Algorithms;

internal class Program
{
    private static void Main(string[] args)
    {    
        // var nums1= new int[]{1,2,3,0,0,0};
        // var nums2= new int[]{2,5,6};
        var input=new int[]{4, -31, 0, 99, 83, 1};
        MergeSort.MergeSortAlgorithm(input, 0, input.Length-1);
       
        Console.WriteLine(JsonSerializer.Serialize(input));

        //var a = [4, -31, 0, 99, 83, 1];
        // current= 4

        //array=[4, -31, 0, 99, 83, 1];

        //current= -31
        //araay=



    }
}