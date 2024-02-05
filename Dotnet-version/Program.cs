using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Technical_Test_Practice;
using Technical_Test_Practice.Arry_Problems;
using Technical_Test_Practice.Sorting_Algorithms;

internal class Program
{
    private static void Main(string[] args)
    {    
        // var nums1= new int[]{1,2,3,0,0,0};
        // var nums2= new int[]{2,5,6};
        // [[1,100],[11,22],[1,11],[2,12]]
        // var input= new int[][]{
        //     new int[]{1,100},
        //     new int[]{11,22},
        //     new int[]{1,11},
        //     new int[]{2,12},
            
        // };

          var input= new int[][]{
            new int[]{1,2},
            new int[]{2,3},
            new int[]{3,4},
            new int[]{1,3},
            
        };
        //   var input= new int[][]{
        //     new int[]{1,2},
        //     new int[]{1,2},
        //     new int[]{1,2},           
        // };

        
        var result= LC435_NonOverlapingIntervals.EraseOverlapingIntervals(input);
       
        Console.WriteLine(JsonSerializer.Serialize(input));

        //var a = [4, -31, 0, 99, 83, 1];
        // current= 4

        //array=[4, -31, 0, 99, 83, 1];

        //current= -31
        //araay=



    }
}