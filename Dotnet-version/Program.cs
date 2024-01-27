using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;

internal class Program
{
    private static void Main(string[] args)
    {    
        // var nums1= new int[]{1,2,3,0,0,0};
        // var nums2= new int[]{2,5,6};
        var nums1= new int[]{4,5,6,0,0,0};
        var nums2= new int[]{1,2,3};

        MergeSortedArray.Merge(nums1, 3, nums2, 3);
        Console.WriteLine(JsonSerializer.Serialize(nums1));

    }
}